namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type EnsureTests() =
    [<TestMethod>]
    member _.``ensureBegins "Mr " "Bob Saget"`` () =
        Assert.AreEqual("Mr. Bob Saget", ensureBegins "Mr. " "Bob Saget")

    [<TestMethod>]
    member _.``ensureBegins "Mr " "Mr Bob Saget"`` () =
        Assert.AreEqual("Mr. Bob Saget", ensureBegins "Mr. " "Mr. Bob Saget")

    [<TestMethod>]
    member _.``ensureEnds " MD" "Gregory House"`` () =
        Assert.AreEqual("Gregory House MD", ensureEnds " MD" "Gregory House")

    [<TestMethod>]
    member _.``ensureEnds " MD" "Gregory House MD"`` () =
        Assert.AreEqual("Gregory House MD", ensureEnds " MD" "Gregory House MD")