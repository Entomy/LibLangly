namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RepeaterTests() =

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = "Hi! " * 2

        ResultAssert.Captures("Hi! Hi! ", pattern.Consume("Hi! Hi! Hi!"))
        ResultAssert.Fails(pattern.Consume("Bye! Hi! "))

    [<TestMethod>]
    member _.``multiplication still works`` () =
        Assert.AreEqual(4, 2 * 2)
        Assert.AreEqual(6.66, 3.33 * 2.0)

    [<TestMethod>]
    member _.``neglect`` () =
        let pattern = not ("Hi!" * 2)
        ResultAssert.Fails(pattern.Consume("Hi!Hi!"))
        ResultAssert.Captures("Oh!Oh!", pattern.Consume("Oh!Oh!"))
        ResultAssert.Captures("Oh!Hi!", pattern.Consume("Oh!Hi!"))