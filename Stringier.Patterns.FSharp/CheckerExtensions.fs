namespace System.Text.Patterns

open System
open System.Text.Patterns.Bindings

[<AutoOpen>]
module CheckerExtensions =

    type Binding =
        static member Checker(name:String, check:Func<char, bool>) = PatternBindings.Checker(name, check)
        static member Checker(name:String, check:(char -> bool)) = PatternBindings.Checker(name, new Func<char, bool>(check))

    let inline checker< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Checker : ^a * ^b -> ^c)> name check = ((^t or ^a) : (static member Checker : ^a * ^b -> ^c)(name, check))

    let inline check name check = checker<Binding, _, _, _> name check
