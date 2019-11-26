namespace Stringier.Patterns

open System

[<AutoOpen>]
module OptorExtensions =

    type Binder =
        static member Optional(pattern:Pattern) = Pattern.Maybe(pattern)
        static member Optional(pattern:String) = Pattern.Maybe(pattern)
        static member Optional(pattern:Char) = Pattern.Maybe(pattern)
        static member Optional(pattern:Capture ref) = Pattern.Maybe(!pattern)

    let inline private optional< ^t, ^a, ^b when (^t or ^a) : (static member Optional : ^a -> ^b)> pattern = ((^t or ^a) : (static member Optional : ^a -> ^b)(pattern))

    let inline maybe pattern = optional<Binder, _, Pattern> pattern