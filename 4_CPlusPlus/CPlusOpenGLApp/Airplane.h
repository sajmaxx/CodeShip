#pragma once


#include <iostream>


class Airplane
{

private:
	int* _wingSpan;

public:

	Airplane()
	{
		_wingSpan = (int*)malloc(sizeof(int));
		std::cout << " wing span resource allocated" << std::endl;
	}



	~Airplane()
	{
		if (_wingSpan != nullptr)
		{
			free(_wingSpan);
		}
	}




	Airplane(Airplane& SourcePlane)
	{
		_wingSpan = SourcePlane._wingSpan;

		SourcePlane._wingSpan = nullptr;
	}


	Airplane& operator=(Airplane& SourcePlane)
	{
		_wingSpan = SourcePlane._wingSpan;
		SourcePlane._wingSpan = nullptr;
		return *this;
	}

	int WingSpan ()
	{
		return *_wingSpan;
	}

	void SetWingSpan(int value)
	{
		*_wingSpan = value;
	}


};
