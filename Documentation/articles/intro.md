# Introduction

## What is LibLangly?

Simply put, **LibLangly** is a collection of libraries meant to make text processing, parsing, and manipulation a far better experience than existing tooling out there.

Because of the developmental history of this project, the organization and naming is a bit unique. Rather than a whole history dump, however, that history will be given when explaining why things were done.

## The Parts

**LibLangly** is extremely modular as far as libraries typically go. This helps with keeping the size down if you use any of its components. This has become especially important as Microsoft thinks it's a good idea to bring back static linking. Furthermore, it improves build times, making contributors time better spent, and even helps with API design, since contributors are required to use the same public API as downstream.

### Stringier

**Stringier** is where this whole thing got started. I was working on a suite of Ada tooling that's now deprecated, and was frustrated with the need to keep writing out common text functions. I knew I wasn't the only one, so I spawned a little side project to help. Originally it was just some simple extensions but it grew into one of the largest and most sophisticated text processing libraries there is. It seemed like this was the perfect place to implement a novel text parser design as well, and when this performed absurdly well it became clear the project, and its name, were here to stay.

### Collectathon

**Collectathon** was one of the next things to show up. **Stringier** had a growing need for unique data structures and I was growing disatisfied with existing solutions out there. What I needed wasn't just solid data structures; I needed a way to rapidly create new data structures without duplicating large amounts of code. **Collectathon** was, first and foremost, a data structure framework. _Was_, because now it's just the proper collections. The framework part split off into **Philosoft** when I realized it was useful to more than just collections, if some additions were made. Things were clear again: a side project meant to support another has, itself, turned into a key project.

One of the key design principals of **Collectathon** has always been that the types should be data structures, not abstract data types. Say you need a stack. Anything that provides stack traits can act as a stack. This could mean an array or a linked list. You chose the performanxe characteristics _you_ need, and the design lets you easily switch data structures as those needs change.

Also provided are some extension libraries to support some of these abstract data types. If you're working with stacks, for example, there's a set of extensions you can include that enhance data structures with stack traits for certain types. A major example is stacks of numeric types will have additional operations for stack math. Queues of delegates also have support for dequeuing and invoking as one simple operation. They're simple conveniences, but it makes your overall experience more enjoyable.

### Numbersome

**Numbersome** was next, and mostly served as a way to relax while doing the frustrating work if data structure design. It provides common, simple, and often overlooked math operations and some auxillary types to help out. I deprecated this for over a year, but after **Philosoft** became a thing, it was reworked to support it. It's not particularly useful as a serious math library, but will support more basic and common scenarios. It mostly serves to extend collections made with **Philosoft**'s Trait and Concepts API, when those collections are of numeric types. 

### Philosoft

**Philosoft** was split off at this point from some techniques that were used to help with developing **Collectathon** when I got some feedback about certain techniques being useful for developing non-collections. Originally it was a set of general interfaces, similar in nature to those in .NET's standard library. In time these interfaces would change and split into two varients, the Traits API and the Concepts API, inspired by the similarly named ideas from C++, within the limitations of C#.

The Traits API is a set of extremely granular and minimal interfaces that indicate support for a single property or method, and possibly overloads of that method. While nothing is stopping you from defining these yourself, using the Traits API ensures a consistent design is communicated throughout large projects, and enables generalization of functions across a wide variety of types. Furthermore, documentation for this functionality can be inherited from the interfaces, meaning docs can be kept consistent and meaningful, with as little effort as possible.

The Concepts API links multiple traits together in common patterns, more similar to the .NET collection interfaces, although it includes more, and isn't exclusive to collections. It also greatly modernizes these. Typically, these are a convenience to type designers, and should not be used as parameters to functions. Although there are exceptions. Using these when appropriate will ensure all relevant traits are supported. Do note that not all traits are wrapped up into concepts, especially as concepts are kept rather minimal, so you will likely need to include some additional traits when defining complex types like data structures.

Both of these are additionally used to define a rich set of extensions that further enhance the developer experience. In their most basic form this is convenience methods, like if your type supports `Add(TElement)` you'll get additional extensions for adding entire arrays, spans, enumerables, and more; but only one element at a time. Many traits support additional derivations for these as well, so if your type can have entire groups of elements added in one operation, consider adding these traits and providing optimized operations. These APIs are designed to support this, and callers will prefer the optimized operations instead of the convenience ones. These extensions aren't limited to just generalized implementations though, as many of them are entirely new operations that you never need to implement. They _just work_! No Todd Howarding going on here. In some cases more optimal LINQ methods will be provided that are compatible with LINQ standards. In this case, the specializations will be chosen and you won't need to change a thing.

As things progressed further, I recognized there was more need for basic developer conveniences. This is when **Philosoft** became a key library rather than just a simple offshoot. The purpose was generalized into: provide features that support developers managing complex software solutions. Now, it wasn't _just_ traits and concepts. **Philosoft** is also home to numerous attributes, both backports for older runtimes, and entirely new ones. This enables annotating almost anything you would need to, like nullability for better fault tolerance, or asymptotic complexity to help downstream make informed decisions about the performance curves of operations.

### Streamy

**Streamy** is something I never wanted to happen, but my hand was forced. When developing **Stringier**'s patterns framework and parsing engine, it was originally designed to parse in memory buffers, by far the most common situation. I realized later that the approach could easily be adapted to parse most streams, as long as some basic conditions were met. This would greatly improve performance when parsing large files on disk, and because of how streams are abstract, would open the door to possibilities like parsing a text stream sent over the network. Trying to use .NET's Stream failed miserably, and as I investigated why, I uncovered numerous questionable or poorly thought out design decisions, and even security vulnerabilities the OWASP now recognizes and has practicies to protect against. It became clear: the stream needed an entire modern redesign.

**Streamy** tried to provide a similar experience to existing and familiar Stream APIs, but will not sacrifice security or usability, and so its experience is not entirely the same. Nevertheless, it should be easy to learn, and fully intends to provide the best possible Stream API of any implementation out there, across languages.

### Langly

Finally, all of these builds up to support **Langly**. For clarity, I need to differentiate the two ways this name is used. **Langly** is a domain specific language, tightly integrated into .NET, used to efficiently define language grammars, and parsers for them, as well as provide an optimal text manipulation and processing environment. You could condsider it the modern successor to SNOBOL or UNICON. **LibLangly**, which will just be refered to as **Langly** here, is the runtime library used to support the language, and additionally to define the language grammar itself. **Langly** is a slice of the various components that it needs, in addition to the new libraries it provides for things like the parse tree. The design of **Langly** itself will be saved for another article, but what you need to know here is that everything in this project supports **Langly** at its time or origin, but has grown more general since then. As such, you can consider the overall **LibLangly** project a collection of libraries with relevancy to **Langly** but are freely usable, and actively used, by others. Collecting them all in one place, monorepo style, makes managing everything far easier.