namespace System.Text.Patterns

open System

type RepeaterExtensions =
    static member Spannr(left:Pattern, right:Int32) = Pattern.Repeat(left, right)
    static member Spannr(left:String, right:Int32) = Pattern.Repeat(left, right)
    static member Spannr(left:Char, right:Int32) = Pattern.Repeat(left, right)
