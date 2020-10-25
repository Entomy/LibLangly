Imports Generators
Imports System
Imports System.Diagnostics.CodeAnalysis
Imports System.Text
Imports Stringier.Encodings
Imports Xunit

Namespace Stringier.Encodings
    Public Class UTF8Tests
        <Theory>
        <InlineData(&H0, &H0)>
        <InlineData(&H41, &H41)>
        <InlineData(&H7F, &H7F)>
        <InlineData(&H80, &HFFFD)>
        <InlineData(&HFF, &HFFFD)>
        Public Sub Decode_1(ByVal first As Byte, ByVal expected As Int32)
            Assert.Equal(expected, UTF8.Decode(first).Value)
        End Sub

        <Theory>
        <InlineData(&HC3, &H86, &HC6)>
        <InlineData(&HCE, &HB2, &H3B2)>
        Public Sub Decode_2(ByVal first As Byte, ByVal second As Byte, ByVal expected As Int32)
            Assert.Equal(expected, UTF8.Decode(first, second).Value)
        End Sub

        <Theory>
        <InlineData(&HE0, &HAE, &H87, &HB87)>
        <InlineData(&HE1, &H82, &HA7, &H10A7)>
        <InlineData(&HEA, &H9C, &HA8, &HA728)>
        Public Sub Decode_3(ByVal first As Byte, ByVal second As Byte, ByVal third As Byte, ByVal expected As Int32)
            Assert.Equal(expected, UTF8.Decode(first, second, third).Value)
        End Sub

        <Theory>
        <InlineData(&HF0, &H90, &H8C, &HB1, &H10331)>
        <InlineData(&HF0, &H9F, &H82, &HA1, &H1F0A1)>
        Public Sub Decode_4(ByVal first As Byte, ByVal second As Byte, ByVal third As Byte, ByVal fourth As Byte, ByVal expected As Int32)
            Assert.Equal(expected, UTF8.Decode(first, second, third, fourth).Value)
        End Sub

        <Theory>
        <InlineData(New Byte() {}, New Int32() {})>
        <InlineData(New Byte() {&H0}, New Int32() {&H0})>
        <InlineData(New Byte() {&H41, &H7F}, New Int32() {&H41, &H7F})>
        <InlineData(New Byte() {&H41, &HC3, &H86}, New Int32() {&H41, &HC6})>
        <InlineData(New Byte() {&HC3, &H86, &H41}, New Int32() {&HC6, &H41})>
        <InlineData(New Byte() {&HE0, &HAE, &H87}, New Int32() {&HB87})>
        <InlineData(New Byte() {&HE0, &HAE, &HE0}, New Int32() {&HFFFD})>
        Public Sub Decode_Buffer(ByVal bytes As Byte(), ByVal expected As Int32())
            Dim text As Rune() = New Rune(expected.Length - 1) {}

            For i As Int32 = 0 To text.Length - 1
                text(i) = New Rune(expected(i))
            Next

            Assert.Equal(text, UTF8.Decode(bytes).ToArray())
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
            Dim buffer As Byte() = Gibberish.GenerateUTF8(reductionFactor)
            UTF8.Decode(buffer)
        End Sub

        <Theory>
        <InlineData(&H41, New Byte() {&H41})>
        <InlineData(&HC6, New Byte() {&HC3, &H86})>
        <InlineData(&HB87, New Byte() {&HE0, &HAE, &H87})>
        <InlineData(&HA728, New Byte() {&HEA, &H9C, &HA8})>
        <InlineData(&H10331, New Byte() {&HF0, &H90, &H8C, &HB1})>
        <InlineData(&H1F0A1, New Byte() {&HF0, &H9F, &H82, &HA1})>
        Public Sub Encode(ByVal scalarValue As UInt32, ByVal expected As Byte())
            Assert.Equal(expected, UTF8.Encode(New Rune(scalarValue)).ToArray())
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
            UTF8.Encode(buffer)
        End Sub

        <Theory>
        <InlineData(&H0, True)>
        <InlineData(&H1, True)>
        <InlineData(&H7E, True)>
        <InlineData(&H7F, True)>
        <InlineData(&H80, False)>
        <InlineData(&H81, False)>
        <InlineData(&HC0, False)>
        <InlineData(&HC1, False)>
        <InlineData(&HC2, True)>
        <InlineData(&HF4, True)>
        <InlineData(&HF5, False)>
        <InlineData(&HF6, False)>
        <InlineData(&HFF, False)>
        Public Sub IsFirstByte(ByVal [Byte] As Byte, ByVal expected As Boolean)
            Assert.Equal(expected, UTF8.IsFirstByte([Byte]))
        End Sub

        <Theory>
        <InlineData(&H7F, &H80, &HBF)>
        <InlineData(&HDF, &H80, &HBF)>
        <InlineData(&HE0, &HA0, &HBF)>
        <InlineData(&HE1, &H80, &HBF)>
        <InlineData(&HEE, &H80, &HBF)>
        <InlineData(&HED, &H80, &H9F)>
        <InlineData(&HEF, &H80, &HBF)>
        <InlineData(&HF0, &H90, &HBF)>
        <InlineData(&HF1, &H80, &HBF)>
        <InlineData(&HF3, &H80, &HBF)>
        <InlineData(&HF4, &H80, &H8F)>
        <InlineData(&HF5, &H80, &HBF)>
        <InlineData(&HFF, &H80, &HBF)>
        Public Sub NextByteRange(ByVal [Byte] As Byte, ByVal lowerExp As Byte, ByVal upperExp As Byte)
            Dim lower As Byte = Nothing, upper As Byte = Nothing
            UTF8.NextByteRange([Byte], lower, upper)
            Assert.Equal(lowerExp, lower)
            Assert.Equal(upperExp, upper)
        End Sub

        <Theory>
        <InlineData(&H0, 1)>
        <InlineData(&H7F, 1)>
        <InlineData(&H80, 0)>
        <InlineData(&HC1, 0)>
        <InlineData(&HC2, 2)>
        <InlineData(&HDF, 2)>
        <InlineData(&HE0, 3)>
        <InlineData(&HE1, 3)>
        <InlineData(&HEE, 3)>
        <InlineData(&HEF, 3)>
        <InlineData(&HF0, 4)>
        <InlineData(&HF1, 4)>
        <InlineData(&HF3, 4)>
        <InlineData(&HF4, 4)>
        <InlineData(&HF5, 0)>
        <InlineData(&HF6, 0)>
        <InlineData(&HFF, 0)>
        Public Sub SequenceLength(ByVal [Byte] As Byte, ByVal expected As Int32)
            Assert.Equal(expected, UTF8.SequenceLength([Byte]))
        End Sub
    End Class
End Namespace
