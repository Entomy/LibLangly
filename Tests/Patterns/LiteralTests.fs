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
        let pattern = "Hello"/=StringComparison.OrdinalIgnoreCase >> ' ' >> "World"/=StringComparison.OrdinalIgnoreCase
        
        ResultAssert.Captures("HELLO WORLD", pattern.Consume("HELLO WORLD"))
        ResultAssert.Captures("hello world", pattern.Consume("hello world"))