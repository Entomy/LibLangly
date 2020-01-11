namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SearchTests() =
    [<TestMethod>]
    member _.``Brute Force`` () =
        Assert.AreEqual(3, Search.BruteForce("helloworld", "low"))
        Assert.AreEqual(-1, Search.BruteForce("helloworld", "bacon"))