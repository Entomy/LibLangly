# Views

One way in which **LibLangly** deviates substantially from most other collections libraries is in the concept of a *View*. A *View* sits on top of a data structure instance, and provides an interface for interacting with it in a more limited or different way. While this sounds superfluous or less capable than the actual data structure, these limitations actual provide their benefits.

## `IndexView` & `ElementView`

Any associative data structure is fundamentally a collection of associations or key-value pairs. **LibLangly** calls these indicies and elements. Because of their associated nature, data structures work with both together as a pair, which is often what you want. But consider the case where you're using one as a sparse array, and you want to enumerate over the values. A normal enumerator return each index and element _together_. By accessing the respective views, you get an interface for working with just that part of the pair. Exactly what is provided by these views depends on the data structure being viewed.

## `ReverseView`

.NET never considered the situation where a sequence could be enumerated in reverse until .NET Framework 3.5 and .NET Core 1.0. When they finally addressed this, it was through [`Reverse()`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.reverse) which certainly works is a nice general way, but is extremely limited in its sequence-only form. **LibLangly** instead provides an entire system for working with the reverse of any data structure that supports this view.