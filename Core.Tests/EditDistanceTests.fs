namespace Core

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type EditDistanceTests() =

    [<DataTestMethod>]
    [<DataRow(1, "ram", "rám")>]
    [<DataRow(0, "\u0072\u00E1\u006D", "\u0072\u0061\u0301\u006D")>]
    [<DataRow(1, "ram", "rom")>]
    [<DataRow(2, "ram", "rob")>]
    member _.``Hamming Distance - grapheme wise``(exp:int32, src:string, oth:string) = Assert.AreEqual(exp, hamming src oth)

    [<DataTestMethod>]
    [<DataRow(1, "ram", "rom")>]
    [<DataRow(2, "ram", "rob")>]
    member _.``Hamming Distance - character wise``(exp:int32, src:string, oth:string) = Assert.AreEqual(exp, hamming (src.ToCharArray()) (oth.ToCharArray()))

    [<DataTestMethod>]
    [<DataRow(1, "ram", "rom")>]
    [<DataRow(2, "ram", "rob")>]
    [<DataRow(3, "ram", "random")>]
    [<DataRow(2, "flaw", "lawn")>]
    member _.``Levenshtein Distance``(exp:int32, src:string, oth:string) = Assert.AreEqual(exp, levenshtein src oth)