# Traits & Concepts

**Philosoft** provides, among other things, both a Traits API and a Concepts API. This article will explain both of those, with sections for developer using these APIs for their own types, advice for implementing types efficiently, and developers writing functions whos parameters use these APIs.

## Defining Types

Typically speaking, you'll want to use concepts for defining types, because they'll include all the relevant traits you'd expect on such a typeclass. That being said, sometimes there's no concept for your typeclass (like for Set) or sometimes there's additional traits your type has. I recommend starting with the relevant concepts, and adding whatever traits you additionally need. Because concepts are groupings of traits, you'll have all of the same benefits, with less effort on your part.

Some traits have variants with `ReadOnly` as part of their name. This says that the operation is not mutating, that it will only get a value. The mutating forms include the `ReadOnly` variant, so your type can be used as either.

Some traits have variants with `Ref` as part of their name. This says that the operation uses `ref` to pass a reference to an element, rather than the value of the element. Prefer using this, especially for generic data structures. You want to avoid this, and use the "standard" form only if the cost of passing around a reference is greater than the value, which is rare, but happens for things like buffers of bytes.

Some traits have variants with `Memory` or `Span` as part of their name. These include their predecessors functionality, while declaring additional support for contiguous memory of the same type. `Memory` variants support `Array`, `ArraySegment`, `Memory`, and `ReadOnlyMemory`. `Span` variants include these, and add support for `Span` and `ReadOnlySpan`. Only use these derived traits if your type can do something with the entire contiguous memory at once, like a block copy or linking it as one single node. If your type can only support one element at a time, these same overloads are provided as convenience methods and do not need to be manually implemented.

Some traits have variants with `Pointer` as part of their name. These include their predecessors functionality, while declaring additional support for fat/safe pointers of the same type. This is limited to `unmanaged` elements. The additional overload uses both a raw pointer and the length of the memory pointed to. Support for only the raw pointer will never be included. This is only intended for interop scenarios, so if you know your type will only ever communicate with a managed environment, don't bother with this. Only use this derived trait if your type xan do something with the entire region of memory at once, like a block copy or linking it as one single node. If your type can only support one element at a time these same overloads are provided as convenience methods and do not need to be manually implemented.

## Implementing Types

All of that is great, but leaves you needing to implement dozens of methods yourself. Right? Nope. Traits come to the rescue here as well. There's two approaches you can take, and in both cases a lot of functionality is provided for you in `Collection`. You only need to make a few "connections".

### Linked Node Backed

Node linking is a popular technique for implementing dynamically sized structures, since it allows elements to be added very efficiently. Because a data structure can vary so much, so much the nodes, making it hard to generalize operations across structures. Well not with traits! `Collection` provides highly general functions called polytypic functions which just require the nodes of your data structure implement a few key traits. It varies, but at that point you usually just pass the function your head node and whatever method parameters were passed, and it does its thing for you. Not only does this mean you can often implement complex functionality as one liners, but it also means this functionality has already been extensively tested! Consider the `Contains` provider. All it expects is that your node has the `Next` property and a `Contains` method. Now it doesn't matter if you're implementing a simple singly-linked list, a complex skip-list, a chunk partially-unrolled list, or even something else entitely: you have a correct implementation you can just tell your type to use.

### Array Backed

`Collection` provides overloads for `Array`, `ArraySegment`, `Memory`, `ReadOnlyMemory`, `Span`, `ReadOnlySpan`, and fat/safe pointers. Use whatever is appropriate. From experience and benchmarks, I recommend `Array` for common scenarios and fat/safe pointers for interop structures. `Memory` and `ReadOnlyMemory` have unexpected performance overhead and should generally be avoided, but are still supported.

While linked node backed types are capable of handling both standard and associative variants with little consideration, array backed types require more guidance. If you're not using the implementation providers in `Collection`, ignore this and do whatever you want.

#### Standard

Standard array backed types are straight forward and work as expected. Define a field with the backing array, and pass it, and the length of actual elements in use, to the provider. If you are always using the entire backing array, pass the provider the backing array's length. This is done to support variably sized arrays, a common strategy.

#### Associative

Associative array backed types have two possible approaches. The first is to use a single array of tuples or some other simple structure that associates the index and element; do _not_ do this. `Collection` has many providers that are still appropriate for associative collections but will only work with standard arrays. Instead, use parallel arrays, where both are the same capacity, one holds the indicies, and one holds the elements. `Collection` providers for associative collections work with parallel arrays, and will require both be passed. `Collection` providers that work on standard arrays and will still work for associative arrays can be passed only the indicies or elements array as appropriate. This further improves code reuse.

## Writing Trait Extensions

### Generalizing

Often, it is possible to provide functionality using a single implementation that works across many types. Consider anything indexable, read and write. It is possible to apply a map function across all the elements of the structure, and the way this is done is the same regardless of the underlying data structure. By generalizing extensions to accept only the necessary traits, they can be generalized, sharing a single implementation across many different types; a huge advantage.

### Specializing

Alternatively, we may not always want to overly generalize an extension. Consider a data structure that can be used as a stack. Any stack supports the basic operations like push and pop. But what about if that is a stack of integers? Now you could pop off two values, do some math, and push the result back onto the stack. By specializing the extensions, you can provide additional functionality to structures of specific types; a big advantage. Similarly, these specializations might be based on multiple traits being present at the same time, like with a queue. Nothing is stopping a type from implementing either `Queue` or `Dequeue`, but when both are implemented another possibility opens up: `Requeue`. Specializations look to add additional features to a type based on the features it already has, whether the type it contains, or traits it already has.

### Limitations

The approach described here completely falls apart if you apply it to the caller ot an extension method. That is, the `this` parameter must be a concrete type rather than composed traits. If you do this your function will technically work, but depending on your editor, Intellisense will either never show your extension, or will show it on every single completion ever. Neither of these are good experiences.

As a workaround for this, the Concepts API was created, which has other benefits. Only rely on this as your function parameters as a last resort. Ask around for advice before doing this, because it may be possible still to avoid it. The issue with using concepts too freely is it will prevent your extension from showing up for types that it would otherwise be able to. 