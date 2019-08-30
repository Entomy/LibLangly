namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type AlternatorExtensions =
    static member Altern(left:Pattern, right:Pattern) = PatternBindings.Alternator(left, right)
    static member Altern(left:String, right:Pattern) = PatternBindings.Alternator(left, right)
    static member Altern(left:Pattern, right:String) = PatternBindings.Alternator(left, right)
    static member Altern(left:Pattern, right:Char) = PatternBindings.Alternator(left, right)
    static member Altern(left:Char, right:Pattern) = PatternBindings.Alternator(left, right)
    static member Altern(left:String, right:String) = PatternBindings.Alternator(left, right)
    static member Altern(left:String, right:Char) = PatternBindings.Alternator(left, right)
    static member Altern(left:Char, right:String) = PatternBindings.Alternator(left, right)
    static member Altern(left:Char, right:Char) = PatternBindings.Alternator(left, right)
