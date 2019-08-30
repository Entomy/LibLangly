namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type ConcatenatorExtensions =
    static member Concat(left:Pattern, right:Pattern) = PatternBindings.Concatenator(left, right)
    static member Concat(left:String, right:Pattern) = PatternBindings.Concatenator(left, right)
    static member Concat(left:Pattern, right:String) = PatternBindings.Concatenator(left, right)
    static member Concat(left:Pattern, right:Char) = PatternBindings.Concatenator(left, right)
    static member Concat(left:Char, right:Pattern) = PatternBindings.Concatenator(left, right)
    static member Concat(left:String, right:String) = PatternBindings.Concatenator(left, right)
    static member Concat(left:String, right:Char) = PatternBindings.Concatenator(left, right)
    static member Concat(left:Char, right:String) = PatternBindings.Concatenator(left, right)
    static member Concat(left:Char, right:Char) = PatternBindings.Concatenator(left, right)
