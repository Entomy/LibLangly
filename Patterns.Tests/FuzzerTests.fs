namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type FuzzerTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let pattern = fuzzy "bob"
        ()

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = fuzzy "bob"
        ResultAssert.Captures("bob", pattern.Consume("bob"))
        ResultAssert.Captures("mob", pattern.Consume("mob"))
        ResultAssert.Fails(pattern.Consume("mom"))