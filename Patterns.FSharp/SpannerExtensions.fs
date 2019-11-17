namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module SpannerExtensions =

    type Binder =
        static member Spanning(pattern:Pattern) = PatternBindings.Spanner(pattern)
        static member Spanning(pattern:String) = PatternBindings.Spanner(PatternBindings.Literal(pattern))
        static member Spanning(pattern:Char) = PatternBindings.Spanner(PatternBindings.Literal(pattern))
        static member Spanning(pattern:Capture) = PatternBindings.Spanner(PatternBindings.Literal(pattern))

    let inline private spanning< ^t, ^a, ^b when (^t or ^a) : (static member Spanning : ^a -> ^b)> pattern = ((^t or ^a) : (static member Spanning : ^a -> ^b)(pattern))

    let inline span pattern = spanning<Binder, _, Pattern> pattern