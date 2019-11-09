namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module OptorExtensions =

    type Binder =
        static member Optional(pattern:Pattern) = PatternBindings.Optor(pattern)
        static member Optional(pattern:String) = PatternBindings.Optor(pattern)
        static member Optional(pattern:Char) = PatternBindings.Optor(pattern)
        static member Optional(pattern:Capture) = PatternBindings.Optor(pattern)

    let inline private optional< ^t, ^a, ^b when (^t or ^a) : (static member Optional : ^a -> ^b)> pattern = ((^t or ^a) : (static member Optional : ^a -> ^b)(pattern))

    let inline option pattern = optional<Binder, _, Pattern> pattern