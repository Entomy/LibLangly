namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CodePointTests() =
    [<TestMethod>]
    member _.``constructor int32`` () =
        let nullChar = CodePoint(0x00)
        let A = CodePoint(0x41)
        let 肀 = CodePoint(0x8080)
        let largestValid = CodePoint(0x10FFFF)
        //Due to a design decision for F#, CodePoint can not be passed to ignore, meaning one of its properties needs to be called to use it in this context. The exception is thrown during construction regardless, so the property is never called. Even if it was, the required functionality is still being tested.
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> CodePoint(-0x01).IsASCII |> ignore)) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> CodePoint(0x110000).IsASCII |> ignore)) |> ignore

    [<TestMethod>]
    member _.``constructor uint32`` () =
        let nullChar = CodePoint(0x00u)
        let A = CodePoint(0x41u)
        let 肀 = CodePoint(0x8080u)
        let largestValid = CodePoint(0x10FFFFu)
        //Due to a design decision for F#, CodePoint can not be passed to ignore, meaning one of its properties needs to be called to use it in this context. The exception is thrown during construction regardless, so the property is never called. Even if it was, the required functionality is still being tested.
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> CodePoint(0x110000u).IsASCII |> ignore)) |> ignore

    [<TestMethod>]
    member _.``constructor char`` () =
        let nullChar = CodePoint('\u0000')
        let A = CodePoint('A')
        let 肀 = CodePoint('肀')
        ()

    [<DataTestMethod>]
    [<DataRow(1, 0x00u)>]
    [<DataRow(1, 0x41u)>]
    [<DataRow(1, 0x7Eu)>]
    [<DataRow(1, 0x7Fu)>]
    [<DataRow(1, 0x80u)>]
    [<DataRow(1, 0x0416u)>]
    [<DataRow(1, 0x8080u)>]
    [<DataRow(2, 0x010281u)>]
    member _.``UTF-16 sequence length`` (exp:int32, value:uint32) = Assert.AreEqual(exp, CodePoint(value).Utf16SequenceLength)

    [<DataTestMethod>]
    [<DataRow(1, 0x00u)>]
    [<DataRow(1, 0x41u)>]
    [<DataRow(1, 0x7Eu)>]
    [<DataRow(1, 0x7Fu)>]
    [<DataRow(2, 0x80u)>]
    [<DataRow(2, 0x0416u)>]
    [<DataRow(3, 0x8080u)>]
    [<DataRow(4, 0x010281u)>]
    member _.``UTF-8 sequence length`` (exp:int32, value:uint32) = Assert.AreEqual(exp, CodePoint(value).Utf8SequenceLength)

    [<DataTestMethod>]
    [<DataRow("U+00", 0x00u)>]
    [<DataRow("U+41", 0x41u)>]
    [<DataRow("U+7E", 0x7Eu)>]
    [<DataRow("U+7F", 0x7Fu)>]
    [<DataRow("U+80", 0x80u)>]
    [<DataRow("U+0416", 0x0416u)>]
    [<DataRow("U+8080", 0x8080u)>]
    [<DataRow("U+010281", 0x010281u)>]
    member _.``ToString()`` (exp:string, value:uint32) = Assert.AreEqual(exp, CodePoint(value).ToString())

    [<DataTestMethod>]
    [<DataRow(false, 0xD7FFu)>]
    [<DataRow(true, 0xD800u)>]
    [<DataRow(true, 0xD801u)>]
    [<DataRow(true, 0xDBFFu)>]
    [<DataRow(false, 0xDC00u)>]
    member _.``is high surrogate`` (exp:bool, value:uint32) = Assert.AreEqual(exp, CodePoint(value).IsHighSurrogate)

    [<DataTestMethod>]
    [<DataRow(false, 0xDBFFu)>]
    [<DataRow(true, 0xDC00u)>]
    [<DataRow(true, 0xDC01u)>]
    [<DataRow(true, 0xDFFFu)>]
    [<DataRow(false, 0xE000u)>]
    member _.``is low surrogate`` (exp:bool, value:uint32) = Assert.AreEqual(exp, CodePoint(value).IsLowSurrogate)