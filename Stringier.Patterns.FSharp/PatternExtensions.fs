namespace System.Text.Patterns

open System

[<AutoOpen>]
module PatternExtensions =
    type Binding =
        static member Consum(pattern:Pattern, source:String) = pattern.Consume(source)
        static member Consum(pattern:Pattern, source:byref<Source>) = pattern.Consume(&source)

    let inline consum< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Consum : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Consum : ^a * ^b -> ^c)(left, right))
