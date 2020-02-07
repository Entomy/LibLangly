namespace Patterns

open System
open System.Text.RegularExpressions
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RegexAdapterTests() =

    [<TestMethod>]
    member _.``converter`` () =
        let mutable pattern = (fun () -> Regex(@"hello").AsPattern() |> ignore)
        Assert.ThrowsException<PatternConstructionException>(Action pattern) |> ignore
        Regex(@"^hello") |> ignore
        pattern <- (fun () -> Regex(@"hello$").AsPattern() |> ignore)
        Assert.ThrowsException<PatternConstructionException>(Action pattern) |> ignore
        Regex(@"^hello$") |> ignore
        
    [<TestMethod>]
    member _.``consume`` () =
        let pattern = Regex(@"^hello").AsPattern()
        ResultAssert.Captures("hello", pattern.Consume("hello"))
        ResultAssert.Captures("hello", pattern.Consume("hello world"))
        ResultAssert.Fails(pattern.Consume("hel"))