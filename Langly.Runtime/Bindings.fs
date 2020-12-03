namespace Langly

module internal Bindings =
    let inline Add< ^t, ^a, ^b when (^t or ^a) : (static member Add : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Add : ^a * ^b -> unit)(collection, elements))

    let inline Clear< ^t, ^a when (^t or ^a) : (static member Clear : ^a -> unit)> collection = ((^t or ^a) : (static member Clear : ^a -> unit)(collection))

    let inline Clone< ^t, ^a when (^t or ^a) : (static member Clone : ^a -> ^a)> collection = ((^t or ^a) : (static member Clone : ^a -> ^a)(collection))

    let inline Conjunction< ^t, ^o, ^a, ^b, ^c when (^t or ^o or ^a) : (static member And : ^a * ^b -> ^c)> first second = ((^t or ^o or ^a) : (static member And : ^a * ^b -> ^c)(first, second))

    let inline Contains< ^t, ^a, ^b when (^t or ^a) : (static member Contains : ^a * ^b -> bool)> collection element = ((^t or ^a) : (static member Contains : ^a * ^b -> bool)(collection, element))

    let inline Contingent< ^t, ^a when (^t or ^a) : (static member Contingent : ^a -> bool)> value = ((^t or ^a) : (static member Contingent : ^a -> bool)(value))

    let inline Dequeue< ^t, ^a, ^b when (^t or ^a) : (static member Dequeue : ^a -> ^b)> collection = ((^t or ^a) : (static member Dequeue : ^a -> ^b)(collection))

    let inline Difference< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Subtract : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Subtract : ^a * ^b -> ^c)(first, second))

    let inline Divide< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Divide : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Divide : ^a * ^b -> ^c)(first, second))

    let inline Enqueue< ^t, ^a, ^b when (^t or ^a) : (static member Enqueue : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Enqueue : ^a * ^b -> unit)(collection, elements))

    let inline Equivalent< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Equivalent : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Equivalent : ^a * ^b -> ^c)(first, second))

    let inline Exclusion< ^t, ^o, ^a, ^b, ^c when (^t or ^o or ^a) : (static member XOr : ^a * ^b -> ^c)> first second = ((^t or ^o or ^a) : (static member XOr : ^a * ^b -> ^c)(first, second))

    let inline Fold< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)> collection func identity = ((^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)(collection, func, identity))

    let inline Grow< ^t, ^a when (^t or ^a) : (static member Grow : ^a -> unit)> collection = ((^t or ^a) : (static member Grow : ^a -> unit)(collection))

    let inline Implies< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Implies : ^a * ^b -> ^c)> this that = ((^t or ^a) : (static member Implies : ^a * ^b -> ^c)(this, that))

    let inline Inclusion< ^t, ^o, ^a, ^b, ^c when (^t or ^o or ^a) : (static member Or : ^a * ^b -> ^c)> first second = ((^t or ^o or ^a) : (static member Or : ^a * ^b -> ^c)(first, second))

    let inline Insert< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Insert : ^a * ^b * ^c -> unit)> collection index element = ((^t or ^a) : (static member Insert : ^a * ^b * ^c -> unit)(collection, index, element))

    let inline Map< ^t, ^a, ^b when (^t or ^a) : (static member Map : ^a * ^b -> unit)> collection func = ((^t or ^a) : (static member Map : ^a * ^b -> unit)(collection, func))

    let inline Multiply< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Multiply : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Multiply : ^a * ^b -> ^c)(first, second))

    let inline Necessary< ^t, ^a when (^t or ^a) : (static member Necessary : ^a -> bool)> value = ((^t or ^a) : (static member Necessary : ^a -> bool)(value))

    let inline Not< ^t, ^o, ^a when (^t or ^o or ^a) : (static member Not : ^a -> ^a)> value = ((^t or ^o or ^a) : (static member Not : ^a -> ^a)(value))

    let inline Occurrences< ^t, ^a, ^b when (^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)> collection elements = ((^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)(collection, elements))

    let inline Pop< ^t, ^a, ^b when (^t or ^a) : (static member Pop : ^a -> ^b)> collection = ((^t or ^a) : (static member Pop : ^a -> ^b)(collection))

    let inline Possible< ^t, ^a when (^t or ^a) : (static member Possible : ^a -> bool)> value = ((^t or ^a) : (static member Possible : ^a -> bool)(value))

    let inline Push< ^t, ^a, ^b when (^t or ^a) : (static member Push : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Push : ^a * ^b -> unit)(collection, elements))

    let inline Read< ^t, ^a, ^b when (^t or ^a) : (static member Read : ^a -> ^b)> collection = ((^t or ^a) : (static member Read : ^a -> ^b)(collection))

    let inline Remove< ^t, ^a, ^b when (^t or ^a) : (static member Remove : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Remove : ^a * ^b -> unit)(collection, elements))

    let inline Resize< ^t, ^a when (^t or ^a) : (static member Resize : ^a * nativeint -> unit)> collection capacity = ((^t or ^a) : (static member Resize : ^a * nativeint -> unit)(collection, capacity))

    let inline Shrink< ^t, ^a when (^t or ^a) : (static member Shrink : ^a -> unit)> collection = ((^t or ^a) : (static member Shrink : ^a -> unit)(collection))

    let inline Sum< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Add : ^a * ^b -> ^c)> first second = ((^t or ^a) : (static member Add : ^a * ^b -> ^c)(first, second))

    let inline TryRead< ^t, ^a, ^b, ^c when (^t or ^a) : (static member TryRead : ^a -> bool * ^b * ^c)> collection = ((^t or ^a) : (static member TryRead : ^a -> bool * ^b * ^c)(collection))

    let inline TryWrite< ^t, ^a, ^b, ^c when (^t or ^a) : (static member TryWrite : ^a * ^b -> bool * ^c)> collection element = ((^t or ^a) : (static member TryWrite : ^a * ^b -> bool * ^c)(collection, element))

    let inline Write< ^t, ^a, ^b when (^t or ^a) : (static member Write : ^a * ^b -> unit)> collection element = ((^t or ^a) : (static member Write : ^a * ^b -> unit)(collection, element))
