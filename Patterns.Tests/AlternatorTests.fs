namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

type enum = First = 1
          | Second = 2
          | Third = 3

[<TestClass>]
type AlternatorTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let _pattern = "Hello" || "Goodbye"
        ()

    [<TestMethod>]
    member _.``consume`` () =
        let pattern = "Hello" || "Goodbye"

        ResultAssert.Captures("Hello", pattern.Consume("Hello"))
        ResultAssert.Captures("Goodbye", pattern.Consume("Goodbye"))
        ResultAssert.Fails(pattern.Consume("!"))
        ResultAssert.Fails(pattern.Consume("How are you?"))

        let chainPattern = "Hello" || "Hi" || "Howdy"

        ResultAssert.Captures("Hello", chainPattern.Consume("Hello"))
        ResultAssert.Captures("Hi", chainPattern.Consume("Hi"))
        ResultAssert.Captures("Howdy", chainPattern.Consume("Howdy"))
        ResultAssert.Fails(chainPattern.Consume("Goodbye"))

        let oneOfPattern = oneOf [|p"Hello";p"Hi";p"Howdy"|]

        ResultAssert.Captures("Hello", oneOfPattern.Consume("Hello"))
        ResultAssert.Captures("Hi", oneOfPattern.Consume("Hi"))
        ResultAssert.Captures("Howdy", oneOfPattern.Consume("Howdy"))
        ResultAssert.Fails(chainPattern.Consume("Goodbye"))

        let oneOfEnum = oneOfEnum<enum>

        ResultAssert.Captures("First", oneOfEnum.Consume("First"))
        ResultAssert.Captures("Second", oneOfEnum.Consume("Second"))
        ResultAssert.Captures("Third", oneOfEnum.Consume("Third"))
        ResultAssert.Fails(oneOfEnum.Consume("Fourth"))

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