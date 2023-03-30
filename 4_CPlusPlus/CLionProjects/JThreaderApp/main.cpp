#include <iostream>
#include <thread>
#include <cmath>

void workerbeefunc(int ivalue, int realvalue)
{
    //do complex algebra magnitude
    double magnitude = sqrt(ivalue*ivalue + realvalue*realvalue);
    std::cout << "Magnitude is: " << magnitude << std::endl;


}


int main() {
    std::cout << "Hello, World!" << std::endl;

    //use jthread 1
    std::jthread jthread1(workerbeefunc, 1, 2);

    std::this_thread::sleep_for(std::chrono::seconds(1));

    //use jthread 2
    std::jthread jthread2(workerbeefunc, 5, 6);

    std::this_thread::sleep_for(std::chrono::seconds(1));

    return 0;
}
