namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RangerTests() =

    [<TestMethod>]
    member _.``range consume`` () =
        let pattern = range "Hello" ';'

        ResultAssert.Captures("Hello;", pattern.Consume("Hello;"))
        ResultAssert.Captures("Hello World;", pattern.Consume("Hello World;"))

    [<TestMethod>]
    member _.``range neglect`` () =
        let pattern () = not(range "Hello" ';') |> ignore
        Assert.ThrowsException<PatternConstructionException>(Action pattern) |> ignore

    [<TestMethod>]
    member _.``erange consume``() =
        let pattern = erange "\"" "\"" "\\\""

        ResultAssert.Captures("\"\"", pattern.Consume("\"\""))
        ResultAssert.Captures("\"H\"", pattern.Consume("\"H\""))
        ResultAssert.Captures("\"Hello\"", pattern.Consume("\"Hello\""))
        ResultAssert.Captures("\"Hello\\\"Goodbye\"", pattern.Consume("\"Hello\\\"Goodbye\""))

    [<TestMethod>]
    member _.``nrange consume`` () =
        let pattern = nrange "if" "end if"

        ResultAssert.Captures("if\nif\nend if\nbacon\nend if", pattern.Consume("if\nif\nend if\nbacon\nend if\nfoobar"))
        ResultAssert.Fails(pattern.Consume("if\nif\nend if\nbacon\nfoobar"))