namespace System.Text.Patterns

open System

type AlternatorExtensions =
    static member Altern(left:Pattern, right:Pattern) = Pattern.Alternator(left, right)
    static member Altern(left:String, right:Pattern) = Pattern.Alternator(left, right)
    static member Altern(left:Pattern, right:String) = Pattern.Alternator(left, right)
    static member Altern(left:Pattern, right:Char) = Pattern.Alternator(left, right)
    static member Altern(left:Char, right:Pattern) = Pattern.Alternator(left, right)
    static member Altern(left:String, right:String) = Pattern.Alternator(left, right)
    static member Altern(left:String, right:Char) = Pattern.Alternator(left, right)
    static member Altern(left:Char, right:String) = Pattern.Alternator(left, right)
    static member Altern(left:Char, right:Char) = Pattern.Alternator(left, right)
