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

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = negate (span ';')
        ResultAssert.Fails(pattern.Consume(";"))
        ResultAssert.Captures("123456789", pattern.Consume("123456789;"))