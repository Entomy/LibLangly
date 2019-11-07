namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module LiteralExtensions =
    
    type Binder =
        static member Literal(value:string) = PatternBindings.Literal(value)
        static member Literal(value:char) =
            PatternBindings.Literal(value)

    let inline private literal< ^t, ^a, ^b when (^t or ^a) : (static member Literal : ^a -> ^b)> value = ((^t or ^a) : (static member Literal : ^a -> ^b)(value))

    /// <summary>
    /// Marks the specified value as being a <see cref="Pattern" />.
    /// </summary>
    let inline p value = literal<Binder, _, Pattern> value