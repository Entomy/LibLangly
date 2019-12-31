namespace Tests.Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type PalindromeTests() =
    [<DataTestMethod>]
    [<DataRow("detartrated")>]
    [<DataRow("tattarrattat")>]
    [<DataRow("Malayalam")>]
    member _.``palindrome`` (src:string) =
        Assert.IsTrue(palindrome src)