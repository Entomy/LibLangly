namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SurrogatePairTests() =
    [<DataTestMethod>]
    [<DataRow(0xD800u, 0xDC00u)>]
    [<DataRow(0xDBFFu, 0xDFFFu)>]
    member _.``constructor high-low - valid`` (high:uint32, low:uint32) = 
        SurrogatePair(CodePoint(high), CodePoint(low))
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
    [<DataRow(0x10330u)>]
    member _.``constructor SMP - valid`` (value:uint32) =
        SurrogatePair(CodePoint(value))
        ()

    [<DataTestMethod>]
    [<DataRow(0x010000u, 0xD800u, 0xDC00u)>]
    [<DataRow(0x01D11Eu, 0xD834u, 0xDD1Eu)>]
    [<DataRow(0x01F3A8u, 0xD83Cu, 0xDFA8u)>]
    [<DataRow(0x10FFFFu, 0xDBFFu, 0xDFFFu)>]
    member _.``to codepoint`` (exp:uint32, high:uint32, low:uint32) = Assert.IsTrue(CodePoint(exp).Equals(SurrogatePair(CodePoint(high), CodePoint(low)).CodePoint))