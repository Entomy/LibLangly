namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module RepeaterExtensions =
    type Binding =
        static member Repeat(value:Pattern, count:Int32) = PatternBindings.Repeater(value, count)
        static member Repeat(value:String, count:Int32) = PatternBindings.Repeater(value, count)
        static member Repeat(value:Char, count:Int32) = PatternBindings.Repeater(value, count)

    let inline repeat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Repeat : ^a * ^b -> ^c)> value count = ((^t or ^a) : (static member Repeat : ^a * ^b -> ^c)(value, count))

    /// <summary>
    /// Marks the <paramref name="value"/> as repeating <paramref name="count"/> times
    /// </summary>
    let inline ( * ) value count = repeat<Binding, _, _, _> value count
