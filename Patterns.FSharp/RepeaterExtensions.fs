namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module RepeaterExtensions =

    type Binder =
        static member Repeat(pattern:Pattern, count:Int32) = PatternBindings.Repeater(pattern, count)
        static member Repeat(pattern:String, count:Int32) = PatternBindings.Repeater(pattern, count)
        static member Repeat(pattern:Char, count:Int32) = PatternBindings.Repeater(pattern, count)
        static member Repeat(pattern:Capture, count:Int32) = PatternBindings.Repeater(pattern, count)
        // These makes the operator still do multiplication
        // Unfortunantly type resolution doesn't work, so there's a lot of overloads
        static member Repeat(left:uint8, right:uint8) = left * right
        static member Repeat(left:uint16, right:uint16) = left * right
        static member Repeat(left:uint32, right:uint32) = left * right
        static member Repeat(left:uint64, right:uint64) = left * right
        static member Repeat(left:int8, right:int8) = left * right
        static member Repeat(left:int16, right:int16) = left * right
        static member Repeat(left:int32, right:int32) = left * right
        static member Repeat(left:int64, right:int64) = left * right
        static member Repeat(left:single, right:single) = left * right
        static member Repeat(left:double, right:double) = left * right
        static member Repeat(left:decimal, right:decimal) = left * right

    let inline private repeat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Repeat : ^a * ^b -> ^c)> pattern count = ((^t or ^a) : (static member Repeat : ^a * ^b -> ^c)(pattern, count))

    let inline ( * ) left right = repeat<Binder, _, _, _> left right