# Sequences & Enumerators

**LibLangly** introduces some improvements to the [`IEnumerable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) and [`IEnumerator<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1) API's. This includes usability, in that the new interfaces implement a little extra for you, and even performance. Of special interest to many is the new bidirectional support, allowing sequences to be traversed in both directions!

## [`IEnumerator<TElement>`](https://entomy.github.io/LibLangly/api/Langly.IEnumerator-1.html)

This trait is a simple helper around standard enumerators. You don't get anything new, but, instead, it implements many of the API's for you using reasonable defaults that you can still override if need be. You can consider this a simple convenience that speeds up your development.

## [`IEnumeratorBidi<TElement>`](https://entomy.github.io/LibLangly/api/Langly.IEnumeratorBidi-1.html)

This trait additionally adds support for bidirectional traversal over supported sequences. Their default behavior is still forward traversal, but they can be reversed.

## [`ISequence<TElement, TEnumerator>`](https://entomy.github.io/LibLangly/api/Langly.ISequence-2.html)

This trait is a specialization of [`IEnumerable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1). It degeneralizes the enumerator potentially allowing enumeration to not require a heap allocation, a minor but easy performance improvement! It requires the count of elements in the sequence to be known, but allows for predefined [`Contains()`](https://entomy.github.io/LibLangly/api/Langly.ISequence-2.html#Langly_ISequence_2_Langly_IContains_TMember__Contains__0_), [`Fold()`](https://entomy.github.io/LibLangly/api/Langly.ISequence-2.html#Langly_ISequence_2_Fold_System_Func__0__0__0___0_), and [`Occurrences()`](https://entomy.github.io/LibLangly/api/Langly.ISequence-2.html#Langly_ISequence_2_Occurrences__0_) methods, as well as use in many cases where a sequence of known length is known. In line with most of **LibLangly**'s traits, this additional functionality is defined for you, using the enumerator you provide, but is still overridable if you need a unique implementation.

## [`ISequenceBidi<TMember, TEnumerator>`](https://entomy.github.io/LibLangly/api/Langly.ISequenceBidi-2.html)

This trait additionally provides the [`Reverse()`](https://entomy.github.io/LibLangly/api/Langly.ISequenceBidi-2.html#Langly_ISequenceBidi_2_Reverse) method allowing for efficient reverse enumeration of a sequence. This is preferentially used over LINQ's [`Reverse()`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.reverse), allowing efficient reverse enumerators to be used when available, and LINQ's fully universal technique otherwise.