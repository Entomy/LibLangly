namespace Patterns

open System
open Stringier.Patterns
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ExtensionTests() =

    [<TestMethod>]
    member _.``char consume string`` () =
        let mutable source = Source("hello")
        ResultAssert.Fails('?'.Consume(&source))
        ResultAssert.Captures("h", 'h'.Consume(&source))
        ResultAssert.Captures("e", 'e'.Consume(&source))
        ResultAssert.Captures("l", 'l'.Consume(&source))
        ResultAssert.Captures("l", 'l'.Consume(&source))
        ResultAssert.Captures("o", 'o'.Consume(&source))
        ResultAssert.Fails('?'.Consume(&source))

    [<TestMethod>]
    member _.``string consume string`` () =
        let mutable source = Source("hello")
        ResultAssert.Fails("hello?".Consume(&source))
        ResultAssert.Captures("hello", "hello".Consume(&source))
        ResultAssert.Fails("?".Consume(&source))