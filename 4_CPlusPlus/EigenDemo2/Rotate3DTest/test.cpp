#include "pch.h"

const float  pieby180  = 3.14159265358979323846/180;

using namespace std;
using namespace Eigen;

TEST(TestCaseName, TestName) {
  EXPECT_EQ(1, 1);
  EXPECT_TRUE(true);
}

TEST(TestCaseZXRotation, RotZAndX)
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


	Vector4d rotatedByz45 = rotbyZ * v1;
	Vector4d rotatedByx45 = rotbyX * rotatedByz45;
	
	Vector4d rotate2Pos = rotbyX*(rotbyZ*v1);

	EXPECT_EQ(rotate2Pos, rotatedByx45);
	EXPECT_TRUE(true);

	
}