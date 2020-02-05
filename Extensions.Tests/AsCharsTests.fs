namespace Tests.Extensions

open System
open System.Text
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type AsCharsTests() =
    [<DataTestMethod>]
    [<DataRow([|'A'|], 0x41)>]
    [<DataRow([|'Þ'|], 0xDE)>]
    [<DataRow([|'ö'|], 0xF6)>]
    [<DataRow([|'Ξ'|], 0x39E)>]
    [<DataRow([|'℥'|], 0x2125)>]
    [<DataRow([|'⎃'|], 0x2383)>]
    [<DataRow([|'\uD834'; '\uDD1E'|], 0x1D11E)>] // 𝄞 which can't be represented with a single char
    member _.``rune AsChars`` (exp:char[], value:Int32) =
        CollectionAssert.AreEqual(exp, Rune(value).AsChars())