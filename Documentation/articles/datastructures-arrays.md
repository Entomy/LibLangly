# Arrays

Arrays are the most basic of all data structures. This being said, **LibLangly provides several options, all with very sophisticated API's. In all cases, an Array is a contiguous collection of elements, and only varies in how work is done.

## [`Array<TElement>`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Array-1.html)

This is the most primative implementation of an Array. It is read only as a form of optimization, and only one-dimensional as a matter of semantics. It should be considered analogous to [`ReadOnlyMemory<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.readonlymemory-1). While it supports operations that would modify its elements, it does so by _always_ creating a new array, which means an allocation always occurs. These operations are not recommended in the majority of cases, and are only provided for orthogonality. Furthermore, as a simplification, this is implemented as a value type (`struct`), so `null` doesn't need to be considered. Most cases where arrays would be used are best served through this type.

## [`FlexibleArray<TElement, TSelf>`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Arrays.FlexibleArray-2.html)

Building upon the **Consolator** ancestry, **LibLangly** also provides variations of resizable, or _flexible_, arrays. These arrays are mutable, with behavior dictated by the implemention. All of these flexible arrays inherit from this base class.

### [`BoundedArray<TElement>`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Arrays.BoundedArray-1.html)

Bounded arrays have a maximum capacity and are allowed to freely resize within that upper limit. While not useful in most cases, this should allow better interfacing with relational databases and other applications where arrays exhibit this behavior.

### [`DynamicArray<TElement>`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Arrays.DynamicArray-1.html)

Dynamic arrays have no static capacity limit. Instead, at any given time there is a capacity, and if this is exceeded, the underlying allocation is resized. This is the most primative of all dynamic data structures, but is able to serve a large number of use cases. The performance is generally exceptionally good, but be wary that resizing operations are very expensive, as a new allocation has to occur, and all existing elements copied over. Furthermore, the garbage collector will eventually need to clean up the older allocation. If resizing is not a common operation, or you can reliably predict a good capacity, this serves as a very performant data structure.