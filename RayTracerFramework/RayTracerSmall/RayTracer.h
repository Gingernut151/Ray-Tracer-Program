#pragma once
#include <vector>
#include <iostream>
#include <fstream>
#include <sstream>
#include <algorithm>
#include <functional>
#include <cmath>
#include <thread>
#include <chrono>

#include "Commons.h"
#include <math.h>
#include "Sphere.h"
#include "ConfigLoader.h"
#include "MemoryPool.h"

using namespace::std;

class RayTracer
{
public:
	RayTracer();
	~RayTracer();

	void SmoothScaling();

private:
	float Mix(const float &a, const float &b, const float &mix);
	Vec3f Trace(const Vec3f &rayorig, const Vec3f &raydir, const vector<Sphere*> &spheres, const int &depth);

	Vec3f OrbitSphere(Vec3f angle, Vec3f centre, Vec3f position);

	void InitializeFrame();
	void SaveTimeData();
	chrono::high_resolution_clock::time_point SaveToPPM(Vec3f *image,const unsigned int iteration);

	void Render(const vector<Sphere*> &spheres, unsigned int iteration);
	void Update(const vector<Sphere*> &spheres);

	void PopulateSpheres(vector<Sphere*>* spheres);
	void DeleteSpheres(vector<Sphere*>* spheres);

	void ThreadedTrace(const vector<Sphere*> &spheres, Vec3f* pixel, unsigned int yMin, unsigned int yMax);

	void ReadInConfig();
	std::istream& ReadCsv(std::istream& myfile, std::vector<std::vector<string>>& data);

private:
	// Recommended Testing Resolution
	unsigned int _width = 640;
	unsigned int _height = 480;

	MemoryPool* _spherePool;

	int _numOfThreads;
	unsigned int _numOfFrames;
	unsigned int _numOfSpheres;
	unsigned int _fps;

	float _invWidth;
	float _invHeight;
	float _fov;
	float _aspectratio;
	float _angle;

	chrono::duration<double> _frameDelta;
	chrono::duration<double> _rayTraceDelta;
	chrono::duration<double> _fileSaveDelta;
	chrono::duration<double> _stringStreamDelta;
	chrono::duration<double> _toFIleDelta;

	//string _data;

private:
#define M_PI 3.141592653589793
//#define INFINITY 1e8

	//[comment]
	// This variable controls the maximum recursion depth
	//[/comment]
#define MAX_RAY_DEPTH 5
};

