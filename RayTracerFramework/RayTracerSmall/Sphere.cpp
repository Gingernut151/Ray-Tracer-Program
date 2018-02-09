#include "Sphere.h"

MemoryPool* Sphere::_pool = nullptr;
	//--------------------------------------------------------------------------------------------------------------
	Sphere::Sphere(const string &nam, const Vec3f &c, const float &r, const Vec3f &sc, const float &refl, const float &transp, const Vec3f &ec, const float &rotAmount, const string &paren)
	{ 
		center = c;
		radius = r;
		radius2 = r * r;
		surfaceColor = sc;
		emissionColor = ec;
		transparency = transp;
		reflection = refl;
		name = nam;
		parent = paren;
		rotationAmount = rotAmount;
	}
	//--------------------------------------------------------------------------------------------------------------
	Sphere::~Sphere()
	{

	}
	//--------------------------------------------------------------------------------------------------------------
	//[comment]
	// Compute a ray-sphere intersection using the geometric solution
	//[/comment]
	bool Sphere::Intersect(const Vec3f &rayorig, const Vec3f &raydir, float &t0, float &t1) const
	{
		Vec3f l = center - rayorig;
		float tca = l.dot(raydir);

		if (tca < 0)
			return false;

		float d2 = l.dot(l) - tca * tca;

		if (d2 > radius2)
			return false;

		float thc = sqrt(radius2 - d2);

		t0 = tca - thc;
		t1 = tca + thc;

		return true;
	}
	//--------------------------------------------------------------------------------------------------------------
	void Sphere::SetMemoryPool(MemoryPool* pool)
	{
		_pool = pool;
	}
	//--------------------------------------------------------------------------------------------------------------
	void* Sphere::operator new (size_t size)
	{
		if (_pool)
		{
			return _pool->Alloc(size);
		}
		else
		{
			return nullptr;
		}
	}
	//--------------------------------------------------------------------------------------------------------------
	void Sphere::operator delete(void* object)
	{
		if (_pool)
		{
			_pool->Free(object);
		}
	}