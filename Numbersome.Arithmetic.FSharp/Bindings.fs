namespace Numbersome

module internal Bindings =
    let inline Product< ^t, ^a, ^b when (^t or ^a) : (static member Product : ^a -> ^b)> values = ((^t or ^a) : (static member Product : ^a -> ^b)(values))

    let inline Sum< ^t, ^a, ^b when (^t or ^a) : (static member Sum : ^a -> ^b)> values = ((^t or ^a) : (static member Sum : ^a -> ^b)(values))
