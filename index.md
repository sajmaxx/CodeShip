# A whirlwind Modern C++ Blog 2022


 This article touches upon several modern C++ concepts, that will enable one to make an application that is capable of using resources efficiently and support asynchronous programming.



## Memory Management through hardware and software:

   There are 2 kinds of  memory as every one knows, the stack and the heap.

The heap memory has  a much larger size availability for developers to allocate objects/types on.  Objects stored on the heap, need to be garbage collected programmatically( even with smart points  I consider this a memory garbage collection via code ... more on this later). The downside to using the heap is the memory access is slow.

The stack memory is quicker to access and write into. The stack memory is order of magnitude smaller in limit of memory available for use. So great care has to be taken care in terms of choosing to use the stack and not maintain data on it for great lengths of time. Types declared on stack have the great advantage of being automatically garbage collected, as they go out of  scope.


## C++ Value types versus Reference Types - true flexibility and control     

In C++ unlike some other languages, you can choose to instantiate either an object or a basic variable type either on a stack or the heap.

This makes it interesting to be able to have those choices for instances of classes or structs, or basic types like int, float, double, char to be instantiated on heap or stack.

## Value Type allocated on the heap
Here is an example:
```
int *winningNum = new int(777);
auto losingnum = *winningNum - 111;
delete winningNum;
```
 
## Reference Type allocated on the heap
```
Car *hybridCar = new Car(122, "Ferrari", 2022);
hybdridCar->ShowData();
delete hybdridCar;
```
[For a detailed treatment on this subject, check out Stack and Heap Article](https://www.learncpp.com/cpp-tutorial/the-stack-and-the-heap/)


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
This is where the rule of 3 comes in. Which basically means if  there is the need for a custom destructor or a copy constructor override, or a copy assignment override then all 3 are needed.
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




-------------------------------------------------------------------------------------
### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/sajmaxx/CodeShip/settings/pages). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
You can use the [editor on GitHub](https://github.com/sajmaxx/CodeShip/edit/gh-pages/index.md) to maintain and preview the content for your website in Markdown files.
