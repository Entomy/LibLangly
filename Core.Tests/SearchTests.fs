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

    [<TestMethod>]
    member _.``Rabin-Karp`` () =
        Assert.AreEqual(3, Search.RabinKarp("helloworld", "low"))
        Assert.AreEqual(-1, Search.RabinKarp("helloworld", "bacon"))

    [<TestMethod>]
    member _.``Boyer-Moore-Horspool`` () =
        Assert.AreEqual(3, Search.Horspool("helloworld", "low"))
        Assert.AreEqual(-1, Search.Horspool("helloworld", "bacon"))