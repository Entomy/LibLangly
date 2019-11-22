namespace Tests.Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type LiteralTests() =

    [<TestMethod>]
    member _.``constructor`` () =
        let _charLiteral = p 'h'
        let _stringLiteral = p "hello"
        ()

    [<TestMethod>]
    member _.``consume string`` () =
        let hello = p "Hello"

        let mutable result = Result()
        
        result <- hello.Consume("Hello World!")
        ResultAssert.Captures("Hello", result)

        result <- hello.Consume("Hell")
        ResultAssert.Fails(result)

        result <- hello.Consume("Bacon")
        ResultAssert.Fails(result)

    [<TestMethod>]
    member _.``consume source`` () =
        let hello = p "Hello"
        let space = p ' '
        let world = p "World"

        let mutable result = Result()

        let mutable source = Source("Hello World")

        result <- hello.Consume(&source)
        ResultAssert.Captures("Hello", result)

        result <- space.Consume(&source)
        ResultAssert.Captures(" ", result)

        result <- world.Consume(&source)
        ResultAssert.Captures("World", result)

        source <- Source("Hello World")
        let helloWorld = hello >> space >> world

        result <- helloWorld.Consume(&source)
        ResultAssert.Captures("Hello World", result)

    [<TestMethod>]
    member _.``consume case-insensitive`` () =
        let pattern = "Hello"/=Compare.CaseInsensitive >> ' ' >> "World"/=Compare.CaseInsensitive
        
        ResultAssert.Captures("HELLO WORLD", pattern.Consume("HELLO WORLD"))
        ResultAssert.Captures("hello world", pattern.Consume("hello world"))

    [<TestMethod>]
    member _.``neglect string`` () =
        let pattern = negate "Hello"
        ResultAssert.Fails(pattern.Consume("Hello"))
        ResultAssert.Fails(pattern.Consume("Hello!"))
        ResultAssert.Fails(pattern.Consume("Hello."))
        ResultAssert.Captures("Oh no", pattern.Consume("Oh no!"))
        ResultAssert.Captures("Oh no", pattern.Consume("Oh no?"))