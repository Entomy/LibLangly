namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SpannerTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = many ' '
        let mutable result = Result()

        result <- pattern.Consume(" Hi!")
        ResultAssert.Captures(" ", result)

        result <- pattern.Consume("    Hi!")
        ResultAssert.Captures("    ", result)

        result <- pattern.Consume("Hi!  ")
        ResultAssert.Fails(result)

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not (many ';')
        ResultAssert.Fails(pattern.Consume(";"))
        ResultAssert.Captures("123456789", pattern.Consume("123456789;"))