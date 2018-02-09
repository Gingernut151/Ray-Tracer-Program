#include "RayTracer.h"

//--------------------------------------------------------------------------------------------------------------
RayTracer::RayTracer()
{}
//--------------------------------------------------------------------------------------------------------------
RayTracer::~RayTracer()
{}
//--------------------------------------------------------------------------------------------------------------
float RayTracer::Mix(const float &a, const float &b, const float &mix)
{
	return b * mix + a * (1 - mix);
}
//--------------------------------------------------------------------------------------------------------------
Vec3f RayTracer::Trace(const Vec3f &rayorig, const Vec3f &raydir, const vector<Sphere*> &spheres, const int &depth)
{
	//if (raydir.length() != 1) std::cerr << "Error " << raydir << std::endl;
	float tnear = INFINITY;
	const Sphere* sphere = NULL;
	// find intersection of this ray with the sphere in the scene
	for (unsigned i = 0; i < spheres.size(); ++i)
	{
		float t0 = INFINITY, t1 = INFINITY;

		if (spheres.at(i)->Intersect(rayorig, raydir, t0, t1))
		{
			if (t0 < 0)
				t0 = t1;

			if (t0 < tnear)
			{
				tnear = t0;
				sphere = spheres[i];
			}
		}
	}
	// if there's no intersection return black or background color
	if (!sphere)
		return Vec3f(2);

	Vec3f surfaceColor = 0; // color of the ray/surfaceof the object intersected by the ray
	Vec3f phit = rayorig + raydir * tnear; // point of intersection
	Vec3f nhit = phit - sphere->center; // normal at the intersection point

	nhit.normalize(); // normalize normal direction
					  // If the normal and the view direction are not opposite to each other
					  // reverse the normal direction. That also means we are inside the sphere so set
					  // the inside bool to true. Finally reverse the sign of IdotN which we want
					  // positive.
	float bias = float(1e-4); // add some bias to the point from which we will be tracing
	bool inside = false;

	if (raydir.dot(nhit) > 0)
		nhit = -nhit, inside = true;

	if ((sphere->transparency > 0 || sphere->reflection > 0) && depth < MAX_RAY_DEPTH)
	{
		float facingratio = -raydir.dot(nhit);
		float fresneleffect = Mix(pow(1.0f - facingratio, 3.0f), 1.0f, 0.1f);		// change the mix value to tweak the effect
		Vec3f refldir = raydir - nhit * 2.0f * raydir.dot(nhit);		// compute reflection direction (not need to normalize because all vectors are already normalized)

		refldir.normalize();

		Vec3f reflection = Trace(phit + nhit * bias, refldir, spheres, depth + 1);
		Vec3f refraction = 0;

		// if the sphere is also transparent compute refraction ray (transmission)
		if (sphere->transparency)
		{
			float ior = 1.1f, eta = (inside) ? ior : 1.0f / ior; // are we inside or outside the surface?
			float cosi = -nhit.dot(raydir);
			float k = 1.0f - eta * eta * (1.0f - cosi * cosi);
			Vec3f refrdir = raydir * eta + nhit * (eta *  cosi - sqrt(k));
			refrdir.normalize();
			refraction = Trace(phit - nhit * bias, refrdir, spheres, depth + 1);
		}
		// the result is a mix of reflection and refraction (if the sphere is transparent)
		surfaceColor = (
			reflection * fresneleffect +
			refraction * (1.0f - fresneleffect) * sphere->transparency) * sphere->surfaceColor;
	}
	else {
		// it's a diffuse object, no need to raytrace any further
		for (unsigned i = 0; i < spheres.size(); ++i) {
			if (spheres.at(i)->emissionColor.x > 0) {
				// this is a light
				Vec3f transmission = 1.0f;
				Vec3f lightDirection = spheres.at(i)->center - phit;
				lightDirection.normalize();
				for (unsigned j = 0; j < spheres.size(); ++j) {
					if (i != j) {
						float t0, t1;
						if (spheres.at(i)->Intersect(phit + nhit * bias, lightDirection, t0, t1)) {
							transmission = 0;
							break;
						}
					}
				}
				surfaceColor += sphere->surfaceColor * transmission *
					std::max(float(0), nhit.dot(lightDirection)) * spheres.at(i)->emissionColor;
			}
		}
	}

	return surfaceColor + sphere->emissionColor;
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::ThreadedTrace(const vector<Sphere*> &spheres, Vec3f* pixel, unsigned int yMin, unsigned int yMax)
{
	// Trace rays
	for (yMin; yMin < yMax; ++yMin)
	{
		for (unsigned int x = 0; x < _width; ++x, ++pixel)
		{
			float xx = (2.0f * ((x + 0.5f) * _invWidth) - 1.0f) * _angle * _aspectratio;
			float yy = (1.0f - 2.0f * ((yMin + 0.5f) * _invHeight)) * _angle;
			Vec3f raydir(xx, yy, -1.0f);
			raydir.normalize();
			*pixel = Trace(Vec3f(0), raydir, spheres, 0);
		}
	}
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::SaveTimeData()
{
	ofstream dataFile;
	dataFile.open("Data/ThreadedData.txt", std::ios::app);
	dataFile << _frameDelta.count() << endl;
	dataFile.close();

	dataFile.open("Data/RaytraceTimeData.txt", std::ios::app);
	dataFile << _rayTraceDelta.count() << endl;
	dataFile.close();

	dataFile.open("Data/FileSaveData.txt", std::ios::app);
	dataFile << _fileSaveDelta.count() << endl;
	dataFile.close();

	dataFile.open("Data/StringStreamData.txt", std::ios::app);
	dataFile << _stringStreamDelta.count() << endl;
	dataFile.close();

	dataFile.open("Data/ToFileData.txt", std::ios::app);
	dataFile << _toFIleDelta.count() << endl;
	dataFile.close();
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::InitializeFrame()
{
	_invWidth = 1 / float(_width);
	_invHeight = 1 / float(_height);
	_fov = 80;
	_aspectratio = _width / float(_height);
	_angle = float(tan(M_PI * 0.5f * _fov / 180.0f));
}
//--------------------------------------------------------------------------------------------------------------
std::string fixedLength(int value, int digits = 3)
{
	unsigned int uvalue = value;
	std::string result;

	if (value < 0) 
	{
		uvalue = -uvalue;
	}

	while (digits-- > 0) 
	{
		result += ('0' + uvalue % 10);
		uvalue /= 10;
	}

	if (value < 0)
	{
		result += '-';
	}

	std::reverse(result.begin(), result.end());
	return result;
}
//--------------------------------------------------------------------------------------------------------------
chrono::high_resolution_clock::time_point RayTracer::SaveToPPM(Vec3f *image, const unsigned int iteration)
{
	// Save result to a PPM image (keep these flags if you compile under Windows)

	string number = fixedLength(iteration, 4);
	string file = "./Pics/spheres" + number + ".ppm";
	char* filename = (char*)file.c_str();

	string width = to_string(_width);
	string height = to_string(_height);

	const size_t widthCount = width.length();
	const size_t heightCount = width.length();
	const size_t headerlength = widthCount + heightCount + 9;

	char* header = new char[headerlength];

	unsigned int headerPointer = 0;
	header[headerPointer] = unsigned char('P');
	headerPointer++;
	header[headerPointer] = unsigned char('6');
	headerPointer++;
	header[headerPointer] = unsigned char('\n');
	headerPointer++;

	for (unsigned int i = 0; i < widthCount; i++)
	{
		header[headerPointer] = unsigned char(width.at(i));
		headerPointer++;
	}

	header[headerPointer] = unsigned char(' ');
	headerPointer++;

	for (unsigned int i = 0; i < heightCount; i++)
	{
		header[headerPointer] = unsigned char(height.at(i));
		headerPointer++;
	}

	header[headerPointer] = unsigned char('\n');
	headerPointer++;
	header[headerPointer] = unsigned char('2');
	headerPointer++;
	header[headerPointer] = unsigned char('5');
	headerPointer++;
	header[headerPointer] = unsigned char('5');
	headerPointer++;
	header[headerPointer] = unsigned char('\n');
	headerPointer++;

	const unsigned int dataSize = (_width * _height * 3) + headerPointer;
	char* data = new char [dataSize];

	for (unsigned int i = 0; i < headerPointer; i++)
	{
		// str is likely to be an array of characters
		data[i] = header[i];
	}
	unsigned int datapointer = headerPointer;
	for (unsigned i = 0; i < _width * _height; ++i)
	{
		data[datapointer] = (unsigned char)(std::min(float(1), image[i].x) * 255);
		datapointer++;
		data[datapointer] = (unsigned char)(std::min(float(1), image[i].y) * 255);
		datapointer++;
		data[datapointer] = (unsigned char)(std::min(float(1), image[i].z) * 255);
		datapointer++;
	}


	chrono::high_resolution_clock::time_point stringStreamTimeEnd = chrono::high_resolution_clock::now();

	ofstream imageFile;
	imageFile.open(filename, std::ios::out | std::ios::binary);
	imageFile.write(data, dataSize);
	imageFile.close();

	delete[] data;

	return stringStreamTimeEnd;
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::Render(const vector<Sphere*> &spheres, unsigned int iteration)
{
	chrono::high_resolution_clock::time_point startTime = chrono::high_resolution_clock::now();

	InitializeFrame();

	Vec3f* image = new Vec3f[_width * _height];
	Vec3f* pixel = image;
	vector<thread> myThreads;

	for (int i = 0; i < _numOfThreads; i++)
	{
		unsigned int start = 0 + (i * (_height / _numOfThreads));
		unsigned int end = 0 + ((i + 1) * (_height / _numOfThreads));

		// So no chance to miss last row if last row is odd (int rounding error)
		if (i == (_numOfThreads - 1))
		{
			end = _height;
		}

		myThreads.push_back(thread(&RayTracer::ThreadedTrace, this, spheres, pixel + (start * _width), start, end));
	}

	for (size_t i = 0; i < myThreads.size(); i++)
	{
		myThreads[i].join();
	}

	chrono::high_resolution_clock::time_point rayTraceTimeEnd = chrono::high_resolution_clock::now();
	chrono::high_resolution_clock::time_point fileSaveTimeStart = chrono::high_resolution_clock::now();
	chrono::high_resolution_clock::time_point stringStreamTimeStart = chrono::high_resolution_clock::now();

	chrono::high_resolution_clock::time_point stringStreamTimeEnd;
	
	stringStreamTimeEnd = SaveToPPM(image, iteration);

	delete[] image;

	chrono::high_resolution_clock::time_point fullFrameTimeEnd = chrono::high_resolution_clock::now();

	_frameDelta = chrono::duration_cast<chrono::duration<double>>(fullFrameTimeEnd - startTime);
	_rayTraceDelta = chrono::duration_cast<chrono::duration<double>>(rayTraceTimeEnd - startTime);
	_fileSaveDelta = chrono::duration_cast<chrono::duration<double>>(fullFrameTimeEnd - fileSaveTimeStart);
	_stringStreamDelta = chrono::duration_cast<chrono::duration<double>>(stringStreamTimeEnd - stringStreamTimeStart);
	_toFIleDelta = chrono::duration_cast<chrono::duration<double>>(fullFrameTimeEnd - stringStreamTimeEnd);

	SaveTimeData();
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::PopulateSpheres(vector<Sphere*>* spheres)
{
	vector<vector<string>> data;
	ifstream stream("Data/Spheres.csv");

	ReadCsv(stream, data);

	for (size_t i = 1; i < data.size(); i++) // Start at 1 so i dont include the column headings
	{
		Sphere* sphere = new Sphere(
			data.at(i).at(0), // Name
			Vec3f(stof(data.at(i).at(1)), stof(data.at(i).at(2)), stof(data.at(i).at(3))), // Position
			stof(data.at(i).at(4)), // Radius
			Vec3f(stof(data.at(i).at(5)), stof(data.at(i).at(6)), stof(data.at(i).at(7))), // Surface Colour
			stof(data.at(i).at(8)), //Reflectivity
			stof(data.at(i).at(9)), // Transparency
			stof(data.at(i).at(10)), // Emission Colour
			stof(data.at(i).at(12)), // Parent
			data.at(i).at(11)); // Rotation Speed

		spheres->push_back(sphere);
	}

	stream.close();
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::DeleteSpheres(vector<Sphere*>* spheres)
{
	for (size_t i = 0; i < spheres->size(); i++)
	{
		delete spheres->at(i);
	}

	spheres->clear();
}
//--------------------------------------------------------------------------------------------------------------
std::istream& RayTracer::ReadCsv(std::istream& myfile, std::vector<std::vector<string>>& data)
{
	using namespace std;
	string row;
	while (getline(myfile, row))
	{
		data.push_back(vector<string>());
		istringstream tokenS(row);
		string token;

		while (getline(tokenS, token, ','))
		{
			istringstream valueS(token);
			valueS.imbue(myfile.getloc());
			string value;
			if (valueS >> value)
				data.back().push_back(value);
		}
	}

	return myfile;
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::ReadInConfig()
{
	ConfigLoader cfg("Data/Config.cfg");
	string x = cfg.GetValueOfKey<string>("ScreenX");
	string y = cfg.GetValueOfKey<string>("ScreenY");
	string threads = cfg.GetValueOfKey<string>("Threads");
	string frameCount = cfg.GetValueOfKey<string>("FrameCount");
	string sphereCount = cfg.GetValueOfKey<string>("SphereCount");
	string fps = cfg.GetValueOfKey<string>("Fps");

	stringstream ss;
	ss << x;
	ss >> _width; //--
	ss.str(y);
	ss.clear();
	ss >> _height; //--
	ss.str(threads);
	ss.clear();
	ss >> _numOfThreads; //--
	ss.str(frameCount);
	ss.clear();
	ss >> _numOfFrames; //--
	ss.str(sphereCount);
	ss.clear();
	ss >> _numOfSpheres; //--
	ss.str(fps);
	ss.clear();
	ss >> _fps; //--


	ofstream clearFile;
	clearFile.open("Data/ThreadedData.txt");
	clearFile << "";
	clearFile.close();

	clearFile.open("Data/RaytraceTimeData.txt");
	clearFile << "";
	clearFile.close();

	clearFile.open("Data/FileSaveData.txt");
	clearFile << "";
	clearFile.close();
}
//--------------------------------------------------------------------------------------------------------------
Vec3f RayTracer::OrbitSphere(Vec3f angle, Vec3f centre, Vec3f position)
{
	angle = (angle * (1.0f / _fps)) * (float(M_PI) / 180.0f); // Convert to radians
	float rotatedX = cos(angle.x) * (position.x - centre.x) - sin(angle.x) * (position.y - centre.y) + centre.x;
	float rotatedY = sin(angle.y) * (position.x - centre.x) + cos(angle.y) * (position.y - centre.y) + centre.y;

	return Vec3f(rotatedX, rotatedY, position.z);
}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::Update(const vector<Sphere*>& spheres)
{
	Vec3f centre = 0.0f;

	for (unsigned int i = 0; i < _numOfSpheres; i++)
	{
		string parent = spheres.at(i)->parent;

		if (parent.compare("0"))
		{
			centre = 0.0;
		}
		else
		{
			for (unsigned int x = 0; x < _numOfSpheres; x++)
			{
				if (parent.compare(spheres.at(x)->name))
				{
					centre = spheres.at(x)->center;
				}
			}
		}

		spheres.at(i)->center = OrbitSphere(spheres.at(i)->rotationAmount, centre, spheres.at(i)->center);
	}


}
//--------------------------------------------------------------------------------------------------------------
void RayTracer::SmoothScaling()
{
	ReadInConfig();

	MemoryPool* pool = new MemoryPool(_numOfSpheres, sizeof(Sphere));
	Sphere::SetMemoryPool(pool);

	vector<Sphere*>* spheres = new vector<Sphere*>;

	PopulateSpheres(spheres);

	for (unsigned int r = 0; r <= _numOfFrames; r++)
	{
		Render(*spheres, r);
		Update(*spheres);
		std::cout << "Rendered and saved spheres" << r << ".ppm" << std::endl;
	}

	DeleteSpheres(spheres);
}
