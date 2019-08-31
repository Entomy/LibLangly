namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module SpannerExtensions =
    type Binding =
        static member Spannr(value:Pattern) = PatternBindings.Spanner(value)
        static member Spannr(value:String) = PatternBindings.Spanner(value)
        static member Spannr(value:Char) = PatternBindings.Spanner(value)

    let inline spannr< ^t, ^a, ^b     when (^t or ^a) : (static member Spannr : ^a -> ^b     )> value      = ((^t or ^a) : (static member Spannr : ^a -> ^b     )(value))

    /// <summary></summary>
    let inline ( ~+ ) value = spannr<Binding, _, _> value