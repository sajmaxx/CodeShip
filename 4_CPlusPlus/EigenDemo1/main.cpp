#include <Eigen/Dense>
#include <iostream>

using namespace std;
using namespace Eigen;


//refer this link on how to initialize and use eigen library matrices and vectors
/// https://eigen.tuxfamily.org/dox/group__TutorialAdvancedInitialization.html
///	https://eigen.tuxfamily.org/dox/index.html = Starter Page


int main()
{

	Matrix4d transform;

	transform << 1, 0, 0, 20,  0, 1, 0, 20,  0, 0, 1, 0,  0, 0, 0, 1 ;

	cout << transform << endl;

	Vector4d initialPos;
	initialPos << 4, 5, 0, 1;

	Vector4d finalMovedPos;

	finalMovedPos = transform * initialPos;


	cout << " Final position after transformation is " << finalMovedPos ;

}