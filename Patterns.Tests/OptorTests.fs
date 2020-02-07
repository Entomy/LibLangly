namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type OptorTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = maybe "Hello"

        ResultAssert.Captures("Hello", pattern.Consume("Hello world!"))
        ResultAssert.Captures("", pattern.Consume("Goodbye world!"))

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not (maybe "Hello")
        ResultAssert.Captures("", pattern.Consume("Hello"))
        ResultAssert.Captures("World", pattern.Consume("World"))