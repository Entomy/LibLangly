namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SpannerTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = many ' '

        ResultAssert.Captures(" ", pattern.Consume(" Hi!"))
        ResultAssert.Captures("    ", pattern.Consume("    Hi!"))
        ResultAssert.Fails(pattern.Consume("Hi!  "))

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not (many ';')
        ResultAssert.Fails(pattern.Consume(";"))
        ResultAssert.Captures("123456789", pattern.Consume("123456789;"))