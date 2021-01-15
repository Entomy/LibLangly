# Base Objects

**Langly** introduces two new based objects designed to help develop more quickly and with consistent behavior. First though, what's the problem?

Everything in standard .NET derives from [`Object`](https://docs.microsoft.com/en-us/dotnet/api/system.object), even the value types with [`ValueType`](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype). This creates some weird situations resulting from everything unifying on one single concept. Value types are basically fine. It'd be nice to have some common stuff defined for them as other languages are capable of, but, I get it. Reference types are where things go haywire. Within reference types there's two ways to handle equality. The first is everything being referential as well. Two object references are equal only if they reference the same object. But it's also possible to have structural equality with reference passing types, the very reason `record` was introduced into C# to assist with. C# records have some issues however, especially in their non-shared base, with everything being synthesized instead. The thing is, none of that behavior needs to be synthesized by the compiler. Nearly all of it can be supplied by a base type. But that's not the only way to provide structural equality with reference types. You can also overload equality on the object, defining your own equality. This has the potential to create bizarre and inconsistent scenarios where a base class may have some types with reference equality and other types with structural equality. Worse yet, some individual types may exhibit both behaviors when compared against different types!

## Object

**Langly**'s [`Object`](https://entomy.github.io/LibLangly/api/Langly.Object.html) forces reference semantics in every possible way, by explicitly defining this behavior and preventing future classes from defining new behavior that deviates from this. Type classes where referentially equality is appropriate should always derive from this type.

When deriving from [`Object`](https://entomy.github.io/LibLangly/api/Langly.Object.html), nothing additional needs to be done. Equality and other operations are already defined as they should be.

## Record

**Langly**'s [`Record<TSelf>`](https://entomy.github.io/LibLangly/api/Langly.Record-1.html) instead establishes contracts about equality in an extensible way. Equality is not defined as a matter of what other types an object might be equal to. It's also not defined through a shared equality contract object that C# `record` uses. Rather, every [`Record<TSelf>`](https://entomy.github.io/LibLangly/api/Langly.Record-1.html) is defined as supporting equality for anything that says it's equal to it. This is a subtle but incredibly important thing: it defines a point of extensibility; a general contract for testing equality.

When deriving from [`Record<TSelf>`](https://entomy.github.io/LibLangly/api/Langly.Record-1.html), a few extra things need to be defined. These have all been made `abstract` even if they weren't already, so an IDE will prompt you to define these and create the stubs for you.
