namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CompoundPatternTests() =

    [<TestMethod>]
    member _.``alternate repeater`` () =
        let pattern = ("Hi " || "Bye ") * 2;
        ResultAssert.Captures("Hi Bye ", pattern.Consume("Hi Bye Hi"))

    [<TestMethod>]
    member _.``alternate spanner`` () =
        let pattern = many (Pattern.SpaceSeparator || "\t")
        ResultAssert.Captures("  \t ", pattern.Consume("  \t "))

    [<TestMethod>]
    member _.``double negator`` () =
        let pattern = not (not "Hello")
        ResultAssert.Captures("Hello", pattern.Consume("Hello"))

    [<TestMethod>]
    member _.``double optor`` () =
        let pattern = maybe (maybe "Hello")
        ResultAssert.Captures("Hello", pattern.Consume("Hello"))
        ResultAssert.Captures("", pattern.Consume("World"))

    [<TestMethod>]
    member _.``double spanner`` () =
        let pattern = many (many "hi")
        ResultAssert.Captures("hi", pattern.Consume("hi"))
        ResultAssert.Captures("hihi", pattern.Consume("hihi"))
        ResultAssert.Captures("hihihi", pattern.Consume("hihihi"))

    [<TestMethod>]
    member _.``optional spanner`` () =
        let pattern = kleene ' '
        ResultAssert.Captures("  ", pattern.Consume("  Hello"))
        ResultAssert.Captures("", pattern.Consume("Hello"))

    [<TestMethod>]
    member _.``spaning optor`` () =
        Assert.ThrowsException<PatternConstructionException>(fun () -> many(maybe ' ') |> ignore) |> ignore