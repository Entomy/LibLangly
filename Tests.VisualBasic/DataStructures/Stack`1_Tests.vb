Imports Xunit

Namespace DataStructures
	Public Class Stack1_Tests
		<Theory>
		<MemberData(NameOf(Stack1_Data.Stack), MemberType:=GetType(Stack1_Data))>
		Public Sub Stack(expected As Int32(), values As Int32())
			Dim stack = New Stack(Of Int32)().Write(values)
			Assert.Equal(expected.Length, stack.Count)
			Assert.Equal(expected, stack)
			Dim vals As ReadOnlyMemory(Of Int32)
			Dim unused = stack.Read(expected.Length, vals)
			Assert.Equal(0, stack.Count)
			Assert.Equal(expected, vals.ToArray())
		End Sub
	End Class
End Namespace
