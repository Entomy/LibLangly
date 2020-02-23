namespace Extensions

open System
open Stringier.Extensions
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type PalindromeTests() =
    [<DataTestMethod>]
    [<DataRow("")>]
    [<DataRow("a")>]
    [<DataRow("detartrated")>]
    [<DataRow("tattarrattat")>]
    [<DataRow("Malayalam")>]
    [<DataRow("Was it a car or a cat I saw?")>]
    [<DataRow("No 'X' in Nixon")>]
    [<DataRow("Able was I ere I saw Elba")>]
    [<DataRow("A man, a plan, a canal, Panama!")>]
    [<DataRow("Do, O God, no evil deed! Live on! Do good!")>]
    member _.``palindrome - string`` (src:string) = Assert.IsTrue(palindrome src)

    [<DataTestMethod>]
    [<DataRow([|'a'|])>]
    [<DataRow([|'a';'a'|])>]
    [<DataRow([|'á';'a';'á'|])>]
    [<DataRow([|'á';'.';'a';'á';'.'|])>]
    member _.``palindrome - chars`` (src:char[]) = Assert.IsTrue(palindrome src)