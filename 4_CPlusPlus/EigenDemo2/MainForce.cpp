#include <iostream>
#include<Eigen/Dense>
#include <math.h>

const float  pieby180  = 3.14159265358979323846/180;

using namespace std;
using namespace  Eigen;

int main()
{

	Vector4d v1;

	v1 << 20, 0, 10, 0;

	Matrix4d rotbyX;

	rotbyX << 1, 0, 0, 0,
	               0, cos(45*pieby180), -sin(45*pieby180), 0,
	               0, sin(45*pieby180), cos(45*pieby180), 0,
	               0, 0, 0, 1;

	

	Matrix4d rotbyZ;

	rotbyZ << cos(45*pieby180), -sin(45*pieby180), 0, 0,
				sin(45*pieby180), cos(45*pieby180), 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1;


	cout << rotbyX;
	cout << "\n\n";
	cout << rotbyZ;

	Vector4d rotatedByz45 = rotbyZ * v1;
	cout << "\n\nZ Rotated vector is " << endl;
	cout << rotatedByz45;


	Vector4d rotatedPos = rotbyX * rotatedByz45;
	cout << "\n\nX Rotated vector is " << endl;
	cout << rotatedPos;

	//do 2 rotations at once
	Vector4d rotate2Pos = rotbyX*(rotbyZ*v1);
	cout << "\n\nZ and then X Rotated vector is " << endl;
	cout << rotate2Pos;

	return 0;
}