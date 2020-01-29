namespace Tests

open System
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CodePointTests() =
    [<DataTestMethod>]
    [<DataRow(0x00)>]
    [<DataRow(0x41)>]
    [<DataRow(0x7F)>]
    [<DataRow(0x80)>]
    [<DataRow(0x07FF)>]
    [<DataRow(0x8080)>]
    [<DataRow(0xD7FF)>]
    [<DataRow(0xE000)>]
    [<DataRow(0xFFFD)>]
    [<DataRow(0xFFFF)>]
    [<DataRow(0x10FFFF)>]
    member _.``constructor int32 - valid`` (codepoint:int32) = CodePoint(codepoint)

    [<DataTestMethod>]
    [<DataRow(-0x01)>]
    [<DataRow(0x110000)>]
    member _.``constructor int32 - invalid`` (codepoint:int32) =
        //Due to a design decision for F#, CodePoint can not be passed to ignore, meaning one of its properties needs to be called to use it in this context. The exception is thrown during construction regardless, so the property is never called. Even if it was, the required functionality is still being tested.
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> CodePoint(codepoint).IsAscii |> ignore)) |> ignore

    [<DataTestMethod>]
    [<DataRow(0x00u)>]
    [<DataRow(0x41u)>]
    [<DataRow(0x7Fu)>]
    [<DataRow(0x80u)>]
    [<DataRow(0x07FFu)>]
    [<DataRow(0x8080u)>]
    [<DataRow(0xD7FFu)>]
    [<DataRow(0xE000u)>]
    [<DataRow(0xFFFDu)>]
    [<DataRow(0xFFFFu)>]
    [<DataRow(0x10FFFFu)>]
    member _.``constructor uint32 - valid`` (codepoint:uint32) = CodePoint(codepoint)

    [<DataTestMethod>]
    [<DataRow(0x110000u)>]
    member _.``constructor uint32 - invalid`` (codepoint:uint32) =
        //Due to a design decision for F#, CodePoint can not be passed to ignore, meaning one of its properties needs to be called to use it in this context. The exception is thrown during construction regardless, so the property is never called. Even if it was, the required functionality is still being tested.
        Assert.ThrowsException<ArgumentOutOfRangeException>((fun () -> CodePoint(codepoint).IsAscii |> ignore)) |> ignore

    [<DataTestMethod>]
    [<DataRow('\u0000')>]
    [<DataRow('A')>]
    [<DataRow('肀')>]
    member _.``constructor char`` (char:char) = CodePoint(char)

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

    [<DataTestMethod>]
    [<DataRow(true, 0x41)>]
    [<DataRow(true, 0xDE)>]
    [<DataRow(true, 0xF6)>]
    [<DataRow(true, 0x39E)>]
    [<DataRow(true, 0x2125)>]
    [<DataRow(true, 0x2383)>]
    [<DataRow(true, 0x1D11E)>] // 𝄞 which can't be represented with a single char
    member _.``is code point`` (value:Int32) = CodePoint(value) //The constructor does the check, and will throw if not true

    [<DataTestMethod>]
    [<DataRow(true, 0x41)>]
    [<DataRow(true, 0xDE)>]
    [<DataRow(true, 0xF6)>]
    [<DataRow(true, 0x39E)>]
    [<DataRow(true, 0xFFFD)>]
    [<DataRow(true, 0x2125)>]
    [<DataRow(true, 0x2383)>]
    [<DataRow(true, 0x1D11E)>] // 𝄞 which can't be represented with a single char
    member _.``is scalar value`` (exp:bool, value:Int32) = Assert.AreEqual(exp, CodePoint(value).IsScalarValue)