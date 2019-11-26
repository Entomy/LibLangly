namespace Stringier.Patterns

open System

[<AutoOpen>]
module SpannerExtensions =

    type Binder =
        static member Spanning(pattern:Pattern) = Pattern.Many(pattern)
        static member Spanning(pattern:String) = Pattern.Many(pattern)
        static member Spanning(pattern:Char) = Pattern.Many(pattern)
        static member Spanning(pattern:Capture ref) = Pattern.Many(!pattern)

    let inline private spanning< ^t, ^a, ^b when (^t or ^a) : (static member Spanning : ^a -> ^b)> pattern = ((^t or ^a) : (static member Spanning : ^a -> ^b)(pattern))

    let inline many pattern = spanning<Binder, _, Pattern> pattern