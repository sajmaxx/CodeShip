#include <SFML/Graphics.hpp>


using namespace  sf;

//This is where the game starts from
int main()
{
	VideoMode vm(1920,1080);


	RenderWindow window(vm, "Timbah!!!!", Style::Default);


	while (window.isOpen())
	{

		if (Keyboard::isKeyPressed(Keyboard::Escape))
		{
			window.close();
		}


		window.clear();

		window.display();
	}
	
	
	return 0;
}