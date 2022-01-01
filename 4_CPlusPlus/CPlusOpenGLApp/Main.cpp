#include <GL/glut.h>
#include<iostream>
#include "CarClass.h"
#include "Airplane.h"
#include "../MathLibSM/MathLibSM.h"  // << = static library

using namespace std;

int rx = 100, ry = 125;
int xCenter = 250, yCenter = 250;
 
void myinit(void)
{
    glClearColor(1.0, 1.0, 1.0, 0.0);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(0.0, 640.0, 0.0, 480.0);
}
 
void setPixel(GLint x, GLint y)
{
    glBegin(GL_POINTS);
    glVertex2i(x, y);
    glEnd();
}
void ellipseMidPoint()
{
    float x = 0;
    float y = ry;
    float p1 = ry * ry - (rx * rx) * ry + (rx * rx) * (0.25);
    float dx = 2 * (ry * ry) * x;
    float dy = 2 * (rx * rx) * y;
    glColor3ub(rand() % 255, rand() % 255, rand() % 255);
    while (dx < dy)
    {
        setPixel(xCenter + x, yCenter + y);
        setPixel(xCenter - x, yCenter + y);
        setPixel(xCenter + x, yCenter - y);
        setPixel(xCenter - x, yCenter - y);
        if (p1 < 0)
        {
            x = x + 1;
            dx = 2 * (ry * ry) * x;
            p1 = p1 + dx + (ry * ry);
        }
        else
        {
            x = x + 1;
            y = y - 1;
            dx = 2 * (ry * ry) * x;
            dy = 2 * (rx * rx) * y;
            p1 = p1 + dx - dy + (ry * ry);
        }
    }
    glFlush();
 
    float p2 = (ry * ry) * (x + 0.5) * (x + 0.5) + (rx * rx) * (y
        - 1) * (y - 1) - (rx * rx) * (ry * ry);
    glColor3ub(rand() % 255, rand() % 255, rand() % 255);
    while (y > 0)
    {
        setPixel(xCenter + x, yCenter + y);
        setPixel(xCenter - x, yCenter + y);
        setPixel(xCenter + x, yCenter - y);
        setPixel(xCenter - x, yCenter - y);
        if (p2 > 0)
        {
            x = x;
            y = y - 1;
            dy = 2 * (rx * rx) * y;
            p2 = p2 - dy + (rx * rx);
        }
        else
        {
            x = x + 1;
            y = y - 1;
            dy = dy - 2 * (rx * rx);
            dx = dx + 2 * (ry * ry);
            p2 = p2 + dx -
                dy + (rx * rx);
        }
    }
    glFlush();
}
void display()
{
    glClear(GL_COLOR_BUFFER_BIT);
    glColor3f(1.0, 0.0, 0.0);
    glPointSize(2.0);
    ellipseMidPoint();
    glFlush();
}


#if GEOMATH21
	void FunkyDebug()
	{
		cout << "Let's Do the Funky Math" << endl;
	}
#endif

#if GEOMATH22
	void MathForFun()
	{
	
	}
#endif

//defining a macro!
#define MULLIFY(a,b) a*b+1


void myMoveFunc(int &&val)
{
    val++;
	std::cout << "val = " << val << std::endl;
}

int main(int argc, char** argv)
{

    ///using static library!
    auto myvalue = AddSMMod(44, 56);


	FunkyDebug();


    Airplane boeing;

    boeing.SetWingSpan(777);

    Airplane airbus(boeing);


    Airplane superEt = airbus;


    auto mahvalu = MULLIFY(4,15);

    cout << " using a macro TEST VALUE IS " << mahvalu << endl;


    
    int i = 3;
    int *j = &i;

    int  &k = i;

	float jj, kk;
    jj = 44;
    kk = 56;

    float &&ii = jj + kk;


    myMoveFunc(44);

    myMoveFunc(jj+kk+ii);
    
    cout << "Entering the Gl initialization" << endl;
	glutInit(&argc, argv);
    glutInitWindowSize(640, 480);
    glutInitWindowPosition(10, 10);
    glutCreateWindow("User_Name");
    myinit();
    glutDisplayFunc(display);
    glutMainLoop();


    //using pointers for objects experiment
    CarClass *ferrari =  new CarClass();
    ferrari->setNumber(777);

   // not permitted due to explicit delete on declaration!  CarClass lambo = CarClass(*ferrari);

   // CarClass bobo = ferrari;

    delete ferrari;


    CarClass *SomeCar = new CarClass();

    delete SomeCar;




	return 0;
}