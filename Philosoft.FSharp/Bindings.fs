namespace Philosoft

module internal Bindings =
    let inline Add< ^t, ^a, ^b when (^t or ^a) : (static member Add : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Add : ^a * ^b -> unit)(collection, elements))

    let inline Clear< ^t, ^a when (^t or ^a) : (static member Clear : ^a -> unit)> collection = ((^t or ^a) : (static member Clear : ^a -> unit)(collection))

    let inline Clone< ^t, ^a, ^b when (^t or ^a) : (static member Clone : ^a -> ^b)> collection = ((^t or ^a) : (static member Clone : ^a -> ^b)(collection))

    let inline Contains< ^t, ^a, ^b when (^t or ^a) : (static member Contains : ^a * ^b -> bool)> collection elements = ((^t or ^a) : (static member Contains : ^a * ^b -> bool)(collection, elements))

    let inline Dequeue< ^t, ^a, ^b when (^t or ^a) : (static member Dequeue : ^a -> ^b)> collection = ((^t or ^a) : (static member Dequeue : ^a -> ^b)(collection))

    let inline Enqueue< ^t, ^a, ^b when (^t or ^a) : (static member Enqueue : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Enqueue : ^a * ^b -> unit)(collection, elements))

    let inline Fold< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)> collection func identity = ((^t or ^a) : (static member Fold : ^a * ^b * ^c -> ^c)(collection, func, identity))

    let inline Map< ^t, ^a, ^b when (^t or ^a) : (static member Map : ^a * ^b -> unit)> collection func = ((^t or ^a) : (static member Map : ^a * ^b -> unit)(collection, func))

    let inline Occurrences< ^t, ^a, ^b when (^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)> collection elements = ((^t or ^a) : (static member Occurrences : ^a * ^b -> nativeint)(collection, elements))

    let inline Pop< ^t, ^a, ^b when (^t or ^a) : (static member Pop : ^a -> ^b)> collection = ((^t or ^a) : (static member Pop : ^a -> ^b)(collection))

    let inline Push< ^t, ^a, ^b when (^t or ^a) : (static member Push : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Push : ^a * ^b -> unit)(collection, elements))

    let inline Remove< ^t, ^a, ^b when (^t or ^a) : (static member Remove : ^a * ^b -> unit)> collection elements = ((^t or ^a) : (static member Remove : ^a * ^b -> unit)(collection, elements))
