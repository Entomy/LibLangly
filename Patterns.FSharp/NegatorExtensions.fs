namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module NegatorExtensions =

    type Binder =
        static member Negate(pattern:Pattern) = PatternBindings.Negator(pattern)
        static member Negate(pattern:String) = PatternBindings.Negator(p pattern)
        static member Negate(pattern:Char) = PatternBindings.Negator(p pattern)
        static member Negate(pattern:Capture ref) = PatternBindings.Negator(p pattern)

    let inline private negated< ^t, ^a, ^b when (^t or ^a) : (static member Negate : ^a -> ^b)> pattern = ((^t or ^a) : (static member Negate : ^a -> ^b)(pattern))

    let inline negate pattern = negated<Binder, _, Pattern> pattern