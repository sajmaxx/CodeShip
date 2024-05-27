// singletonMeyers.cpp
#include <chrono>
#include <iostream>
#include <future>

constexpr auto tenMill = 10000000;

class MySingleton
{
public:
    static MySingleton& getInstance()
    {
        static MySingleton instance;
        volatile int dummy{};
        return instance;
    }
private:
    MySingleton()= default;
    ~MySingleton()= default;
    MySingleton(const MySingleton&)= delete;
    MySingleton& operator = (const MySingleton&)= delete;
};

std::chrono::duration<double> getTime()
{
    auto begin= std::chrono::system_clock::now();
    for (size_t i = 0; i < tenMill; ++i) {
        MySingleton::getInstance();
    }
    return std::chrono::system_clock::now() - begin;
};




class MySingletonAtomic {
public:
    static MySingletonAtomic* getInstance() {
        MySingletonAtomic* sin= instance.load(std::memory_order_acquire);
        if ( !sin ) {
            std::lock_guard<std::mutex> myLock(myMutex);
            sin = instance.load(std::memory_order_relaxed);
            if( !sin ){
                sin = new MySingletonAtomic();
                instance.store(sin,std::memory_order_release);
            }
        }
        volatile int dummy{};
        return sin;
    }
private:
    MySingletonAtomic()= default;
    ~MySingletonAtomic()= default;
    MySingletonAtomic(const MySingletonAtomic&)= delete;
    MySingletonAtomic& operator = (const MySingletonAtomic&)= delete;
    static std::atomic<MySingletonAtomic*> instance;
    static std::mutex myMutex;
};


std::atomic<MySingletonAtomic*> MySingletonAtomic::instance;
std::mutex MySingletonAtomic::myMutex;


std::chrono::duration<double> getTimeAtomic()
{
    auto begin= std::chrono::system_clock::now();
    for (size_t i = 0; i < tenMill; ++i) {
        MySingletonAtomic::getInstance();
    }
    return std::chrono::system_clock::now() - begin;
};


std::chrono::duration<double> getTime1Thread()
{
    auto begin= std::chrono::system_clock::now();
    for (size_t i = 0; i < 4*tenMill; ++i) {
        MySingleton::getInstance();
    }
    return std::chrono::system_clock::now() - begin;
};

int main()
{
    auto fut1 = std::async(std::launch::async,getTime);
    auto fut2 = std::async(std::launch::async,getTime);
    auto fut3 = std::async(std::launch::async,getTime);
    auto fut4 = std::async(std::launch::async,getTime);
    auto total = fut1.get() + fut2.get() +
                 fut3.get() + fut4.get();
    std::cout << total.count() << '\n';




    auto fut1a = std::async(std::launch::async,getTimeAtomic);
    auto fut2a = std::async(std::launch::async,getTimeAtomic);
    auto fut3a = std::async(std::launch::async,getTimeAtomic);
    auto fut4a = std::async(std::launch::async,getTimeAtomic);
    auto totala = fut1a.get() + fut2a.get() +
                 fut3a.get() + fut4a.get();
    std::cout << totala.count() << '\n';


    auto timepass = getTime1Thread();
    std::cout << " the single thread solution " << timepass.count() << std::endl;



}

/*
 *
     • std::vector is 30 times faster than std::list or std::forward_list.
    •• std::vector is 5 times faster than std::deque.
    •• std::deque is 6 times faster than std::list and std::forward_list.
    •• std::list and std::forward_list are in the same ballpark.
  *
 */