namespace Extensions

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type FormatTests() =
    [<TestMethod>]
    member _.``format`` () =
        Assert.AreEqual("hello", "{0}".Format("hello"))
        Assert.AreEqual("1c", "{0}{1}".Format(1, 'c'))
        Assert.AreEqual("12345", "{0}{1}{2}{3}{4}".Format(1, 2, 3, 4, 5))