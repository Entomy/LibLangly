namespace Patterns

open System
open Stringier
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type StressTests() =

    [<TestMethod>]
    member _.``gibberish`` () =
        let mutable source = Source(Gibberish.Generate(128))
        let letter = Pattern.Check((fun (char) -> 'a' <= char && char <= 'z'))
        let word = many letter
        let space = many ' '
        let gibberish:Pattern = (many (word || space)) >> Pattern.EndOfSource
        ResultAssert.Succeeds(gibberish.Consume(&source))