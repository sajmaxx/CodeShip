#include<iostream>
#include<glad/glad.h>
#include<GLFW/glfw3.h>

using namespace std;

//resume at 17 minutes
//  https://www.youtube.com/watch?v=45MIykWJ-C4


int main()
{

	glfwInit();

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	
	GLFWwindow *mainGLWindow = glfwCreateWindow(700, 700, "Main Shader Wins", NULL, NULL);

	 if(mainGLWindow == NULL)
	 {
		cout << " Failed to Create GLFW Window" << endl;
		return -1;
		 
	 }

	glfwMakeContextCurrent(mainGLWindow);

	gladLoadGL();

	glViewport(0,0, 700, 700);

	glClearColor(0.17f, 0.03f, 0.17f, 1.0f);  //r g b alpha

	glClear(GL_COLOR_BUFFER_BIT);

	glfwSwapBuffers(mainGLWindow);

	while(!glfwWindowShouldClose(mainGLWindow))
	{
		glfwPollEvents();
	}


	glfwDestroyWindow(mainGLWindow);
	glfwTerminate();
	return 0;

	
}