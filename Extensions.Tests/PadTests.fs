namespace Tests.Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type PadTests() =
    
    [<TestMethod>]
    member _.``pad 10 "hello"`` () =
        Assert.AreEqual("  hello   ", pad 10 "hello")

    [<TestMethod>]
    member _.``pad 4 "hello"`` () =
        Assert.AreEqual("hello", pad 4 "hello")

    [<TestMethod>]
    member _.``pad2 10 '-' "hello"`` () =
        Assert.AreEqual("--hello---", pad2 10 '-' "hello")