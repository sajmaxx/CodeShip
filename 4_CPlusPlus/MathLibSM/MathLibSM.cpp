// MathLibSM.cpp : Defines the functions for the static library.
//

#include "pch.h"
#include "framework.h"
#include "MathLibSM.h"
// TODO: This is an example of a library function
void fnMathLibSM()
{
}


void helperfunc(int &&valua)
{
	auto baba = valua;
	auto gogo = baba + 3;
}

int AddSMMod(int a, int b)
{

	int *p;

	int avalue  = 777;

	p = &avalue;

	int &bb = avalue;

	 helperfunc(44);

	return a + b;
}

