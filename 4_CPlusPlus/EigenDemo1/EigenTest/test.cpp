#include "pch.h"
#include <Eigen/Dense>

using namespace std;
using namespace Eigen;

TEST(TestCaseName, TestName) {
  EXPECT_EQ(1, 1);
  EXPECT_TRUE(true);
}

TEST(EignMatrix, TransformTest)
{

	Matrix4d transform;

	transform << 1, 0, 0, 20,  0, 1, 0, 20,  0, 0, 1, 0,  0, 0, 0, 1 ;

	cout << transform << endl;

	Vector4d initialPos;
	initialPos << 4, 5, 0, 1;

	Vector4d finalMovedPos;

	finalMovedPos = transform * initialPos;

	Vector4d DestinationPos;
	DestinationPos << 24, 25, 0, 1;

	EXPECT_EQ(finalMovedPos, DestinationPos);
	EXPECT_TRUE(true);
	
}