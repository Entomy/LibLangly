namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module OptorExtensions =

    type Binding =
        static member Option(value:Pattern) = PatternBindings.Optor(value)
        static member Option(value:String) = PatternBindings.Optor(value)
        static member Option(value:Char) = PatternBindings.Optor(value)

    let inline option< ^t, ^a, ^b     when (^t or ^a) : (static member Option : ^a -> ^b     )> value      = ((^t or ^a) : (static member Option : ^a -> ^b     )(value))

    /// <summary></summary>
    let inline ( ~~ ) value = option<Binding, _, _> value
