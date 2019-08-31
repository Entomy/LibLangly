namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module RepeaterExtensions =
    type Binding =
        static member Repeat(left:Pattern, right:Int32) = PatternBindings.Repeater(left, right)
        static member Repeat(left:String, right:Int32) = PatternBindings.Repeater(left, right)
        static member Repeat(left:Char, right:Int32) = PatternBindings.Repeater(left, right)

    let inline repeat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Repeat : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Repeat : ^a * ^b -> ^c)(left, right))

    /// <summary></summary>
    let inline ( * ) left right = repeat<Binding, _, _, _> left right
