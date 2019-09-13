Imports System
Imports System.IO

Module Program
	Sub Main()
		Dim Random As Random = New Random()
		Dim Pool As Char() = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
		Using Writer As TextWriter = New StreamWriter("gibberish.txt")
			For i = 0 To Int32.MaxValue / 4
				Writer.Write(Pool(Random.Next() Mod Pool.Length))
			Next
		End Using
	End Sub
End Module
