Imports System.Text

''' <summary>
''' Provides generators for gibberish
''' </summary>
Public Module Gibberish
	Private ReadOnly Random As Random = New Random()

	''' <summary>
	''' Generate gibberish.
	''' </summary>
	''' <param name="size">The size of the gibberish.</param>
	''' <returns>An <see cref="Array"/> of UTF-8 gibberish.</returns>
	Public Function GenerateUTF8(ByVal size As Int32) As Byte()
		Dim result = New Byte(size) {}
		Random.NextBytes(result)
		Return result
	End Function

	''' <summary>
	''' Generate gibberish.
	''' </summary>
	''' <param name="size">The size of the gibberish.</param>
	''' <returns>An <see cref="Array"/> of UTF-16 gibberish.</returns>
	Public Function GenerateUTF16(ByVal size As Int32) As Char()
		Dim result = New Char(size) {}
		For i = 0 To size
			result(i) = ChrW(Random.Next() Mod UInt16.MaxValue)
		Next
		Return result
	End Function

	''' <summary>
	''' Generate gibberish.
	''' </summary>
	''' <param name="size">The size of the gibberish.</param>
	''' <returns>An <see cref="Array"/> of UTF-32 gibberish.</returns>
	Public Function GenerateUTF32(ByVal size As Int32) As Rune()
		Dim result = New Rune(size) {}
		For i = 0 To size
			Dim value = Random.Next()
			If value >= &H10FFFF Then
				value = value Mod &H10FFFF
			End If
			If &HD800 <= value AndAlso value <= &HDFFF Then
				value -= &HD800
			End If
			result(i) = New Rune(value)
		Next
		Return result
	End Function
End Module
