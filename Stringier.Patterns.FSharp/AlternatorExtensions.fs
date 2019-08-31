namespace System.Text.Patterns

#nowarn "86" // Shut your pedantic ass up

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module AlternatorExtensions =

    type Binding =
        static member Altern(left:Pattern, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Altern(left:String, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Altern(left:Pattern, right:String) = PatternBindings.Alternator(left, right)
        static member Altern(left:Pattern, right:Char) = PatternBindings.Alternator(left, right)
        static member Altern(left:Char, right:Pattern) = PatternBindings.Alternator(left, right)
        static member Altern(left:String, right:String) = PatternBindings.Alternator(left, right)
        static member Altern(left:String, right:Char) = PatternBindings.Alternator(left, right)
        static member Altern(left:Char, right:String) = PatternBindings.Alternator(left, right)
        static member Altern(left:Char, right:Char) = PatternBindings.Alternator(left, right)

    let inline altern< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Altern : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Altern : ^a * ^b -> ^c)(left, right))

    /// <summary></summary>
    let inline ( || ) left right = altern<Binding, _, _, _> left right
