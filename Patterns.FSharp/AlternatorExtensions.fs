namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

#nowarn "86" // Shuts up about overloading ||. We are overloading it not overriding it, so it's fine.

[<AutoOpen>]
module AlternatorExtensions =

    type Binding =
        static member Alternate(left:Pattern, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Alternate(left:String, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Alternate(left:Pattern, right:String) = PatternBindings.Alternator(left, right)
        static member Alternate(left:Pattern, right:Char) = PatternBindings.Alternator(left, right)
        static member Alternate(left:Char, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Alternate(left:String, right:String) = PatternBindings.Alternator(left, right)
        static member Alternate(left:String, right:Char) = PatternBindings.Alternator(left, right)
        static member Alternate(left:Char, right:String) = PatternBindings.Alternator(left, right)
        static member Alternate(left:Char, right:Char) = PatternBindings.Alternator(left, right)
        // This makes the operator still do boolean or
        static member Alternate(left, right) = left || right

    let inline private alternate< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Alternate : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Alternate : ^a * ^b -> ^c)(left, right))

    let inline ( || ) left right = alternate<Binding, _, _, _> left right