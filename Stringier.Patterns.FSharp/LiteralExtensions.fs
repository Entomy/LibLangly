namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

type LiteralExtensions =
    static member Literl(value:String) = PatternBindings.Literal(value)
    static member Literl(value:char) = PatternBindings.Literal(value)

