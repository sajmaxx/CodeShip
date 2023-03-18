#include <iostream>
#include <vector>
#include <future>
#include "DecodeLib/Decoder.h"



//add a unit test for Decoder class
//add a unit test for main class

int main()
{
    std::cout << "Async and Futures Experiment: Reuse Same Async multiple times" << std::endl;

    std::unique_ptr<Decoder>  decoderObj{new Decoder()};

    std::future<vector3d> vectorFuture = std::async(std::launch::async, [&decoderObj]()
    {return decoderObj->decode(1, 2, 3);
    });

    //wait for future to be ready
    vector3d vector = vectorFuture.get();
    vector.print();

    // reassign a new async to the same future
    vectorFuture = std::async(std::launch::async, [&decoderObj]()
    {return decoderObj->decode(4, 5, 6);
    });
    //wait for future to be ready
    vector3d vector2 = vectorFuture.get();
    vector2.print();


    // adding asyncs to same future 5 more times within a loop
    for(int i = 0; i < 5; i++)
    {
        vectorFuture = std::async(std::launch::async, [&decoderObj, i]()
        {return decoderObj->decode(i+7, i+8, i+9);
        });
        //wait for future to be ready
        vector3d vector3 = vectorFuture.get();
        vector3.print();
        using namespace  std::chrono_literals;
        std::this_thread::sleep_for(1s);
    }

    using namespace  std::chrono_literals;
    std::this_thread::sleep_for(3s);
    std::cout << "Number ofvectors collected is " << decoderObj->count();

    return 0;
}