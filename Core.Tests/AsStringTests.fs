namespace Extensions

open System
open System.Text
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type AsStringTests() =
    [<TestMethod>]
    member _.``runes AsString - hello`` () =
        Assert.AreEqual("hello", [|Rune(0x68); Rune(0x65); Rune(0x6C); Rune(0x6C); Rune(0x6F)|].AsString())

    [<TestMethod>]
    member _.``runes AsString - привет`` () =
        Assert.AreEqual("привет", [|Rune(0x43F); Rune(0x440); Rune(0x438); Rune(0x432); Rune(0x435); Rune(0x442)|].AsString())

    [<TestMethod>]
    member _.``runes AsString - 𝄞`` () =
        Assert.AreEqual("𝄞", [|Rune(0x1D11E)|].AsString())