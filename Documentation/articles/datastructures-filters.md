# Filters

**LibLangly** strives for a high degree of code sharing. This is especially important given how well tuned data structures are to both the internals, and many use cases. As such, the [`Filter<TIndex, TElement>`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Filters.Filter-2.html) was developed.

Filters change the operations of the data structure they are a part of. Exactly what this is depends on the filters that are used. It is important to remember that filters do not change the structure itself, only the operations that effect that structure. A simplified [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection) model was created to simplify using these. Any supporting data structure _should_ have overloads on its constructors with a [`Filter`](https://entomy.github.io/LibLangly/api/Langly.DataStructures.Filter.html) parameter. This is a flags enum which allows composing together multiple filter designations. The work is done entirely for you.

## Sparse Filter

Sparse filters enable a data structure to operate like a sparse array. Indexing operations will no longer throw [`IndexOutOfBoundsException`](https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception), and will instead always return the default for the element type.