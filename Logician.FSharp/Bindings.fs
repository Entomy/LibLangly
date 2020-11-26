namespace Langly

module internal Bindings =
    let inline Not< ^t, ^a when (^t or ^a) : (static member Not : ^a -> ^a)> value = ((^t or ^a) : (static member Not : ^a -> ^a)(value))

    let inline And< ^t, ^a, ^b, ^c when (^t or ^a) : (static member And : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member And : ^a * ^b -> ^c)(first, second))

    let inline Or< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Or : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Or : ^a * ^b -> ^c)(first, second))

    let inline XOr< ^t, ^a, ^b, ^c when (^t or ^a) : (static member XOr : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member XOr : ^a * ^b -> ^c)(first, second))

    let inline Implies< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Implies : ^a * ^b -> ^c)> this that = ((^t or ^a) : (static member Implies : ^a * ^b -> ^c)(this, that))

    let inline Equivalent< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Equivalent : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Equivalent : ^a * ^b -> ^c)(first, second))

    let inline Contingent< ^t, ^a when (^t or ^a) : (static member Contingent : ^a -> bool)> value = ((^t or ^a) : (static member Contingent : ^a -> bool)(value))

    let inline Necessary< ^t, ^a when (^t or ^a) : (static member Necessary : ^a -> bool)> value = ((^t or ^a) : (static member Necessary : ^a -> bool)(value))

    let inline Possible< ^t, ^a when (^t or ^a) : (static member Possible : ^a -> bool)> value = ((^t or ^a) : (static member Possible : ^a -> bool)(value))
