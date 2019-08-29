namespace System.Text.Patterns

[<AutoOpen>]
module Functions =
    let inline altern< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Altern : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Altern : ^a * ^b -> ^c)(left, right))
    let inline concat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Concat : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Concat : ^a * ^b -> ^c)(left, right))
    let inline negate< ^t, ^a, ^b     when (^t or ^a) : (static member Negate : ^a -> ^b     )> value      = ((^t or ^a) : (static member Negate : ^a -> ^b     )(value))
    let inline option< ^t, ^a, ^b     when (^t or ^a) : (static member Option : ^a -> ^b     )> value      = ((^t or ^a) : (static member Option : ^a -> ^b     )(value))
    let inline repeat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Repeat : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Repeat : ^a * ^b -> ^c)(left, right))
    let inline spannr< ^t, ^a, ^b     when (^t or ^a) : (static member Spannr : ^a -> ^b     )> value      = ((^t or ^a) : (static member Spannr : ^a -> ^b     )(value))
    