#include "RayTracer.h"

//[comment]
// In the main function, we will create the scene which is composed of 5 spheres
// and 1 light (which is also a sphere). Then, once the scene description is complete
// we render that scene, by calling the render() function.
//[/comment]
int main(int argc, char **argv)
{
	RayTracer* tracer = new RayTracer();
	tracer->SmoothScaling();

	return 0;
}

