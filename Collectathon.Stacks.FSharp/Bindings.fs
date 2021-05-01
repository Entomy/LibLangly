namespace Collectathon.Stacks

open Collectathon.Stacks

module internal Bindings =
    let inline Abs< ^t, ^a when (^t or ^a) : (static member Abs : Stack< ^a> -> Stack< ^a>)> stack = ((^t or ^a) : (static member Abs : Stack< ^a> -> Stack< ^a>)(stack))

    let inline Add< ^t, ^a when (^t or ^a) : (static member Add : Stack< ^a> -> Stack< ^a>)> stack = ((^t or ^a) : (static member Add : Stack< ^a> -> Stack< ^a>)(stack))

    let inline Cbrt< ^t, ^a when (^t or ^a) : (static member Cbrt : Stack < ^a> -> Stack< ^a>)> stack = ((^t or ^a) : (static member Cbrt : Stack< ^a> -> Stack< ^a>)(stack))
