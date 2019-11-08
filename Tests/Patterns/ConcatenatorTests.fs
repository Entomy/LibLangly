namespace Tests.Patterns

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

        let mutable result = Result()

        result <- helloWorld.Consume("Hello world")
        ResultAssert.Captures("Hello world", result)

        result <- goodbyeWorld.Consume("Goodbye world")
        ResultAssert.Captures("Goodbye world", result)

        result <- helloWorld.Consume("Hello everyone")
        ResultAssert.Fails(result)

        result <- goodbyeWorld.Consume("Hello world")
        ResultAssert.Fails(result)