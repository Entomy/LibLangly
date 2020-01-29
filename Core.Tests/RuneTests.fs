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
    member this.__DebugDisplay:string = "U+" + this.ScalarValue.ToString("X4");

[<TestClass>]
type RuneTests() =
    static member AllRunes():seq<Rune> = seq {
        for i in 0u..0xD800u do yield Rune(i)
        for i in 0xE000u..0x10FFFFu do yield Rune(i) }
        
    static member GeneralTestData_BmpCodePoints_NoSurrogates():seq<Object[]> = seq {
        yield [| GeneralTestData(0x00, true, true, 0, [| '\u0000' |], [| 0x00uy |]) |]
        yield [| GeneralTestData(0x7F, true, true, 0, [| '\u007F' |], [| 0x7Fuy |]) |]
        yield [| GeneralTestData(0x80, false, true, 0, [| '\u0080' |], [| 0xC2uy; 0x80uy |]) |]
        yield [| GeneralTestData(0x07FF, false, true, 0, [| '\u07FF' |], [| 0xDFuy; 0xBFuy |]) |]
        yield [| GeneralTestData(0x0800, false, true, 0, [| '\u0800' |], [| 0xE0uy; 0xA0uy; 0x80uy |]) |]
        yield [| GeneralTestData(0xD7FF, false, true, 0, [| '\uD7FF' |], [| 0xEDuy; 0x9Fuy; 0xBFuy |]) |]
        yield [| GeneralTestData(0xE000, false, true, 0, [| '\uE000' |], [| 0xEEuy; 0x80uy; 0x80uy |]) |]
        yield [| GeneralTestData(0xFFFD, false, true, 0, [| '\uFFFD' |], [| 0xEFuy; 0xBFuy; 0xBDuy |]) |]
        yield [| GeneralTestData(0xFFFF, false, true, 0, [| '\uFFFF' |], [| 0xEFuy; 0xBFuy; 0xBFuy |]) |] }

    static member GeneralTestData_SupplementaryCodePoints_ValidOnly():seq<Object[]> = seq {
        yield [| GeneralTestData(0x10000, false, false, 1, [| '\uD800'; '\uDC00' |], [| 0xF0uy; 0x90uy; 0x80uy; 0x80uy |]) |]
        yield [| GeneralTestData(0x10FFFF, false, false, 16, [| '\uDBFF'; '\uDFFF' |], [| 0xF4uy; 0x8Fuy; 0xBFuy; 0xBFuy |]) |] }

    [<DataTestMethod>]
    [<DynamicData("GeneralTestData_BmpCodePoints_NoSurrogates", DynamicDataSourceType.Method)>]
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

    [<DataTestMethod>]
    [<DynamicData("GeneralTestData_BmpCodePoints_NoSurrogates", DynamicDataSourceType.Method)>]
    [<DynamicData("GeneralTestData_SupplementaryCodePoints_ValidOnly", DynamicDataSourceType.Method)>]
    member _.``Ctor_Cast_Int32_Valid`` (testData:GeneralTestData) =
        let rune = Rune(int testData.ScalarValue)
        let runeFromCast = Rune.op_Explicit(int testData.ScalarValue)

        Assert.AreEqual(rune, runeFromCast)
        Assert.AreEqual(testData.ScalarValue, rune.Value)
        Assert.AreEqual(testData.IsAscii, rune.IsAscii)
        Assert.AreEqual(testData.IsBmp, rune.IsBmp)
        Assert.AreEqual(testData.Plane, rune.Plane)

    [<DataTestMethod>]
    [<DataRow(0xD800)>]
    [<DataRow(0xDBFF)>]
    [<DataRow(0xDC00)>]
    [<DataRow(0xDFFF)>]
    [<DataRow(-0x01)>]
    [<DataRow(0x110000)>]
    member _.``Ctor_Cast_Int32_Invalid_Throws`` (value:int32) =
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune(value) |> ignore) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune.op_Explicit(value) |> ignore) |> ignore

    [<DataTestMethod>]
    [<DynamicData("GeneralTestData_BmpCodePoints_NoSurrogates", DynamicDataSourceType.Method)>]
    [<DynamicData("GeneralTestData_SupplementaryCodePoints_ValidOnly", DynamicDataSourceType.Method)>]
    member _.``Ctor_Cast_UInt32_Valid`` (testData:GeneralTestData) =
        let rune = Rune(uint32 testData.ScalarValue)
        let runeFromCast = Rune.op_Explicit(uint32 testData.ScalarValue)

        Assert.AreEqual(rune, runeFromCast)
        Assert.AreEqual(testData.ScalarValue, rune.Value)
        Assert.AreEqual(testData.IsAscii, rune.IsAscii)
        Assert.AreEqual(testData.IsBmp, rune.IsBmp)
        Assert.AreEqual(testData.Plane, rune.Plane)

    [<DataTestMethod>]
    [<DataRow(0xD800u)>]
    [<DataRow(0xDBFFu)>]
    [<DataRow(0xDC00u)>]
    [<DataRow(0xDFFFu)>]
    [<DataRow(0x110000u)>]
    member _.``Ctor_Cast_UInt32_Invalid_Throws`` (value:uint32) =
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune(value) |> ignore) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune.op_Explicit(value) |> ignore) |> ignore

    [<DataTestMethod>]
    [<DataRow(0x010000, '\uD800', '\uDC00')>]
    [<DataRow(0x10FFFF, '\uDBFF', '\uDFFF')>]
    [<DataRow(0x01F3A8, '\uD83C', '\uDFA8')>]
    member _.``Ctor_SurrogatePair_Valid`` (exp:int, high:char, low:char) =
        Assert.AreEqual(exp, Rune(high, low).Value)

    [<DataTestMethod>]
    [<DataRow('\uD800', '\uD800')>]
    [<DataRow('\uDFFF', '\uDFFF')>]
    [<DataRow('\uDF00', '\uDB00')>]
    [<DataRow('\uD900', '\u1234')>]
    [<DataRow('\uD900', '\uE000')>]
    [<DataRow('\u1234', '\uDE00')>]
    [<DataRow('\uDC00', '\uDE00')>]
    member _.``Ctor_SurrogatePair_Invalid`` (high:char, low:char) =
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune(high, low) |> ignore) |> ignore

    [<DataTestMethod>]
    [<DataRow(-1, 'A', 'a')>]
    [<DataRow(0, 'A', 'A')>]
    [<DataRow(1, 'a', 'A')>]
    [<DataRow(0, 0x10000, 0x10000)>]
    [<DataRow(-1, '\uFFFD', 0x10000)>]
    [<DataRow(1, 0x10FFFF, 0x10000)>]
    member _.``CompareTo_And_ComparisonOperators`` (exp:int, first:int, second:int) =
        let a = Rune(first)
        let b = Rune(second)

        Assert.AreEqual(exp, Math.Sign(a.CompareTo(b)))
        //These had to be changed from the official ones. Due to what I beleive is an oversight, F# comparison operators can't work with Rune, because of the missing IComparable interface.
        Assert.AreEqual(exp, a.CompareTo(b))
        Assert.AreEqual(exp, a.CompareTo(b))
        Assert.AreEqual(exp, a.CompareTo(b))
        Assert.AreEqual(exp, a.CompareTo(b))