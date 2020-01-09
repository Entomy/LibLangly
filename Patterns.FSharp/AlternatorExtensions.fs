namespace Stringier.Patterns

open System

#nowarn "86" // Shuts up about using ||. We are overloading it not overriding it, so it's fine.

[<AutoOpen>]
module AlternatorExtensions =

    type Binding =
        static member Alternate(left:Pattern, right:Pattern) = left.Or(right)
        static member Alternate(left:String, right:Pattern) = left.Or(right)
        static member Alternate(left:Pattern, right:String) = left.Or(right)
        static member Alternate(left:Char, right:Pattern) = left.Or(right)
        static member Alternate(left:Pattern, right:Char) = left.Or(right)
        static member Alternate(left:String, right:String) = left.Or(right)
        static member Alternate(left:String, right:Char) = left.Or(right)
        static member Alternate(left:Char, right:String) = left.Or(right)
        static member Alternate(left:Char, right:Char) = left.Or(right)
        static member Alternate(left:Pattern, right:Capture ref) = left.Or(!right)
        static member Alternate(left:Capture ref, right:Pattern) = (!left).Or(right)
        static member Alternate(left:String, right:Capture ref) = left.Or(!right)
        static member Alternate(left:Capture ref, right:String) = (!left).Or(right)
        static member Alternate(left:Char, right:Capture ref) = left.Or(!right)
        static member Alternate(left:Capture ref, right:Char) = (!left).Or(right)
        // This makes the operator still do boolean or
        static member Alternate(left, right) = left || right

    let inline private alternate< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Alternate : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Alternate : ^a * ^b -> ^c)(left, right))

    let inline ( || ) left right = alternate<Binding, _, _, _> left right

    let inline oneOf (patterns:Pattern[]) = Pattern.OneOf(patterns)

    let inline oneOfEnum<'e when 'e :> Enum> = Pattern.OneOf<'e>()