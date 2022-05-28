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



### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/sajmaxx/CodeShip/settings/pages). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
You can use the [editor on GitHub](https://github.com/sajmaxx/CodeShip/edit/gh-pages/index.md) to maintain and preview the content for your website in Markdown files.
