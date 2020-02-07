namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ConcatenatorTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let _pattern = "Hello" >> ' ' >> "world"
        ()

    [<TestMethod>]
    member _.``consume`` () =
        let helloWorld = "Hello" >> ' ' >> "world"
        let goodbyeWorld = "Goodbye" >> ' ' >> "world"

        ResultAssert.Captures("Hello world", helloWorld.Consume("Hello world"))
        ResultAssert.Captures("Goodbye world", goodbyeWorld.Consume("Goodbye world"))
        ResultAssert.Fails(helloWorld.Consume("Hello everyone"))
        ResultAssert.Fails(goodbyeWorld.Consume("Hello world"))

    [<TestMethod>]
    member _.``forward composition still works`` () =
        let f x = x + 1
        let g x = x * 2
        let h = f >> g
        Assert.AreEqual(4, h 1)

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not ("Hello" >> '!')
        ResultAssert.Fails(pattern.Consume("Hello"))
        ResultAssert.Fails(pattern.Consume("Hello!"))
        ResultAssert.Captures("Hello.", pattern.Consume("Hello."))
        ResultAssert.Captures("Oh no!", pattern.Consume("Oh no!"))
        ResultAssert.Captures("Oh no?", pattern.Consume("Oh no?"))