#include <iostream>
#include <future>
#include <thread>
#include <chrono>


std::mutex global_mutex;

void produce_value(std::promise<int> &p)
{

    {
        std::this_thread::sleep_for(std::chrono::seconds(2));
    }


    // get a random number from 1 through 10

    try
    {
        int random_value = rand() % 10 + 1;
        if(random_value <= 2)
        {

            throw std::runtime_error("Random param value is less than 2");
        }
        else
        {
            p.set_value(42);
        }
    }
    catch(...)
    {
        p.set_exception(std::current_exception());
    }



    // set a brief pause to keep debug simple on the future "getting value" from promise.
    {
        using namespace std::chrono_literals;
        std::this_thread::sleep_for(10ms);
    }
    std::cout << "Promise producer function  has done all it's work!!! <<<<<<<<<" << std::endl;
}


void consume_value(std::future<int> &fut)
{
    std::lock_guard<std::mutex> lock(global_mutex);
    try
    {
        std::cout << " FUTURE Waiting for value..." << std::endl;
        std::cout << " FUTURE GOT THE Value from promise-contract and it is : " << fut.get() << std::endl;
    }
    catch(std::exception const &e)
    {
         std::cout << " whaaat exception whaat? " << e.what() << std::endl;
    }

}

int main() {
    std::cout << "PROMISE AND FUTURE EXAMPLE FEBRUARY023" << std::endl;
    std::promise<int> stock_price_promise;
    std::thread stockThread(produce_value, std::ref(stock_price_promise));
    std::future<int> stock_price_future = stock_price_promise.get_future();

    std::thread futuredThread(consume_value, std::ref(stock_price_future));

    stockThread.join();
    futuredThread.join();
    return 0;
}
