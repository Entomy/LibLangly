namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module RangerExtensions =
    type Binding =
        static member Range(left:Pattern, right:Pattern) = PatternBindings.Ranger(left, right)
        static member Range(left:Pattern, right:String) = PatternBindings.Ranger(left, right)
        static member Range(left:String, right:Pattern) = PatternBindings.Ranger(left, right)
        static member Range(left:Pattern, right:Char) = PatternBindings.Ranger(left, right)
        static member Range(left:Char, right:Pattern) = PatternBindings.Ranger(left, right)
        static member Range(left:String, right:String) = PatternBindings.Ranger(left, right)
        static member Range(left:String, right:Char) = PatternBindings.Ranger(left, right)
        static member Range(left:Char, right:String) = PatternBindings.Ranger(left, right)
        static member Range(left:Char, right:Char) = PatternBindings.Ranger(left, right)

        static member ERange(left:Pattern, right:Pattern, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:Pattern, right:String, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:String, right:Pattern, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:Pattern, right:Char, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:Char, right:Pattern, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:String, right:String, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:String, right:Char, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:Char, right:String, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member ERange(left:Char, right:Char, escape:Pattern) = PatternBindings.Ranger(left, right, escape)

        static member NRange(left:Pattern, right:Pattern) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:Pattern, right:String) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:String, right:Pattern) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:Pattern, right:Char) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:Char, right:Pattern) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:String, right:String) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:String, right:Char) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:Char, right:String) = PatternBindings.Ranger(left, right, true)
        static member NRange(left:Char, right:Char) = PatternBindings.Ranger(left, right, true)
    
    let inline range< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Range : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Range : ^a * ^b -> ^c)(left, right))
    let inline erange< ^t, ^a, ^b, ^c when (^t or ^a) : (static member ERange : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member ERange : ^a * ^b -> ^c)(left, right))
    let inline nrange< ^t, ^a, ^b, ^c when (^t or ^a) : (static member NRange : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member NRange : ^a * ^b -> ^c)(left, right))