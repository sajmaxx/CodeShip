#include <iostream>
#include<thread>
#include<chrono>

using namespace std;

class Vehicle
{
    public:
        Vehicle(int vinid) : _vinId(vinid) {}
        void operator ()()
        {
            cout << " Vin Number is " << _vinId << endl;
        }
   protected:
        int _vinId;     
};

class Car : public Vehicle{
    public:
        Car(int vinid, int chasId) : Vehicle(vinid)
        {
            
            _chassisNum  = chasId;
        }

        void operator()()
        {
            
            cout << "Car has these values " << _vinId << " And Chassis Style is " << _chassisNum << endl;
        }

    private:
        int _chassisNum;
};

class Airplane : public Vehicle
{
    public:
        Airplane(int vinid, int wingprofile) : Vehicle(vinid)
        {
            _wingProfileId = wingprofile;
        }

        void operator ()()
        {
            cout << "Aeroplan has these value. Id for Plane is " << _vinId << " Wing Profile ID is " << _wingProfileId << endl;
        }
    private:
        int _wingProfileId;

};


int  main()
{
    thread carThread( (Car(333, 444)) );

    thread planeThread( (Airplane(555,51747))  );

    carThread.join();

    cout << " Main thread working currently " << endl;

    planeThread.join();
    return 0;
}