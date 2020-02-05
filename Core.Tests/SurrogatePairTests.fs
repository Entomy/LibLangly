namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SurrogatePairTests() =
    [<DataTestMethod>]
    [<DataRow(0x010000, '\uD800', '\uDC00')>]
    [<DataRow(0x01D11E, '\uD834', '\uDD1E')>]
    [<DataRow(0x01F3A8, '\uD83C', '\uDFA8')>]
    [<DataRow(0x10FFFF, '\uDBFF', '\uDFFF')>]
    member _.``constructor high-low - valid`` (exp:int, high:char, low:char) = 
        Assert.AreEqual(exp, SurrogatePair(CodePoint(high), CodePoint(low)).CodePoint.Value)
        ()

    [<DataTestMethod>]
    [<DataRow(0xD800u, 0xD800u)>]
    [<DataRow(0xDFFFu, 0xDFFFu)>]
    [<DataRow(0xDE00u, 0xDB00u)>]
    [<DataRow(0xD900u, 0x1234u)>]
    [<DataRow(0xD900u, 0xE000u)>]
    [<DataRow(0x1234u, 0xDE00u)>]
    [<DataRow(0xDC00u, 0xDE00u)>]
    member _.``constructor high-low - invalid`` (high:uint32, low:uint32) =
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> SurrogatePair(CodePoint(high), CodePoint(low)).CodePoint.IsAscii |> ignore)) |> ignore

    [<DataTestMethod>]
    [<DataRow(0x10330, 0x10330u)>]
    member _.``constructor SMP - valid`` (exp:int32, value:uint32) =
        Assert.AreEqual(exp, SurrogatePair(CodePoint(value)).CodePoint.Value)
        ()

    [<DataTestMethod>]
    [<DataRow(0x41u)>]
    [<DataRow(0xD800u)>]
    [<DataRow(0xDC00u)>]
    member _.``constructor SMP - invalid`` (value:uint32) =
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> SurrogatePair(CodePoint(value)).CodePoint.IsAscii |> ignore)) |> ignore
