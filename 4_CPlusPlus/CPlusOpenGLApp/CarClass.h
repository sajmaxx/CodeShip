#include<stdlib.h>
#include<iostream>
#include<malloc.h>
#pragma once


//EXAMPLE OF ALLOCATING AND FREEING MEMORY using malloc and free 
class CarClass
{
	private:
		int *_vinNo;

	public:
		CarClass()
		{
			_vinNo =  (int *)malloc(sizeof(int));
		}

		~CarClass()
		{
			free(_vinNo);
		}

		void setNumber(int numba)
		{
			*_vinNo = numba;
		}

};

