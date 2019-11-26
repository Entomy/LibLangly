namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type AlternatorTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let _pattern = "Hello" || "Goodbye"
        ()

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = "Hello" || "Goodbye"
        let mutable result = Result()

        result <- pattern.Consume("Hello")
        ResultAssert.Captures("Hello", result)

        result <- pattern.Consume("Goodbye")
        ResultAssert.Captures("Goodbye", result)

        result <- pattern.Consume("!")
        ResultAssert.Fails(result)

        result <- pattern.Consume("How are you?")
        ResultAssert.Fails(result)

        let chainPattern = "Hello" || "Hi" || "Howdy"

        result <- chainPattern.Consume("Hello")
        ResultAssert.Captures("Hello", result)

        result <- chainPattern.Consume("Hi")
        ResultAssert.Captures("Hi", result)

        result <- chainPattern.Consume("Howdy")
        ResultAssert.Captures("Howdy", result)

        result <- chainPattern.Consume("Goodbye")
        ResultAssert.Fails(result)

    [<TestMethod>]
    member _.``boolean-or still works`` () =
        Assert.IsTrue(true || true)
        Assert.IsTrue(false || true)
        Assert.IsTrue(true || false)
        Assert.IsFalse(false || false)

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not ("Hello" || "Goodbye")
        ResultAssert.Fails(pattern.Consume("Hello"))
        ResultAssert.Fails(pattern.Consume("Goodbye"))
        ResultAssert.Captures("World", pattern.Consume("Worldeater"))