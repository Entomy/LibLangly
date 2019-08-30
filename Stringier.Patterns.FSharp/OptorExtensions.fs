namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type OptorExtensions =
    static member Option(value:Pattern) = PatternBindings.Optor(value)
    static member Option(value:String) = PatternBindings.Optor(value)
    static member Option(value:Char) = PatternBindings.Optor(value)