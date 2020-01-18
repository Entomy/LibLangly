namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type SurrogatePairTests() =
    [<TestMethod>]
    member _.``constructor high-low`` () =
        SurrogatePair(CodePoint(0xD800u), CodePoint(0xDC00u))
        ()

    [<TestMethod>]
    member _.``constructor SMP`` () =
        SurrogatePair(CodePoint(0x10330u))
        ()

    [<DataTestMethod>]
    [<DataRow(0x01D11Eu, 0xD834u, 0xDD1Eu)>]
    member _.``to codepoint`` (exp:uint32, high:uint32, low:uint32) = Assert.IsTrue(CodePoint(exp).Equals(SurrogatePair(CodePoint(high), CodePoint(low)).CodePoint))