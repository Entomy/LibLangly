Imports System
Imports System.IO

Public Module Gibberish
	Public Function Generate(ReductionFactor As Int32, Optional Bad As Boolean = False) As String
		Dim Random As Random = New Random()
		Dim Pool As Char() = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
		Dim Builder As StringBuilder = New StringBuilder()
		For i = 0 To Int32.MaxValue / ReductionFactor
			If Bad AndAlso i = Int32.MaxValue / ReductionFactor - 2 Then
				Builder.Append("/")
			Else
				Builder.Append(Pool(Random.Next() Mod Pool.Length))
			End If
		Next
		Return Builder.ToString
	End Function
End Module
