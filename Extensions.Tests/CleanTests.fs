namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CleanTests() =

    [<TestMethod>]
    member _.``clean "hello world"`` () =
        Assert.AreEqual("hello world", clean "hello world")

    [<TestMethod>]
    member _.``clean "hello  world"`` () =
        Assert.AreEqual("hello world", clean "hello  world")

    [<TestMethod>]
    member _.``clean " hello  world "`` () =
        Assert.AreEqual("hello world", clean " hello  world ")

    [<TestMethod>]
    member _.``clean 'o' "hellooo world"`` () =
        Assert.AreEqual("hello world", clean2 'o' "hellooo world")