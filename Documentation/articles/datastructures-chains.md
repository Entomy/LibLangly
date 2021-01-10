# Chains

Chains play a critical role in **LibLangly**. When faced with how to handle more complicated work, there's two major approaches.

1. Mutate an existing object in place

2. Create a copy of the existing object with the changes made.

The first option provides better performance but means consistency isn't maintained and state potentially needs to be tracked. While there's techniques to deal with this, it's often considered a code smell in modern programming.

The second option provides greater consistency but cripples performance, especially through increased memory pressure. Functional programming languages, where this is the norm, employ techniques to address this which are successful in the smaller scale but fail in the large scale.

But there's another way, inspired by the work of [Boehm, Atkinson, and Plass](https://citeseer.ist.psu.edu/viewdoc/download?doi=10.1.1.14.9450&rep=rep1&type=pdf), [Nelson, et al](http://www.eastgate.com/catalog/LiteraryMachines.html), [Papadakis](https://cs.uwaterloo.ca/research/tr/1993/28/root2side.pdf), [Pugh](https://dl.acm.org/doi/10.1145/78973.78977), and [Shao, Reppy, and Appel](https://dl.acm.org/doi/10.1145/182409.182453): transformations of a particular data structure.

A Chain is a hybrid list, a combination of a skip-list and partially-unrolled list which itself internally uses reference slicing for efficiency. It is meant to address two complaints with the Rope. First is that the Rope was designed specifically with text in mind, whereas Chains are generalized data structures. Second is that Ropes are (supposed to be) implemented as special binary trees whos leaves form the text. Oftentimes, "Ropes" are implemented as doubly-linked lists, which is even worse. Not only are trees harder to program, but skip-lists actually provide faster operations when data is ordered. Text is always ordered, and anything that would normally use a simple sequence or linked-list is also ordered, so therefore skip-lists should be preferred. This is integrated with partial-unrolling both as further optimization of traversal, but also allowing for nodes to reference slice existing texts. All of this leads to remarkable optimizations for working with complex data.

As it turns out, operations like inserts and replaces, especially with irregular sized data, is remarkably easier to implement through transforming chains. Data primatives can stay immutable while still being manipulated through efficient means. As a result, when you use **LibLangly** you will overwhelmingly wind up working with Chains.