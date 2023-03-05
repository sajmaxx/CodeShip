#include <iostream>

//functions discussed in this recipe are:: exit(), quick_exit(), atexit() and at_quick_exit().

void onExitDothis()
{
    std::cout << "onExitDothis() called" << std::endl;
}

int main() {
    std::cout << "Hello, World!" << std::endl;

//atexit() registers a function to be called at normal program termination.
    atexit(onExitDothis);
    return 0;
}
