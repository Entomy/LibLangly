namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SurrogatePairTests() =
    [<DataTestMethod>]
    [<DataRow(0xD800u, 0xDC00u)>]
    [<DataRow(0xDBFFu, 0xDFFFu)>]
    member _.``constructor high-low`` (high:uint32, low:uint32) =
        SurrogatePair(CodePoint(high), CodePoint(low))
        ()

    [<DataTestMethod>]
    [<DataRow(0x10330u)>]
    member _.``constructor SMP`` (value:uint32) =
        SurrogatePair(CodePoint(value))
        ()

    [<DataTestMethod>]
    [<DataRow(0x01D11Eu, 0xD834u, 0xDD1Eu)>]
    member _.``to codepoint`` (exp:uint32, high:uint32, low:uint32) = Assert.IsTrue(CodePoint(exp).Equals(SurrogatePair(CodePoint(high), CodePoint(low)).CodePoint))