namespace Stringier.Patterns

open System

[<AutoOpen>]
module FuzzerExtensions =

    let fuzzy(string) = Pattern.Fuzzy(string)