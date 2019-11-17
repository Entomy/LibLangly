namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type OptorTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = option "Hello"
        let mutable result = Result()

        result <- pattern.Consume("Hello world!")
        ResultAssert.Captures("Hello", result)

        result <- pattern.Consume("Goodbye world!")
        ResultAssert.Captures("", result)

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = negate (option "Hello")
        ResultAssert.Captures("", pattern.Consume("Hello"))
        ResultAssert.Captures("World", pattern.Consume("World"))