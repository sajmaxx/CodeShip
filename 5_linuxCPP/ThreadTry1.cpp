#include<iostream>
#include<thread>
#include<vector>

using namespace std;

void threadWorkSM()
{
    this_thread::sleep_for(chrono::milliseconds(50));

     cout <<  "Finished Work in 2nd Thread" << endl;
}


int main()
{    

    unsigned int numberofThreads = thread::hardware_concurrency();

    cout << " This Computer has " << numberofThreads << " concurrent threads available " << endl;

    vector<int> lablids;

    lablids.push_back(33);
    lablids.push_back(44);
    lablids.push_back(77);

    //using inser with iterator into a vector!

    lablids.insert(begin(lablids)+2, 55);

    for(int i =0; i < lablids.size(); i++)
    {
        cout << lablids[i] << endl;
    }

    thread smTh(threadWorkSM);


    this_thread::sleep_for(chrono::milliseconds(100));

    cout << "Did some work in Main Thread " << endl;


    smTh.join();

    return 0;

}