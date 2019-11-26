namespace Stringier.Patterns

open System

[<AutoOpen>]
module ConcatenatorExtensions =

    type Binding =
        static member Concatenate(left:Pattern, right:Pattern) = left.Then(right)
        static member Concatenate(left:String, right:Pattern) = left.Then(right)
        static member Concatenate(left:Pattern, right:String) = left.Then(right)
        static member Concatenate(left:Char, right:Pattern) = left.Then(right)
        static member Concatenate(left:Pattern, right:Char) = left.Then(right)
        static member Concatenate(left:String, right:String) = left.Then(right)
        static member Concatenate(left:String, right:Char) = left.Then(right)
        static member Concatenate(left:Char, right:String) = left.Then(right)
        static member Concatenate(left:Char, right:Char) = left.Then(right)
        static member Concatenate(left:Pattern, right:Capture ref) = left.Then(!right)
        static member Concatenate(left:Capture ref, right:Pattern) = (!left).Then(right)
        static member Concatenate(left:String, right:Capture ref) = left.Then(!right)
        static member Concatenate(left:Capture ref, right:String) = (!left).Then(right)
        static member Concatenate(left:Char, right:Capture ref) = left.Then(!right)
        static member Concatenate(left:Capture ref, right:Char) = (!left).Then(right)
        // This makes >> still do foreward composition
        static member Concatenate(left, right) = left >> right

    let inline private concatenate< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Concatenate : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Concatenate : ^a * ^b -> ^c)(left, right))

    let inline ( >> ) left right = concatenate<Binding, _, _, _> left right
