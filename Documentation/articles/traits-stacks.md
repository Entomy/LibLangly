# Stacks

Contrary to colloquial use of the term, Stacks are _not_ a data structure, but rather, an abstract data type. **LibLangly** does provide a specialized data structure for use exclusively as a stack, but stack functionality can easily be provided by other data structures through a set of stack traits; the same traits the predefined structure implements.

## [`IPush<TElement, TResult>`](https://entomy.github.io/LibLangly/api/Langly.IPush-2.html)

This trait indicates that your type supports pushing elements onto it. When you implement [`Push(TElement)`](https://entomy.github.io/LibLangly/api/Langly.IPush-2.html#Langly_IPush_2_Push__0_) you'll automatically get overloads that support [`params TElement[]`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params), [`Memory<TElement>`](https://docs.microsoft.com/en-us/dotnet/api/system.memory-1), [`ReadOnlyMemory<TElement>`](https://docs.microsoft.com/en-us/dotnet/api/system.readonlymemory-1), [`Span<TElement>`](https://docs.microsoft.com/en-us/dotnet/api/system.span-1), [`ReadOnlySpan<TElement>`](https://docs.microsoft.com/en-us/dotnet/api/system.readonlyspan-1), and [`ISequence<TElement, TEnumerator`>](). All for free! If you need specific behavior, you're free to provide implementations of any of the overloads that will be used instead.

## [`IPop<TElement, TResult>`](https://entomy.github.io/LibLangly/api/Langly.IPop-2.html)

This trait indicates that your type supports popping elements off it. When you implement [`Pop(out TElement)`](https://entomy.github.io/LibLangly/api/Langly.IPop-2.html#Langly_IPop_2_Pop__0__) you'll automatically get overloads that support [`Pop(out TElement[])`]() and [`Pop(out Memory<TElement>)`]()

## [`IPeek<TElement, TResult>`](https://entomy.github.io/LibLangly/api/Langly.IPeek-2.html)

This trait indicates that your type supports peeking at the first element. This isn't required, but is highly recommended, for stack behavior. There's no special extra stuff. Rather, it's just very useful for people using your finished type.