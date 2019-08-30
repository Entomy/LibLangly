namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type SpannerExtensions =
    static member Spannr(value:Pattern) = PatternBindings.Spanner(value)
    static member Spannr(value:String) = PatternBindings.Spanner(value)
    static member Spannr(value:Char) = PatternBindings.Spanner(value)