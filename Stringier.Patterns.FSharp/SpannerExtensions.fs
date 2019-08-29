namespace System.Text.Patterns

open System

type SpannerExtensions =
    static member Spannr(value:Pattern) = Pattern.Span(value)
    static member Spannr(value:String) = Pattern.Span(value)
    static member Spannr(value:Char) = Pattern.Span(value)