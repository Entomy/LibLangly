namespace System.Text.Patterns

open System

type PatternExtensions =
    static member Consum(pattern:Pattern, source:String) = pattern.Consume(source)
    static member Consum(pattern:Pattern, source:byref<Source>) = pattern.Consume(&source)