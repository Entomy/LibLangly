Imports Generators
Imports System
Imports System.Diagnostics.CodeAnalysis
Imports System.Text
Imports Stringier.Encodings
Imports Xunit

Namespace Stringier.Encodings
    Public Class UTF16Tests
        <Theory>
        <InlineData(&H0, &H0)>
        <InlineData(&H41, &H41)>
        <InlineData(&H7F, &H7F)>
        <InlineData(&H80, &H80)>
        <InlineData(&HFF, &HFF)>
        Public Sub Decode_1(ByVal first As UInt16, ByVal expected As Int32)
            Assert.Equal(expected, UTF16.Decode(first).Value)
        End Sub

        <Theory>
        <InlineData(&HD834, &HDD1E, &H1D11E)>
        <InlineData(&HD834, &HDD3D, &H1D13D)>
        Public Sub Decode_2(ByVal first As UInt16, ByVal second As UInt16, ByVal expected As Int32)
            Assert.Equal(expected, UTF16.Decode(first, second).Value)
        End Sub

        <Theory>
        <InlineData(4096)>
        <InlineData(2048)>
        <InlineData(1024)>
        <InlineData(512)>
        <InlineData(256)>
        <InlineData(128)>
        <SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification:="We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")>
        Public Sub Decode_Gibberish(ByVal reductionFactor As Int32)
            Dim buffer As Char() = Gibberish.GenerateUTF16(reductionFactor)
            UTF16.Decode(buffer)
        End Sub

        <Theory>
        <InlineData(&H1D11E, New Char() {ChrW(55348), ChrW(56606)})>
        <InlineData(&H1D13D, New Char() {ChrW(55348), ChrW(56637)})>
        Public Sub Encode(ByVal scalarValue As UInt32, ByVal expected As Char())
            Assert.Equal(expected, UTF16.Encode(New Rune(scalarValue)).ToArray())
        End Sub

        <Theory>
        <InlineData(4096)>
        <InlineData(2048)>
        <InlineData(1024)>
        <InlineData(512)>
        <InlineData(256)>
        <InlineData(128)>
        <SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification:="We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")>
        Public Sub Encode_Gibberish(ByVal reductionFactor As Int32)
            Dim buffer As Rune() = Gibberish.GenerateUTF32(reductionFactor)
            UTF16.Encode(buffer)
        End Sub

        <Theory>
        <InlineData(&H0, True)>
        <InlineData(&HD7FF, True)>
        <InlineData(&HD800, True)>
        <InlineData(&HD801, True)>
        <InlineData(&HDBFE, True)>
        <InlineData(&HDBFF, True)>
        <InlineData(&HDC00, False)>
        <InlineData(&HDC01, False)>
        <InlineData(&HDFFE, False)>
        <InlineData(&HDFFF, False)>
        <InlineData(&HE000, True)>
        <InlineData(&HE001, True)>
        <InlineData(&HFFFF, True)>
        Public Sub IsFirstUnit(ByVal unit As UInt16, ByVal expected As Boolean)
            Assert.Equal(expected, UTF16.IsFirstUnit(unit))
        End Sub

        <Theory>
        <InlineData(&H0, &H0, &HFFFF)>
        <InlineData(&HD7FF, &H0, &HFFFF)>
        <InlineData(&HD800, &HDC00, &HDFFF)>
        <InlineData(&HD801, &HDC00, &HDFFF)>
        <InlineData(&HDBFE, &HDC00, &HDFFF)>
        <InlineData(&HDBFF, &HDC00, &HDFFF)>
        <InlineData(&HDC00, &H0, &HFFFF)>
        <InlineData(&HDC01, &H0, &HFFFF)>
        <InlineData(&HDFFE, &H0, &HFFFF)>
        <InlineData(&HDFFF, &H0, &HFFFF)>
        <InlineData(&HE000, &H0, &HFFFF)>
        <InlineData(&HE001, &H0, &HFFFF)>
        <InlineData(&HFFFF, &H0, &HFFFF)>
        Public Sub NextUnitRange(ByVal unit As UInt16, ByVal lowerExp As UInt16, ByVal upperExp As UInt16)
            Dim lower As UInt16 = Nothing, upper As UInt16 = Nothing
            UTF16.NextUnitRange(unit, lower, upper)
            Assert.Equal(lowerExp, lower)
            Assert.Equal(upperExp, upper)
        End Sub

        <Theory>
        <InlineData(&H0, 1)>
        <InlineData(&HD7FF, 1)>
        <InlineData(&HD800, 2)>
        <InlineData(&HD801, 2)>
        <InlineData(&HDBFE, 2)>
        <InlineData(&HDBFF, 2)>
        <InlineData(&HDC00, 0)>
        <InlineData(&HDC01, 0)>
        <InlineData(&HDFFE, 0)>
        <InlineData(&HDFFF, 0)>
        <InlineData(&HE000, 1)>
        <InlineData(&HE001, 1)>
        <InlineData(&HFFFF, 1)>
        Public Sub SequenceLength(ByVal unit As UInt16, ByVal expected As Int32)
            Assert.Equal(expected, UTF16.SequenceLength(unit))
        End Sub
    End Class
End Namespace
