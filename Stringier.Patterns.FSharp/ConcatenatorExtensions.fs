namespace System.Text.Patterns

open System

type ConcatenatorExtensions =
    static member Concat(left:Pattern, right:Pattern) = Pattern.Concatenate(left, right)
    static member Concat(left:String, right:Pattern) = Pattern.Concatenate(left, right)
    static member Concat(left:Pattern, right:String) = Pattern.Concatenate(left, right)
    static member Concat(left:Pattern, right:Char) = Pattern.Concatenate(left, right)
    static member Concat(left:Char, right:Pattern) = Pattern.Concatenate(left, right)
    static member Concat(left:String, right:String) = Pattern.Concatenate(left, right)
    static member Concat(left:String, right:Char) = Pattern.Concatenate(left, right)
    static member Concat(left:Char, right:String) = Pattern.Concatenate(left, right)
    static member Concat(left:Char, right:Char) = Pattern.Concatenate(left, right)
