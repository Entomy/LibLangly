namespace Tests

open System
open System.Collections.Generic
open System.Text
open Stringier
open Microsoft.VisualStudio.TestTools.UnitTesting

//! This file uses testing code/approaches also used by the .NET Core runtime. Copyright belongs to the .NET Core Foundation.

type GeneralTestData(scalarValue, isAscii, isBmp, plane, utf16Sequence, utf8Sequence) =
    member _.ScalarValue:int32 = scalarValue
    member _.IsAscii:bool = isAscii
    member _.IsBmp:bool = isBmp
    member _.Plane:int32 = plane
    member _.Utf16Sequence:char[] = utf16Sequence
    member _.Utf8Sequence:byte[] = utf8Sequence

[<TestClass>]
type RuneTests() =
    static member AllRunes():seq<Rune> = seq {
        for i in 0u..0xD800u do yield Rune(i)
        for i in 0xE000u..0x10FFFFu do yield Rune(i) }
        
    static member GeneralTestData_BmpCodePoints_NoSurrogate():seq<Object[]> = seq {
        yield [| GeneralTestData(0x00, true, true, 0, [| '\u0000' |], [| 0x00uy |]) |]
        yield [| GeneralTestData(0x7F, true, true, 0, [| '\u007F' |], [| 0x7Fuy |]) |]
        yield [| GeneralTestData(0x80, false, true, 0, [| '\u0080' |], [| 0xC2uy; 0x80uy |]) |]
        yield [| GeneralTestData(0x07FF, false, true, 0, [| '\u07FF' |], [| 0xDFuy; 0xBFuy |]) |]
        yield [| GeneralTestData(0x0800, false, true, 0, [| '\u0800' |], [| 0xE0uy; 0xA0uy; 0x80uy |]) |]
        yield [| GeneralTestData(0xD7FF, false, true, 0, [| '\uD7FF' |], [| 0xEDuy; 0x9Fuy; 0xBFuy |]) |]
        yield [| GeneralTestData(0xE000, false, true, 0, [| '\uE000' |], [| 0xEEuy; 0x80uy; 0x80uy |]) |]
        yield [| GeneralTestData(0xFFFD, false, true, 0, [| '\uFFFD' |], [| 0xEFuy; 0xBFuy; 0xBDuy |]) |]
        yield [| GeneralTestData(0xFFFF, false, true, 0, [| '\uFFFF' |], [| 0xEFuy; 0xBFuy; 0xBFuy |]) |] }

    [<DataTestMethod>]
    [<DynamicData("GeneralTestData_BmpCodePoints_NoSurrogate", DynamicDataSourceType.Method)>]
    member _.``Ctor_Cast_Char_Valid`` (testData:GeneralTestData) =
        let rune = Rune(testData.ScalarValue)
        let runeFromCast = Rune.op_Explicit(char testData.ScalarValue)

        Assert.AreEqual(rune, runeFromCast)
        Assert.AreEqual(testData.ScalarValue, rune.Value)
        Assert.AreEqual(testData.IsAscii, rune.IsAscii)
        Assert.AreEqual(testData.IsBmp, rune.IsBmp)
        Assert.AreEqual(testData.Plane, rune.Plane)

    [<DataTestMethod>]
    [<DataRow('\uD800')>]
    [<DataRow('\uDBFF')>]
    [<DataRow('\uDC00')>]
    [<DataRow('\uDFFF')>]
    member _.``Ctor_Cast_Char_Invalid_Throws`` (ch:char) =
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune(ch) |> ignore) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune.op_Explicit(ch) |> ignore) |> ignore