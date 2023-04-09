#include <iostream>
#include <thread>
#include <chrono>
#include <stop_token>

void do_workwithStopCheck(std::stop_token stopToken)
{
    while(!stopToken.stop_requested())
    {
        std::this_thread::sleep_for(std::chrono::seconds(1));
        std::cout << "Working..." << std::endl;
    }
}


int main()
{
    std::cout << "Hello, World!" << std::endl;

    std::stop_source stopSource;
    std::stop_token mahStopToken = stopSource.get_token();

    std::thread workerThread(do_workwithStopCheck, mahStopToken);

    std::this_thread::sleep_for(std::chrono::seconds(3));

    stopSource.request_stop();
    std::cout << "Stop requested" << std::endl;


    workerThread.join();
    std::cout << "Worker thread joined" << std::endl;


    return 0;
}
