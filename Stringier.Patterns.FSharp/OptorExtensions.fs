namespace System.Text.Patterns

open System

type OptorExtensions =
    static member Option(value:Pattern) = Pattern.Optional(value)
    static member Option(value:String) = Pattern.Optional(value)
    static member Option(value:Char) = Pattern.Optional(value)