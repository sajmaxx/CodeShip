# A whirlwind Modern C++ Blog 2022


 This article touches upon several modern C++ concepts, that will enable one to make an application that is capable of using resources efficiently and support asynchronous programming.



## Memory Management through hardware and software:

   There are 2 kinds of  memory as every one knows, the stack and the heap.

The heap memory has  a much larger size availability for developers to allocate objects/types on.  Objects stored on the heap, need to be garbage collected programmatically( even with smart points  I consider this a memory garbage collection via code ... more on this later). The downside to using the heap is the memory access is slow.

The stack memory is quicker to access and write into. The stack memory is order of magnitude smaller in limit of memory available for use. So great care has to be taken care in terms of choosing to use the stack and not maintain data on it for great lengths of time. Types declared on stack have the great advantage of being automatically garbage collected, as they go out of  scope.


## C++ Value types versus Reference Types - true flexibility and control     

In C++ unlike some other languages, you can choose to instantiate either an object or a basic variable type either on a stack or the heap.

This makes it interesting to be able to have those choices for instances of classes or structs, or basic types like int, float, double, char to be instantiated on heap or stack.






### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/sajmaxx/CodeShip/settings/pages). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
You can use the [editor on GitHub](https://github.com/sajmaxx/CodeShip/edit/gh-pages/index.md) to maintain and preview the content for your website in Markdown files.
