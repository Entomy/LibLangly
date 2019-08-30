namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type NegatorExtensions =
    static member Negate(value:Pattern) = PatternBindings.Negator(value)
    static member Negate(value:String) = PatternBindings.Negator(value)
    static member Negate(value:Char) = PatternBindings.Negator(value)