namespace Langly

module internal Bindings =
    let inline Add< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Add : ^a * ^b -> ^c)> collection elements = ((^t or ^a) : (static member Add : ^a * ^b -> ^c)(collection, elements))

    let inline Clear< ^t, ^a, ^b when (^t or ^a) : (static member Clear : ^a -> ^b)> collection = ((^t or ^a) : (static member Clear : ^a -> ^b)(collection))

    let inline Contains< ^t, ^a, ^b when (^t or ^a) : (static member Contains : ^a * ^b -> bool)> collection element = ((^t or ^a) : (static member Contains : ^a * ^b -> bool)(collection, element))

    let inline ContainsAny< ^t, ^a, ^b when (^t or ^a) : (static member ContainsAny : ^a * ^b -> bool)> collection elements = ((^t or ^a) : (static member ContainsAny : ^a * ^b -> bool)(collection, elements))

    let inline ContainsAll< ^t, ^a, ^b when (^t or ^a) : (static member ContainsAll : ^a * ^b -> bool)> collection elements = ((^t or ^a) : (static member ContainsAll : ^a * ^b -> bool)(collection, elements))

    let inline Fold< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)> collection func identity = ((^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)(collection, func, identity))

    let inline Grow< ^t, ^a, ^b when (^t or ^a) : (static member Grow : ^a -> ^b)> collection = ((^t or ^a) : (static member Grow : ^a -> ^b)(collection))

    let inline IndexOfFirst< ^t, ^a, ^b when (^t or ^a) : (static member IndexOfFirst : ^a * ^b -> nativeint)> collection elements = ((^t or ^a) : (static member IndexOfFirst : ^a * ^b -> nativeint)(collection, elements))

    let inline IndexOfLast< ^t, ^a, ^b when (^t or ^a) : (static member IndexOfLast : ^a * ^b -> nativeint)> collection elements = ((^t or ^a) : (static member IndexOfLast : ^a * ^b -> nativeint)(collection, elements))

    let inline Insert< ^t, ^a, ^b, ^c, ^d when (^t or ^a) : (static member Insert : ^a * ^b * ^c -> ^d)> collection index elements = ((^t or ^a) : (static member Insert : ^a * ^b * ^c -> ^d)(collection, index, elements))

    let inline Occurrences< ^t, ^a, ^b when (^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)> collection element = ((^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)(collection, element))

    let inline Replace< ^t, ^a, ^b, ^c, ^d when (^t or ^a) : (static member Replace : ^a * ^b * ^c -> ^d)> collection search replace = ((^t or ^a) : (static member Replace : ^a * ^b * ^c -> ^d)(collection, search, replace))

    let inline Resize< ^t, ^a, ^b when (^t or ^a) : (static member Resize : ^a * nativeint -> ^b)> collection capacity = ((^t or ^a) : (static member Resize : ^a * nativeint -> ^b)(collection, capacity))

    let inline Seek< ^t, ^a, ^b when (^t or ^a) : (static member Seek : ^a * nativeint -> ^b)> collection offset = ((^t or ^a) : (static member Seek : ^a * nativeint -> ^b)(collection, offset))

    let inline Shrink< ^t, ^a, ^b when (^t or ^a) : (static member Shrink : ^a -> ^b)> collection = ((^t or ^a) : (static member Shrink : ^a -> ^b)(collection))

    let inline Write< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Write : ^a * ^b -> ^c)> collection elements = ((^t or ^a) : (static member Write : ^a * ^b -> ^c)(collection, elements))
