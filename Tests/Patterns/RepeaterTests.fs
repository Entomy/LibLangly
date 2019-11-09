namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RepeaterTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = "Hi! " * 2
        let mutable result = Result()

        result <- pattern.Consume("Hi! Hi! Hi!")
        ResultAssert.Captures("Hi! Hi! ", result)

        result <- pattern.Consume("Bye! Hi! ")
        ResultAssert.Fails(result)

    [<TestMethod>]
    member _.``multiplication still works`` () =
        Assert.AreEqual(4, 2 * 2)
        Assert.AreEqual(6.66, 3.33 * 2.0)