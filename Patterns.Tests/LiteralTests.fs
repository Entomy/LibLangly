namespace Patterns

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
        let hello = p"Hello"
        
        ResultAssert.Captures("Hello", hello.Consume("Hello World!"))

        ResultAssert.Fails(hello.Consume("Hell"))

        ResultAssert.Fails(hello.Consume("Bacon"))

    [<TestMethod>]
    member _.``consume source`` () =
        let hello = p"Hello"
        let space = p ' '
        let world = p"World"

        let mutable source = Source("Hello World")

        ResultAssert.Captures("Hello", hello.Consume(&source))

        ResultAssert.Captures(" ", space.Consume(&source))

        ResultAssert.Captures("World", world.Consume(&source))

        source <- Source("Hello World")
        let helloWorld = hello >> space >> world

        ResultAssert.Captures("Hello World", helloWorld.Consume(&source))

    [<TestMethod>]
    member _.``consume case-insensitive`` () =
        let pattern = "Hello"/=Compare.CaseInsensitive >> ' '/=Compare.CaseInsensitive >> "World"/=Compare.CaseInsensitive
        
        ResultAssert.Captures("HELLO WORLD", pattern.Consume("HELLO WORLD"))
        ResultAssert.Captures("hello world", pattern.Consume("hello world"))

    [<TestMethod>]
    member _.``neglect string`` () =
        let pattern = not "Hello"
        ResultAssert.Fails(pattern.Consume("Hello"))
        ResultAssert.Fails(pattern.Consume("Hello!"))
        ResultAssert.Fails(pattern.Consume("Hello."))
        ResultAssert.Captures("Oh no", pattern.Consume("Oh no!"))
        ResultAssert.Captures("Oh no", pattern.Consume("Oh no?"))