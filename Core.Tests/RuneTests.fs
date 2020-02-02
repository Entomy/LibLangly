namespace Tests

open System
open System.Buffers
open System.Collections.Generic
open System.Globalization
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

type UnicodeInfoTestData(scalarValue, unicodeCategory, numericValue, isControl, isDigit, isLetter, isLetterOrDigit, isLower, isNumber, isPunctuation, isSeparator, isSymbol, isUpper, isWhiteSpace) =
    member _.ScalarValue:Rune = scalarValue
    member _.UnicodeCategory:UnicodeCategory = unicodeCategory
    member _.NumericValue:float = numericValue
    member _.IsControl:bool = isControl
    member _.IsDigit:bool = isDigit
    member _.IsLetter:bool = isLetter
    member _.IsLetterOrDigit:bool = isLetterOrDigit
    member _.IsLower:bool = isLower
    member _.IsNumber:bool = isNumber
    member _.IsPunctuation:bool = isPunctuation
    member _.IsSeparator:bool = isSeparator
    member _.IsSymbol:bool = isSymbol
    member _.IsUpper:bool = isUpper
    member _.IsWhiteSpace:bool = isWhiteSpace
    member this.__DebugDisplay:string = "U+" + this.ScalarValue.Value.ToString("X4")

[<TestClass>]
type RuneTests() =
    static member AllRunes():seq<Rune> = seq {
        for i in 0u..0xD7FFu do yield Rune(i)
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

    static member UnicodeInfoTestData_Latin1AndSelectOthers():seq<Object[]> = seq {
        yield [| UnicodeInfoTestData(Rune(0x00),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x01),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x02),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x03),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x04),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x05),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x06),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x07),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x08),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x09),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x0A),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x0B),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x0C),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false,  true) |]
        yield [| UnicodeInfoTestData(Rune(0x0D),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x0E),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x0F),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x10),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x11),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x12),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x13),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x14),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x15),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x16),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x17),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x18),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x19),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1A),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1B),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1C),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1D),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1E),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x1F),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x20),    UnicodeCategory.SpaceSeparator,          -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x21),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x22),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x23),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x24),    UnicodeCategory.CurrencySymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x25),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x26),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x27),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x28),    UnicodeCategory.OpenPunctuation,         -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x29),    UnicodeCategory.ClosePunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2A),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2B),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2C),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2D),    UnicodeCategory.DashPunctuation,         -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2E),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2F),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x30),    UnicodeCategory.DecimalDigitNumber,       0.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x31),    UnicodeCategory.DecimalDigitNumber,       1.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x32),    UnicodeCategory.DecimalDigitNumber,       2.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x33),    UnicodeCategory.DecimalDigitNumber,       3.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x34),    UnicodeCategory.DecimalDigitNumber,       4.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x35),    UnicodeCategory.DecimalDigitNumber,       5.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x36),    UnicodeCategory.DecimalDigitNumber,       6.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x37),    UnicodeCategory.DecimalDigitNumber,       7.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x38),    UnicodeCategory.DecimalDigitNumber,       8.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x39),    UnicodeCategory.DecimalDigitNumber,       9.0, false, true, false, true, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3A),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3B),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3C),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3D),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3E),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x3F),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x40),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x41),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x42),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x43),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x44),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x45),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x46),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x47),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x48),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x49),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4A),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4B),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4C),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4D),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4E),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x4F),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x50),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x51),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x52),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x53),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x54),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x55),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x56),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x57),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x58),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x59),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5A),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5B),    UnicodeCategory.OpenPunctuation,         -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5C),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5D),    UnicodeCategory.ClosePunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5E),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x5F),    UnicodeCategory.ConnectorPunctuation,    -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x60),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x61),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x62),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x63),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x64),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x65),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x66),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x67),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x68),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x69),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6A),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6B),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6C),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6D),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6E),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x6F),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x70),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x71),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x72),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x73),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x74),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x75),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x76),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x77),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x78),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x79),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7A),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7B),    UnicodeCategory.OpenPunctuation,         -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7C),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7D),    UnicodeCategory.ClosePunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7E),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x7F),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x80),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x81),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x82),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x83),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x84),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x85),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x86),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x87),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x88),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x89),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8A),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8B),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8C),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8D),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8E),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x8F),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x90),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x91),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x92),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x93),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x94),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x95),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x96),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x97),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x98),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x99),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9A),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9B),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9C),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9D),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9E),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x9F),    UnicodeCategory.Control,                 -1.0, true, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA0),    UnicodeCategory.SpaceSeparator,          -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0xA1),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA2),    UnicodeCategory.CurrencySymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA3),    UnicodeCategory.CurrencySymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA4),    UnicodeCategory.CurrencySymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA5),    UnicodeCategory.CurrencySymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA6),    UnicodeCategory.OtherSymbol,             -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA7),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA8),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xA9),    UnicodeCategory.OtherSymbol,             -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAA),    UnicodeCategory.OtherLetter,             -1.0, false, false, true, true, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAB),    UnicodeCategory.InitialQuotePunctuation, -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAC),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAD),    UnicodeCategory.Format,                  -1.0, false, false, false, false, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAE),    UnicodeCategory.OtherSymbol,             -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xAF),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB0),    UnicodeCategory.OtherSymbol,             -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB1),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB2),    UnicodeCategory.OtherNumber,             2.0, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB3),    UnicodeCategory.OtherNumber,             3.0, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB4),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB5),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB6),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB7),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB8),    UnicodeCategory.ModifierSymbol,          -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xB9),    UnicodeCategory.OtherNumber,             1.0, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBA),    UnicodeCategory.OtherLetter,             -1.0, false, false, true, true, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBB),    UnicodeCategory.FinalQuotePunctuation,   -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBC),    UnicodeCategory.OtherNumber,             0.25, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBD),    UnicodeCategory.OtherNumber,             0.5, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBE),    UnicodeCategory.OtherNumber,             0.75, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xBF),    UnicodeCategory.OtherPunctuation,        -1.0, false, false, false, false, false, false, true, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC0),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC1),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC2),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC3),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC4),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC5),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC6),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC7),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC8),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xC9),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCA),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCB),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCC),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCD),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCE),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xCF),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD0),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD1),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD2),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD3),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD4),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD5),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD6),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD7),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD8),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xD9),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDA),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDB),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDC),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDD),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDE),    UnicodeCategory.UppercaseLetter,         -1.0, false, false, true, true, false, false, false, false, false, true, false) |]
        yield [| UnicodeInfoTestData(Rune(0xDF),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE0),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE1),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE2),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE3),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE4),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE5),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE6),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE7),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE8),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xE9),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xEA),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xEB),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xEC),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xED),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xEE),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xEF),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF0),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF1),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF2),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF3),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF4),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF5),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF6),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF7),    UnicodeCategory.MathSymbol,              -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF8),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xF9),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFA),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFB),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFC),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFD),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFE),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFF),    UnicodeCategory.LowercaseLetter,         -1.0, false, false, true, true, true, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x2000),  UnicodeCategory.SpaceSeparator,          -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x2028),  UnicodeCategory.LineSeparator,           -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x2029),  UnicodeCategory.ParagraphSeparator,      -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x202F),  UnicodeCategory.SpaceSeparator,          -1.0, false, false, false, false, false, false, false, true, false, false, true) |]
        yield [| UnicodeInfoTestData(Rune(0x2154),  UnicodeCategory.OtherNumber,        2.0 / 3.0, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0xFFFD),  UnicodeCategory.OtherSymbol,             -1.0, false, false, false, false, false, false, false, false, true, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x10000), UnicodeCategory.OtherLetter,             -1.0, false, false, true, true, false, false, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x10110), UnicodeCategory.OtherNumber,             10.0, false, false, false, false, false, true, false, false, false, false, false) |]
        yield [| UnicodeInfoTestData(Rune(0x10177), UnicodeCategory.OtherNumber,        2.0 / 3.0, false, false, false, false, false, true, false, false, false, false, false) |] }

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

    //This has to exist so that an empty array can be checked against. Due to a limitation of F#, an empty array of a specific type can't be put into an attribute expecting a constant expression.
    [<TestMethod>]
    member _.``DecodeFromUtf16 - empty`` () =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(OperationStatus.NeedMoreData, Rune.DecodeFromUtf16(ReadOnlySpan<Char>(Array.zeroCreate<Char> 0), &rune, &cons))
        Assert.AreEqual(0xFFFD, rune.Value)
        Assert.AreEqual(0, cons)

    [<DataTestMethod>]
    [<DataRow([| '\u1234' |], OperationStatus.Done, 0x1234, 1)>]
    [<DataRow([| '\u1234'; '\uD800' |], OperationStatus.Done, 0x1234, 1)>]
    [<DataRow([| '\uD83D'; '\uDE32' |], OperationStatus.Done, 0x01F632, 2)>]
    [<DataRow([| '\uDC00' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| '\uDC00'; '\uDC00' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| '\uD800' |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| '\uD800'; '\uD800' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| '\uD800'; '\u1234' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    member _.``DecodeFromUtf16`` (data:char[], expOpStat:OperationStatus, expRune:int, expCharCons:int) =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(expOpStat, Rune.DecodeFromUtf16(ReadOnlySpan<Char>(data), &rune, &cons))
        Assert.AreEqual(expRune, rune.Value)
        Assert.AreEqual(expCharCons, cons)

    //This has to exist so that an empty array can be checked against. Due to a limitation of F#, an empty array of a specific type can't be put into an attribute expecting a constant expression.
    [<TestMethod>]
    member _.``DecodeLastFromUtf16 - empty`` () =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(OperationStatus.NeedMoreData, Rune.DecodeLastFromUtf16(ReadOnlySpan<Char>(Array.zeroCreate<Char> 0), &rune, &cons))
        Assert.AreEqual(0xFFFD, rune.Value)
        Assert.AreEqual(0, cons)

    [<DataTestMethod>]
    [<DataRow([| '\u1234'; '\u5678' |], OperationStatus.Done, 0x5678, 1)>]
    [<DataRow([| '\uDC00'; '\uD800' |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| '\uD83D'; '\uDE32' |], OperationStatus.Done, 0x1F632, 2)>]
    [<DataRow([| '\u1234'; '\uDC00' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| '\uDC00' |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    member _.``DecodeLastFromUtf16`` (data:char[], expOpStat:OperationStatus, expRune:int, expCharCons:int) =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(expOpStat, Rune.DecodeLastFromUtf16(ReadOnlySpan<Char>(data), &rune, &cons))
        Assert.AreEqual(expRune, rune.Value)
        Assert.AreEqual(expCharCons, cons)

    [<TestMethod>]
    member _.``DecodeFromUtf8 - empty`` () =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(OperationStatus.NeedMoreData, Rune.DecodeFromUtf8(ReadOnlySpan<Byte>(Array.zeroCreate<Byte> 0), &rune, &cons))
        Assert.AreEqual(0xFFFD, rune.Value)
        Assert.AreEqual(0, cons)

    [<DataTestMethod>]
    [<DataRow([| 0x30y |], OperationStatus.Done, 0x30, 1)>]
    [<DataRow([| 0x30y; 0x40y; 0x50y |], OperationStatus.Done, 0x30, 1)>]
    [<DataRow([| 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0x80y; 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xC1y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xF5y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xC2y |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| 0xEDy |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| 0xF4y |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| 0xC2y; 0xC2y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xC3y; 0x90y |], OperationStatus.Done, 0xD0, 2)>]
    [<DataRow([| 0xC1y; 0xBFy |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xE0y; 0x9Fy |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xE0y; 0xA0y |], OperationStatus.NeedMoreData, 0xFFFD, 2)>]
    [<DataRow([| 0xEDy; 0x9Fy |], OperationStatus.NeedMoreData, 0xFFFD, 2)>]
    [<DataRow([| 0xEDy; 0xBFy |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xEEy; 0x80y |], OperationStatus.NeedMoreData, 0xFFFD, 2)>]
    [<DataRow([| 0xF0y; 0x8Fy |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xF0y; 0x90y |], OperationStatus.NeedMoreData, 0xFFFD, 2)>]
    [<DataRow([| 0xF4y; 0x90y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xE2y; 0x88y; 0xB4y |], OperationStatus.Done, 0x2234, 3)>]
    [<DataRow([| 0xE2y; 0x88y; 0xC0y |], OperationStatus.InvalidData, 0xFFFD, 2)>]
    [<DataRow([| 0xF0y; 0x9Fy; 0x98y |], OperationStatus.NeedMoreData, 0xFFFD, 3)>]
    [<DataRow([| 0xF0y; 0x9Fy; 0x98y; 0x20y |], OperationStatus.InvalidData, 0xFFFD, 3)>]
    [<DataRow([| 0xF0y; 0x9Fy; 0x98y; 0xB2y |], OperationStatus.Done, 0x1F632, 4)>]
    member _.``DecodeFromUtf8`` (data:byte[], expOpStat:OperationStatus, expRune:int, expByteCons:int) =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(expOpStat, Rune.DecodeFromUtf8(ReadOnlySpan<Byte>(data), &rune, &cons))
        Assert.AreEqual(expRune, rune.Value)
        Assert.AreEqual(expByteCons, cons)

    [<TestMethod>]
    member _.``DecodeLastFromUtf8 - empty`` () =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(OperationStatus.NeedMoreData, Rune.DecodeLastFromUtf8(ReadOnlySpan<Byte>(Array.zeroCreate<Byte> 0), &rune, &cons))
        Assert.AreEqual(0xFFFD, rune.Value)
        Assert.AreEqual(0, cons)

    [<DataTestMethod>]
    [<DataRow([| 0x30y |], OperationStatus.Done, 0x30, 1)>]
    [<DataRow([| 0x30y; 0x40y; 0x50y |], OperationStatus.Done, 0x50, 1)>]
    [<DataRow([| 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0x80y; 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0x80y; 0x80y; 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0x80y; 0x80y; 0xC2y |], OperationStatus.NeedMoreData, 0xFFFD, 1)>]
    [<DataRow([| 0xC1y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0xE2y; 0x88y; 0xB4y |], OperationStatus.Done, 0x2234, 3)>]
    [<DataRow([| 0xF0y; 0x9Fy; 0x98y; 0xB2y |], OperationStatus.Done, 0x1F632, 4)>]
    [<DataRow([| 0xE2y; 0x88y; 0xB4y; 0xB2y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0x80y; 0x62y; 0x80y; 0x80y |], OperationStatus.InvalidData, 0xFFFD, 1)>]
    [<DataRow([| 0xF0y; 0x9Fy; 0x98y |], OperationStatus.NeedMoreData, 0xFFFD, 3)>]
    member _.``DecodeLastFromUtf8`` (data:byte[], expOpStat:OperationStatus, expRune:int, expByteCons:int) =
        let mutable rune = Rune(0x00)
        let mutable cons = 0
        Assert.AreEqual(expOpStat, Rune.DecodeLastFromUtf8(ReadOnlySpan<Byte>(data), &rune, &cons))
        Assert.AreEqual(expRune, rune.Value)
        Assert.AreEqual(expByteCons, cons)

    [<DataTestMethod>]
    [<DataRow(true, 0, 0)>]
    [<DataRow(true, 0x10FFFF, 0x10FFFF)>]
    [<DataRow(true, 0xFFFD, 0xFFFD)>]
    [<DataRow(false, 0xFFFD, 0xFFFF)>]
    [<DataRow(true, 'a', 'a')>]
    [<DataRow(false, 'a', 'A')>]
    [<DataRow(false, 'a', 'b')>]
    member _.``Equals_OperatorEqual_OperatorNotEqual`` (exp:bool, first:int32, second:int32) =
        let a = Rune(first)
        let b = Rune(second)
        Assert.AreEqual(exp, Object.Equals(a, b))
        Assert.AreEqual(exp, a.Equals(b))
        Assert.AreEqual(exp, a.Equals(b :> obj))
        Assert.AreEqual(exp, (a = b))
        Assert.AreNotEqual(exp, a <> b)

    [<DataTestMethod>]
    [<DataRow(0)>]
    [<DataRow('a')>]
    [<DataRow('\uFFFD')>]
    [<DataRow(0x10FFFF)>]
    member _.``GetHashCode`` (value:int) = Assert.AreEqual(value, Rune(value).GetHashCode())

    [<DataTestMethod>]
    [<DataRow('a', "a", 0)>]
    [<DataRow('b', "ab", 1)>]
    [<DataRow('y', "x\U0001F46Ey", 3)>]
    [<DataRow(0x1F46E, "x\U0001F46Ey", 1)>]
    member _.``GetRuneAt_TryGetRuneAt_Utf16_Success`` (exp:int, input:string, index:int) =
        Assert.AreEqual(exp, Rune.GetRuneAt(input, index).Value)

        let mutable rune = Rune(0x00)
        Assert.IsTrue(Rune.TryGetRuneAt(input, index, &rune))
        Assert.AreEqual(exp, rune.Value)

    [<DataTestMethod>]
    [<DataRow([| 'x'; '\uD83D'; '\uDC6E'; 'y' |], 2)>]
    [<DataRow([| 'x'; '\uD800'; 'y' |], 1)>]
    [<DataRow([| 'x'; '\uDFFF'; '\uDFFF' |], 1)>]
    [<DataRow([| 'x'; '\uD800' |], 1)>]
    member _.``GetRuneAt_TryGetRuneAt_Utf16_InvalidData`` (input:char[], index:int) =
        let inpt = String(input)

        Assert.ThrowsException<ArgumentException>(fun () -> Rune.GetRuneAt(inpt, index) |> ignore) |> ignore

        let mutable rune = Rune(0x00)
        Assert.IsFalse(Rune.TryGetRuneAt(inpt, index, &rune))
        Assert.AreEqual(0, rune.Value)

    [<TestMethod>]
    member _.``GetRuneAt_TryGetRuneAt_Utf16_BadArgs`` () =
        Assert.ThrowsException<ArgumentNullException>(fun () -> Rune.GetRuneAt(null, 0) |> ignore) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune.GetRuneAt("hello", -1) |> ignore) |> ignore
        Assert.ThrowsException<ArgumentOutOfRangeException>(fun () -> Rune.GetRuneAt(String.Empty, 0) |> ignore) |> ignore

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``GetNumericValue`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.NumericValue, Rune.GetNumericValue(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``GetUnicodeCategory`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.UnicodeCategory, Rune.GetUnicodeCategory(data.ScalarValue))

    [<TestMethod>]
    member _.``GetUnicodeCategory_AllInputs`` () =
        // This tests calls Rune.GetUnicodeCategory for every possible input, ensuring that
        // the runtime agrees with the data in the core Unicode files.
        for rune in RuneTests.AllRunes() do
            if UnicodeData.GetUnicodeCategory(uint32 rune.Value) <> Rune.GetUnicodeCategory(rune) then
                // We'll build up the exception message ourselves so the dev knows what code point failed.
                raise(AssertFailedException("Rune.GetUnicodeCategory(U+" + rune.Value.ToString("X4") + ") returned wrong category: " + Rune.GetUnicodeCategory(rune).ToString() + ", but should have been: " + UnicodeData.GetUnicodeCategory(uint32 rune.Value).ToString() + "."))
            else
                ()

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsControl`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsControl, Rune.IsControl(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsDigit`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsDigit, Rune.IsDigit(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsLetter`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsLetter, Rune.IsLetter(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsLetterOrDigit`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsLetterOrDigit, Rune.IsLetterOrDigit(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsLower`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsLower, Rune.IsLower(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsNumber``(data:UnicodeInfoTestData) = Assert.AreEqual(data.IsNumber, Rune.IsNumber(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsPunctuation`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsPunctuation, Rune.IsPunctuation(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsSeparator`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsSeparator, Rune.IsSeparator(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsSymbol`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsSymbol, Rune.IsSymbol(data.ScalarValue))

    [<DataTestMethod>]
    [<DynamicData("UnicodeInfoTestData_Latin1AndSelectOthers", DynamicDataSourceType.Method)>]
    member _.``IsUpper`` (data:UnicodeInfoTestData) = Assert.AreEqual(data.IsUpper, Rune.IsUpper(data.ScalarValue))