#include<iostream>
#include<thread>

using namespace std;

void threadWorkSM()
{
    this_thread::sleep_for(chrono::milliseconds(50));

     cout <<  "Finished Work in 2nd Thread" << endl;
}


int main()
{    
    thread smTh(threadWorkSM);


    this_thread::sleep_for(chrono::milliseconds(100));

    cout << "Did some work in Main Thread " << endl;


    smTh.join();

    return 0;

}