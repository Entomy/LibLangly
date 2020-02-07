namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type RepeatTests() =

    [<TestMethod>]
    member _.``repeat 3 'a'`` () =
        Assert.AreEqual("aaa", repeat 3 'a')

    [<TestMethod>]
    member _.``repeat 3 "hi!"`` () =
        Assert.AreEqual("hi!hi!hi!", repeat 3 "hi!")