namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type OptorTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = ~~"Hello"
        let mutable result = Result()

        result <- pattern.Consume("Hello world!")
        ResultAssert.Captures("Hello", result)

        result <- pattern.Consume("Goodbye world!")
        ResultAssert.Captures("", result)