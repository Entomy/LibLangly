namespace System.Text.Patterns

open System

type NegatorExtensions =
    static member Negate(value:Pattern) = Pattern.Negate(value)
    static member Negate(value:String) = Pattern.Negate(value)
    static member Negate(value:Char) = Pattern.Negate(value)