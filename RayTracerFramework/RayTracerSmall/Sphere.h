#pragma once
#include "Commons.h"
#include "MemoryPool.h"

class Sphere
{
public:
	Sphere(const string &nam, const Vec3f &c, const float &r, const Vec3f &sc, const float &refl, const float &transp, const Vec3f &ec, const float &rotAmount, const string &paren);
	~Sphere();

	static void SetMemoryPool(MemoryPool* pool);

	void* operator new (size_t size);
	void operator delete(void* object);

	bool Intersect(const Vec3f &rayorig, const Vec3f &raydir, float &t0, float &t1) const;

//private:
	Vec3f center;                           /// position of the sphere
	float radius, radius2;                  /// sphere radius and radius^2
	Vec3f surfaceColor, emissionColor;      /// surface color and emission (light)
	float transparency, reflection;         /// surface transparency and reflectivity
	float rotationAmount;					/// the amount to rotate around the parent
	string name, parent;					/// Name of Sphere, name of parent it orbits

private:
	static MemoryPool* _pool;
};