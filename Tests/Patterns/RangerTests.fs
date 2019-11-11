namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RangerTests() =

    [<TestMethod>]
    member _.``range consume`` () =
        let pattern = range "Hello" ';'
        let mutable result = Result()

        result <- pattern.Consume("Hello;")
        ResultAssert.Captures("Hello;", result)

        result <- pattern.Consume("Hello World;")
        ResultAssert.Captures("Hello World;", result)

    [<TestMethod>]
    member _.``range neglect`` () =
        let pattern () = negate(range "Hello" ';') |> ignore
        Assert.ThrowsException<PatternConstructionException>(Action pattern) |> ignore

    [<TestMethod>]
    member _.``erange consume``() =
        let pattern = erange "\"" "\"" "\\\""
        let mutable result = Result()

        result <- pattern.Consume("\"\"")
        ResultAssert.Captures("\"\"", result)

        result <- pattern.Consume("\"H\"")
        ResultAssert.Captures("\"H\"", result)

        result <- pattern.Consume("\"Hello\"")
        ResultAssert.Captures("\"Hello\"", result)

        result <- pattern.Consume("\"Hello\\\"Goodbye\"")
        ResultAssert.Captures("\"Hello\\\"Goodbye\"", result)

    [<TestMethod>]
    member _.``nrange consume`` () =
        let pattern = nrange "if" "end if"
        let mutable result = Result()

        result <- pattern.Consume("if\nif\nend if\nbacon\nend if\nfoobar")
        ResultAssert.Captures("if\nif\nend if\nbacon\nend if", result)

        result <- pattern.Consume("if\nif\nend if\nbacon\nfoobar")
        ResultAssert.Fails(result)