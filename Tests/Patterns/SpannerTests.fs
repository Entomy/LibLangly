namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SpannerTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = span ' '
        let mutable result = Result()

        result <- pattern.Consume(" Hi!")
        ResultAssert.Captures(" ", result)

        result <- pattern.Consume("    Hi!")
        ResultAssert.Captures("    ", result)

        result <- pattern.Consume("Hi!  ")
        ResultAssert.Fails(result)