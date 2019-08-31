namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module ConcatenatorExtensions =

    type Binding =
        static member Concat(left:Pattern, right:Pattern) = PatternBindings.Concatenator(left, right)
        static member Concat(left:String, right:Pattern) = PatternBindings.Concatenator(left, right)
        static member Concat(left:Pattern, right:String) = PatternBindings.Concatenator(left, right)
        static member Concat(left:Pattern, right:Char) = PatternBindings.Concatenator(left, right)
        static member Concat(left:Char, right:Pattern) = PatternBindings.Concatenator(left, right)
        static member Concat(left:String, right:String) = PatternBindings.Concatenator(left, right)
        static member Concat(left:String, right:Char) = PatternBindings.Concatenator(left, right)
        static member Concat(left:Char, right:String) = PatternBindings.Concatenator(left, right)
        static member Concat(left:Char, right:Char) = PatternBindings.Concatenator(left, right)

    let inline concat< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Concat : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Concat : ^a * ^b -> ^c)(left, right))

    /// <summary></summary>
    let inline ( >> ) left right = concat<Binding, _, _, _> left right

