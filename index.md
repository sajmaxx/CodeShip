# Quick Tour of Modern C++ 


 This article touches upon several modern C++ concepts, that will enable one to make an application that is capable of using resources efficiently and support asynchronous programming. In some sub-topics, I do give a bit of pre-C++11 background, to make a point on how Modern C++ has progressed.
 
### Note: All code snippets included in this article can be compiled in VS 2022 Community Edition. I mostly use only C++ console template for all the samples shown.


## Memory Management through hardware and software:

   There are 2 kinds of  memory when it comes to memory that is consumed in a programming language, the stack and the heap.

The heap memory has  a much larger size availability for developers to allocate objects/types on.  Objects stored on the heap, need to be garbage collected programmatically( even with smart points  I consider this a memory garbage collection via code ... more on this later). The downside to using the heap is the memory access is slow.

The stack memory is quicker to access and write into. The stack memory is order of magnitude smaller in limit of memory available for use. So great care has to be taken care in terms of choosing to use the stack and not maintain data on it for great lengths of time. Types declared on stack have the great advantage of being automatically garbage collected, as they go out of  scope.

[For a detailed treatment on this subject, check out Stack and Heap Article](https://www.learncpp.com/cpp-tutorial/the-stack-and-the-heap/)

## Classic C++ Data Handling

### Raw Pointer Type and Reference Type Usage
Pointers as we know (in modern C++ we call this a "raw pointer") point to an address of a resource.
Pointers can access the type at an address by using the dereferencing syntax.
```
	int *value;
	value = new int(777);
	int justValue = *value;
```
Reference is another way of using pointer technology.
Only caveat is,  the reference type variable ahs to be assigned on declaration. And the variable can only be assigned once.
What is the advantage of using it?
There is a syntactical convenience with using reference type as a parameter being passed in.
```
void changeValueOf(int &affectedValue)
{

   affectedValue = affectedValue*3000 ;
}

int main()
{
	using namespace std;
   //...
   	int changePi = 111;
      changeValueOf(changePi);
      cout << changePi;
}
```

### C++ Value types versus Reference Types - true flexibility and control     

In C++ unlike some other languages, you can choose to instantiate either an object or a basic variable type either on a stack or the heap.

This makes it interesting to be able to have those choices for instances of classes or structs, or basic types like int, float, double, char to be instantiated on heap or stack.


### Value Type allocated on the Stack
Here is an example:
```
{
	int winningVal = 888;
	float array[4] = {4.1, 4.2, 3.3, 4.4};
}
 
```
### Value Type allocated on the Heap
Here is an example:
```
int *winningNum = new int(777);
auto losingnum = *winningNum - 111;
delete winningNum;
```
 
### Reference Type allocated on the Stack
```
{
	Car sportsCar(911, Porsche, 1979);
	sportsCar.ShowData();
}
```
In the above code, since the object is declared via constructor call on the stack, the object is automatically freed, when it goes out of scope.

### Reference Type allocated on the Heap
```
Car *hybridCar = new Car(122, "Ferrari", 2022);
hybdridCar->ShowData();
delete hybdridCar;
```


## Object behavior in C++,  the Rule of 3 and the  Rule of 5 

### Some background:
In this section, I will briefly explain how to understand memory management with classes, especially when they compose resources on the heap.
Main thing to remember is that a class in C++ has a default copy constructor and copy assignment operator.  The critical but understandable principle here is that the copy constructor by default performs a shallow copy and so does the default copy assignment operator.
Follow along this very basic usage  class type UFO that relies in the default copy constructor and default assignment operator.
 
``` 
class UFO
{
    string _name;
    int * _sightHeight;
    int * _zoneIndex;
    
public:
    UFO(int inputheight)
    {
        _name = "ufo";
        _sightHeight = new int(inputheight);
        _zoneIndex = new int(777);
    }

    ~UFO()
    {
        delete _sightHeight;
    }
 
 };    
        
int main()
{
	  UFO *ufOb1 =  new UFO(1000);
 
	  UFO *ufOb2 = new UFO(*ufOb1);  

	  UFO ufOb3 = *ufOb2;

	cout << "Addresses of the 3 object pointers are " << ufOb1 << " "  << ufOb2 << " " << &ufOb3 << endl;

	cout << "Addresses of the pointer datas are " << ufOb1->GetDataAddress() << " " << ufOb2->GetDataAddress() << " " << ufOb3.GetDataAddress() << endl;
	delete ufOb1;
}
 ```
 
 As you can see from the console outputs, both ufoOb2 and ufoOb3 end up possessing a  pointer to the same instance of  heap allocated member data. (In the case of ufoOb3 this happens after the copy assignment operator) 

### Rule of 3:
This is where the rule of 3 comes in. Which basically means if  there is the need for a custom destructor or a copy constructor [for more details](https://www.geeksforgeeks.org/copy-constructor-in-cpp/) override, or a copy assignment override then all 3 are needed
That is to say,  an object of this class type, owns something that is defined on the heap, that needs a deep copy!
 
Here is the above class, amended for the purpose of honoring rule of 3.

```
 class UFO
{
    string _name;
    int * _sightHeight;
    int * _zoneIndex;
    
public:
    UFO(int inputheight)
    {
        _name = "ufo";
        _sightHeight = new int(inputheight);
        _zoneIndex = new int(777);
    }

    ~UFO()
    {
        delete _sightHeight;
    }


    //
    //Copy Consturctor
    UFO(const UFO &incomingUFO)
    {
        _name = incomingUFO._name;
        _sightHeight = new int(0);
        *_sightHeight = *incomingUFO._sightHeight;
        _zoneIndex = new int(0);
        *_zoneIndex  = *incomingUFO._zoneIndex;
    }

    //Copy Assignment Operator
    UFO &operator=(const UFO &incomingUFO)
    {
        if(this == &incomingUFO)
            return *this;

        _name = incomingUFO._name;
        _sightHeight = new int(0);
        *_sightHeight = *incomingUFO._sightHeight;
        _zoneIndex = new int(0);
        *_zoneIndex  = *incomingUFO._zoneIndex;
        return *this;
    }
   
} 
```


### Rule of 5:
 Rule of 5, extends upon rule of 3, requiring two provide a move constructor and a move assignment operator using r value reference parameters (r value reference is a C++ 11 standard and here is an [article on it](http://thbecker.net/articles/rvalue_references/section_01.html).
    The main purpose of enforcing rule of 5 on a class would be, if objects of these type would qualify and be suitable for transferring dyanmically allocated resources within it, from an "outgoing" object to a new/fresh incoming object. That is to say when there is a need to freshen up a new object and destroy an older instance.
```
 class UFO
{
    string _name;
    int * _sightHeight;
    int * _zoneIndex;
    
public:
    UFO(int inputheight)
    {
        _name = "ufo";
        _sightHeight = new int(inputheight);
        _zoneIndex = new int(777);
    }

    ~UFO()
    {
        delete _sightHeight;
    }

    //Copy Consturctor
    UFO(const UFO &incomingUFO)
    {
        _name = incomingUFO._name;
        _sightHeight = new int(0);
        *_sightHeight = *incomingUFO._sightHeight;
        _zoneIndex = new int(0);
        *_zoneIndex  = *incomingUFO._zoneIndex;
    }

    //Copy Assignment Operator
    UFO &operator=(const UFO &incomingUFO)
    {
        if(this == &incomingUFO)
            return *this;

        _name = incomingUFO._name;
        _sightHeight = new int(0);
        *_sightHeight = *incomingUFO._sightHeight;
        _zoneIndex = new int(0);
        *_zoneIndex  = *incomingUFO._zoneIndex;
        return *this;
    }
 
  
    //Move constructor
    UFO(UFO &&incomingUFO)
    {
        _name = incomingUFO._name;
        _sightHeight = incomingUFO._sightHeight;
        incomingUFO._sightHeight = nullptr;
        _zoneIndex = incomingUFO._zoneIndex;
        incomingUFO._zoneIndex = nullptr;
    }
 
 
    //  Move Assignment Operator
    UFO &operator=(UFO &&incomingUFO)
    {
         if (this == &incomingUFO)
        {
            return *this;
        }
        
        _name = incomingUFO._name;

        if (_sightHeight )
        {
             delete _sightHeight;
         }
       _sightHeight = incomingUFO._sightHeight;
        incomingUFO._sightHeight = nullptr;

        if(_zoneIndex)
        {
             delete _zoneIndex;
        }
        _zoneIndex = incomingUFO._zoneIndex;
        incomingUFO._zoneIndex = nullptr;     
        
    }
} 
```

## Smart Pointers
 In modern C++  (since C++ 11), we can use smart pointers.
What are smart pointers?
Smart pointers unlike "raw pointers" can self-manage the resource assigned to it.
There are 3 kinds. They are:

    unique_ptr
    shared_ptr
    weak_ptr

Both unique_ptr and shared_ptr types will own and manage the dynamically allocated resource that it holds on assignment.
The weak_ptr is a dependency pointer that works off the shared_ptr.

### Unique  Pointer
The unique_ptr is the closest form to being used like a classical raw pointer, except that the source gets destroyed once the pointer goes out of scope.
    Example of use of a unique_ptr:
     unique_ptr<int> uniqueId(new int(7));
Imagine we have a class called Airplane.
    Then we can use unique pointer as follows:
     unique_ptr<Airplane> uniqPlane(new Airplane(300, 400, "747"));

### Shared Pointer
  The  shared_ptr as the name suggests, allows for multiple references to the data pointed to by the shared_ptr. A counter is used to increment every time there is a pointing to that data.
This is called reference counting. Once every reference to the memory goes out of scope, the shared_ptr will destroy the resource.
 
### Weak Pointer 
 The weak_ptr as I stated above, works always as a dependent on the shared_ptr. 
As the name would suggest, this pointer assignment to a shared_ptr resource will not increment the reference counting.


	
## Synchronous and Asynchronous

Synchronous programming is what we are most intuitively used to, when it comes to programming.

Within a major block of code, we perform work using functions a, b, c in a serial order, always in the main thread and working through each unit of work in a serial manner.

 Asynchronous programming, provides the ability to perform some work, that can be done independent of some main work done on a main thread, on a worker thread. This can be accomplished by directly controlling the threads, or using the task-threadpool technology of operating systems via the C++ async functionality.

	
	
	
## Threads And Communication between them
 Moving Data from Main Thread to Worker Thread

Here we shall examples of how we can move data for consumption by a worker thread to do work, from a main thread.

With multi-threading in C++, one can send data forward from a main thread to a worker-thread using 2 main ways. One way is to use  lambda functions., the other way is to use variadic template technique.

I will cover both examples soon.
	
### Thread Example for C++11 onwards.
Calling more than 1 thread, by using vector<thread>!
```
#include <vector>
#include <iostream>
#include <thread>

int main(0
{
	auto lamfun = [](double area)
	{
		auto volume = area *100;
	}



	vector<thread> threads;

	for(int i = 0; i < 10, i++)
	{
		threads.push_back(thread(lambda, 100));

	}

	for(int i = 0; i < 10, i++)
	{
		threads[i].join();
	}
	

	cout <<< " Resume Main Work" << endl;

}

```
					    
### Futures and Promises

The future and promise coupling is one way of sending data back from a worker thread to the main thread. This coupling structure, involves a repeated set of boiler plate code, along with an accompanying worker method that has to be aware of a promise via a  move semantic parameter.

Here is the example, which shows the declaration of a promise, hooking the promise.get_future() to a corresponding future. Send promise as a move reference, along with one way input parameters that may be needed.  The future.get(), or future.wait(), or futrure.wait_for() can be used accordingly to get control back to main thread, with a decision to be able to use the future returned data.


promise<string> promiseWorkName;
future<string> futureWorkName = promiseWorkName.get_future();


Then a function is defined to be used by worker thread that uses move semantic referencing for taking in the promise. 

The promise does the job of return results from worker method.

Worker method that will work in a background thread using a promise is as  follows!

```
void doSomeWork(promise<string> && getbackName, string name, int age, int ssn)
{

       do some works here.. .work really really hard...
       and finally
    getbackName.set_value(workedoutName);
}

Now within your main function

void main()
{

   promise<string> promisedLandName;
   future<string> futureLandName = promisedLandName.get_future();

   thread workerLandThread(move(promisedLandName), areaLotName, zipcode, countrycode);

    
   string workedoutLandName = futureLandName.get();     


   workerLandThread.join();

}
```
	
 Then, we start listening on the other end of the communication channel by calling the function get() on the future.
This method will block (further activity on the main thread) until data is available
- which happens as soon as set_value has been called on the promise (from the thread).

 We can also use future.wait().

This is subtle, because you get a pause to be able to know that the future has the result you want

through the promise( example use case: one may want to finish cycling through a for loop and then do an aggregation of all data received).

And then the future can still "Get" the value using future.get() and one could see about using all the future.get(), together within a math expression or a string concatenation or something of that sort.
There are 6 steps to use this promise-future coupling:

    1. Decide and declare the promise with the desired type. promise<int> promisedIndex;
    2. Write the worker method that takes in a promise, using rvalue reference &&.
    3. Declare and assign a future of the same type like this: future<int> futureIndex = promisedIndex.get_future();
    4. Declare and therefore start a thread, that in the worker method, in variadic template form, along with previously instantiated promise.
    5. Where appropriate query the future, using future.get()/wait()/wait_for().
    6. Lastly make sure to call thread.join();

	
	
## Futures and Async

You can also use Promises with Async, instead to make use of tasks and the threadpool,
instead of dealing with threads directly,  you use: std::future and std::async.

With the future and async coupling, there is less boiler plate code, just 3 steps.
We rely on system to decide through async, whether the task will work synchronously or use a parallel thread.
Parallelism is left to the system to decide with this approach.
Developer can take control and override using launch::deferred, launch::async and asyn::default.
One more thing: the method called within async, would be a standard worker method with inputs and an output that doesn't need awareness of thread or task or async or promise structures.
Also since there is no  direct interaction with thread, there is no join needed to do an extra check to make sure thread is closed.
 With the Async Future setup we have 3 steps:

    1. Define worker method with return type needed and inputs needed
    2. Assign the future to the async call as shown below:
    3. future<type> = async(workermethod); or using async() with a lambda method within it.
    4. Call future.get(); 

### An Example:
```
    // AsyncJets.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include<thread>
#include<future>
#include<memory>
#include<string>

using namespace std;

struct JetEngine
{
    string Company;
    int modelNumber;
    int numberofNozzle;
    JetEngine()
    {
        
    }
    JetEngine(string comp, int model, int numberNozz) : Company(comp), modelNumber(model), numberofNozzle(numberNozz) { }

};

//Operation #1: Worker method to be used by async
JetEngine MaketheSingleNozzleEngine(int compCode, int model)
{
    this_thread::sleep_for(chrono::milliseconds(3000));
    switch(compCode)
    {
        case 1:
            return JetEngine("GE Engine", model, 1);
        case 2:
            return JetEngine("Pratt", model, 1);
        default:
            return JetEngine("Merlin", model, 1);

    }
}

int main()
{
    //Operation #2: Setting the future to the async
    int companycode = 1;
    int model = rand();
    future<JetEngine> jetengineFuture1 = async(launch::async, MaketheSingleNozzleEngine, companycode, model);

    companycode = 2;
    model = rand();
    future<JetEngine> jetengineFuture2 = async(launch::async, MaketheSingleNozzleEngine, companycode, model);

    companycode = 3;
    model = rand();
    future<JetEngine> jetengineFuture3= async(launch::async, MaketheSingleNozzleEngine, companycode, model);

    try
    {
        //Operation #3: Use the future.get
        auto newJet3 = jetengineFuture3.get();
        cout << newJet3.Company << endl;

        auto newJet2 = jetengineFuture2.get();
        cout << newJet2.Company << endl;

        auto newJet1 = jetengineFuture1.get();
        cout << newJet1.Company << endl;

    }
    catch(exception ee)
    {
        cout << "excepton is " << ee.what() << endl;
    }

}
```


	
## Mutexes and Locks

This is a way to ensure sustained two way communication  between two threads.The concept consists of using a construct in C++ called a Mutex that has responsibility to lock and unlock a data resources that is shared between multiple threads.

The header to include is:  #include<mutex>

The type to use is Mutex.

Mutex has two functions, which are Mutex.Lock() and Mutex.UnLock().

Here is an example of how it is used, in it's simplest form.

 I have also included an example of using timed_mutex within this code snippet:

```
#include <iostream>
#include <mutex>
#include <thread>
#include <vector>
#include<future>

using namespace std;

class Airplane
{
public:
    Airplane(int flightno) : _flightNo(flightno) {}
    int flightNumber ()
    {
        return _flightNo;
    }
private:
    int _flightNo;
};


// simplification to only account for landing Airplanes.
// showcases use of mutex lock and unlock to make sure there is no data race condition
class AirportManagement
{
public:
    AirportManagement(){}

    void ShowLandedCount()
    {
        majorAirMutex.lock();
        cout << " Major AirLine Planes landed count is " <<  _majorAirPlanes.size() << endl;
        majorAirMutex.unlock();

        if(minorAirMutex.try_lock_for(chrono::milliseconds(100)))
        {
            cout << " Minor Craft landed count is " << _smallCraftPlanes.size() << endl;
            minorAirMutex.unlock();
        }
        
    }

    // This shows using a regular mutex lock and unlock, which ensures a strict lock and unock only after operation is completed
    void MajorPlaneLandedAndTaken(Airplane &&majPlane)
    {
        majorAirMutex.lock();
        _majorAirPlanes.emplace_back(move(majPlane));
        majorAirMutex.unlock();
    }

 // this hows using a timed_mutex to "emulate" a lower priority to gather every object for operation
    void MinorPlaneLandedAndTaken(Airplane &&smallPlane)
    {
        if(minorAirMutex.try_lock_for(chrono::milliseconds(222)))
        {
            this_thread::sleep_for(chrono::milliseconds(smallPlane.flightNumber()*100 + rand()));
            _smallCraftPlanes.emplace_back(move(smallPlane));
            minorAirMutex.unlock();
        }
    }

private:
    vector<Airplane> _majorAirPlanes;
    vector<Airplane> _smallCraftPlanes;
    mutex majorAirMutex;
    timed_mutex minorAirMutex;
};

int main()
{
    shared_ptr<AirportManagement> airport(new AirportManagement());

    vector<future<void>> futureMajorPlanes;

    for(int i =0; i < 77; i++)
    {
        Airplane majPlane(i);
        futureMajorPlanes.emplace_back(async(launch::async, &AirportManagement::MajorPlaneLandedAndTaken, airport, move(majPlane)));
    }

    vector<future<void>> futureSmallPlane;
    for(int i = 0; i < 100; i++)
    {
        Airplane smallPlane(i);
        futureSmallPlane.emplace_back(async(launch::async, &AirportManagement::MinorPlaneLandedAndTaken, airport, smallPlane));
    }

    for_each(futureSmallPlane.begin(), futureSmallPlane.end(), [](future<void> &ft){ ft.wait();});


    for_each(futureMajorPlanes.begin(), futureMajorPlanes.end(), [](future<void> &ft){ ft.wait();});

    

    airport->ShowLandedCount();


}
```

## Lightweight Implementation of Producer and Consumer Threads without Polling - using a condition_variable

Modern C++ offers a type called condition_variable, that works to let multiple threads wait and respond based on conditions met.
The Condition Variable is the communication channel between a thread that signals work has been done, and can have 1 or more other threads waiting for that signal, so they can resume work after that signal was recieved.
In other words, the standard library provides condition_variable, as a primitive that enables 1 thread to signal to 1 or more other threads, that a particular condition has occured.
The type condition_variable, has 3 methods.
1. condition_variable.wait()
	a. this method blocks further operation, till a notify/notify_all is invoked elsewhere (in another thread).
2. condition_variable.notify_one() - this notifies only a single waiting thread.
3. condition_variable.notify_all() - this notifies and wakes up multiple threads.
4. The condition_variable, works with a mutex, the unique_lock (used within the .wait()) and the lock_guard.
  * Given the above definition and with this context in mind, the producer would do a lock_guard on a mutex, and do some work.
  * Once that work is done, the producer will call the condition_variable.notify().
  * The consumer is setup with a unique_lock on a mutex and  will be a in a wait state and blocked. 
  * During the wait invoked through the condition_variable, the mutex is actually "unlocked".
  * When the other thread, using the same condition_variable.notify_one()  is invoked, the "wait" springs back to action, resuming the lock to do work.
5. In the context of using condition variable, with a unique_lock and a lock_guard, there is something to be said about those 2  types.
  * The lock_guard/unique_lock is a RAII treatment of mutex locks and unloccks, similar to smart pointers doing automatic resource management.
	

### Example Console App, that showcases the use of a management of a message que using condition_variable, mutex, lock_guard and unique_lock
```
// MessageQueSimplify.cpp : This file contains the 'main' function. Program execution begins and ends there.

#include <iostream>
#include<deque>
#include<mutex>

using namespace std;


class  MessageMgr
{

public:
    MessageMgr()
    {
	    _alldoneWithAdding = false;
        _counter = 0;
        _addingCounter = 0;
    }

    void AllMessagesAdded()
    {
        int i;
        for(i = 0; i < 500; i++)
        {
	       lock_guard<mutex> lockGrd(_locmutex);
            dataQue.push_back(i);
            _counter++;
            _addingCounter++;
            _conditionVaria.notify_one();  //this will wake up the waiting block
            cout << "Added Message " << i << endl;
        }

        if (_addingCounter >= 499)
        {
			_alldoneWithAdding = true;
        }
	    
    }

    void GetEachNextMessageAndDoWork()
    {
        do
        {
            unique_lock<mutex> ulockforWait(_locmutex);
            _conditionVaria.wait(ulockforWait,[this]()
            {
	           return (!dataQue.empty() ); 
            });

            int readNextDataIn = dataQue.front();
            cout << "   Message Processed is # " << readNextDataIn << endl; 
            dataQue.pop_front();
        	_counter--;
            cout << "       Counter is at "<< _counter << " And dequelength is at " <<  this->getDequeLength() << endl;
	        if ( ( _alldoneWithAdding)  && (_counter == 0)) 
                break;
        }while(true);
	     
    }

    int getDequeLength()
    {
	    return dataQue.size();
    }

private:
    deque<int> dataQue;
    mutex _locmutex;
    condition_variable _conditionVaria;
    bool _alldoneWithAdding;
    int _counter, _addingCounter;

};

int main()
{
    MessageMgr mahMessageQueManager;

    thread populateThread(&MessageMgr::AllMessagesAdded, &mahMessageQueManager);
    thread doActionThread(&MessageMgr::GetEachNextMessageAndDoWork, &mahMessageQueManager);

    populateThread.join();
    doActionThread.join();
    
    cout << "Done all responses to messages triggered! And deque count is  " << mahMessageQueManager.getDequeLength()  << endl;
    return 0;
    
}

```

## Interesting Features in C++ 20 (at least interesting to me :-))
	1. Using Modules
	2. Spaceship Operator <=>
	3. jthread


### Since C++ 20, we have the jthread, that eliminates the need for the join, following RAII principles, in that the threads automatically rejoin with main thread, on destruction.
					    
```
#include <vector>
#include <iostream>
#include <thread>

int main(0
{
	auto lamfun = [](double area)
	{
		auto volume = area *100;
	}



	vector<jthread> jthreads;

	for(int i = 0; i < 10, i++)
	{
		jthreads.push_back(jthread(lambda, 100));

	}

	cout <<< " Resume Main Work" << endl;

}					    
```


