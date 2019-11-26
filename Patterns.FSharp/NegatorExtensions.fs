namespace Stringier.Patterns

open System

[<AutoOpen>]
module NegatorExtensions =

    type Binder =
        static member Negate(pattern:Pattern) = Pattern.Not(pattern)
        static member Negate(pattern:String) = Pattern.Not(pattern)
        static member Negate(pattern:Char) = Pattern.Not(pattern)
        static member Negate(pattern:Capture ref) = Pattern.Not(!pattern)
        //This makes the operator still do Boolean negation
        static member Negate(value:bool):bool = not value

    let inline private negate< ^t, ^a, ^b when (^t or ^a) : (static member Negate : ^a -> ^b)> pattern = ((^t or ^a) : (static member Negate : ^a -> ^b)(pattern))

    let inline not pattern = negate<Binder, _, Pattern> pattern