﻿namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module NegatorExtensions =

    type Binding =
        static member Negate(value:Pattern) = PatternBindings.Negator(value)
        static member Negate(value:String) = PatternBindings.Negator(value)
        static member Negate(value:Char) = PatternBindings.Negator(value)

    let inline negate< ^t, ^a, ^b     when (^t or ^a) : (static member Negate : ^a -> ^b     )> value      = ((^t or ^a) : (static member Negate : ^a -> ^b     )(value))

    /// <summary>
    /// Marks the <paramref name="value"/> as negated
    /// </summary>
    let inline ( ~- ) value = negate<Binding, _, _> value