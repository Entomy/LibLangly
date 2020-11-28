# Guards

Guard clauses are a design pattern accomodating for a languages lack of contracts. You've written plenty of these, often in the form of `if (condition) throw exception`. A guard clause library provides prewritten, efficient, functions that do these checks with less typing. Rather than manually writing out guard clauses, these are prepackaged checks + exceptions than you can write in one line.

# [C#](#tab/cs)

~~~~csharp
void Example(Object obj) {
    Guard.NotNull(obj, nameof(obj));
    // Your code
}
~~~~


# [VB](#tab/vb)

~~~~vbnet
Sub Example(obj As Object)
    Guard.NotNull(obj, NameOf(obj))
    'Your code
End Sub
~~~~

# [F#](#tab/fs)

~~~~fsharp
let example (obj) =
    Guard.NotNull(obj)
    // Your code
~~~~

***

That's it. All guards clauses are static methods within the [`Guard`](https://entomy.github.io/LibLangly/api/Langly.Guard.html) class. That means all of them are super easy to discover. Furthermore, while things like fluent syntax is great, it carries a cost. Guard clauses should perform as fast as possible. Being just standard methods (that are always inlined), they operate exactly as fast as hand written ones. And lastly, because these are premade functions, you don't need to remember whether bounds checks are most efficiently done as `lower <= value && value <= upper`, `(value - lower) * (upper - value) >= 0`, or `(value - lower) <= (upper - lower)`; you get exactly what is ideal for the types you passed.

> [!Note]
> **LibLangy** doesn't use many guards internally, instead opting for a fault-tollerant design wherever possible. We find, generally speaking, fault-tolerance is useful for libraries, fail-fast is useful for services, and exceptions/guards are useful for applications.