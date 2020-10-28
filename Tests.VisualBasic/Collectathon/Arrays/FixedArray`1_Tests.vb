Imports Collectathon.Arrays
Imports Philosoft
Imports Xunit

Namespace Collectathon.Arrays
	Public Class FixedArray1_Tests
		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Clone(Array As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			Dim Clone = FA.Clone()
			Assert.Equal(Array, FA)
			Assert.Equal(Array, Clone)
			Assert.Equal(FA, Clone)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 0, False)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 3, True)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 5, True)>
		Public Sub Contains(Array As Int32(), Item As Int32, Expected As Boolean)
			Dim FA As FixedArray(Of Int32) = Array
			Assert.Equal(Expected, FA.Contains(Item))
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Enumerator(Array As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			Dim A = 0
			For Each Item As Int32 In FA
				Assert.Equal(Array(A), Item)
				A += 1
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 15, 120)>
		Public Sub Fold(Array As Int32(), AddExpected As Int32, MultExpected As Int32)
			Dim FA As FixedArray(Of Int32) = Array
			Assert.Equal(AddExpected, FA.Fold(Function(l, r) l + r, 0))
			Assert.Equal(MultExpected, FA.Fold(Function(l, r) l * r, 1))
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 0, -1)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 3, 2)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 5, 4)>
		Public Sub IndexOf(Array As Int32(), Item As Int32, Expected As Int64)
			Dim FA As FixedArray(Of Int32) = Array
			Assert.Equal(Expected, FA.IndexOf(Item))
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, New Int32() {2, 4, 6, 8, 10})>
		Public Sub Map(Array As Int32(), Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.Map(Function(x) x * 2)
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 2, 4)>
		Public Sub Range(Array As Int32(), Start As Int32, [End] As Int32)
			Dim FA As FixedArray(Of Int32) = Array
			Dim Memory As Memory(Of Int32) = FA(New Range(Start, [End]))
			Dim A = Start
			For Each Item As Int32 In Memory.Span
				Assert.Equal(Array(A), Item)
				A += 1
			Next
			Assert.Equal([End], A)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 2, 4, New Int32() {1, 4, 3, 4, 5})>
		Public Sub Replace(Array As Int32(), OldItem As Int32, NewItem As Int32, Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.Replace(OldItem, NewItem)
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, New Int32() {2, 3, 4, 5, 0})>
		Public Sub ShiftLeft(Array As Int32(), Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.ShiftLeft()
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 1, New Int32() {2, 3, 4, 5, 0})>
		Public Sub ShiftLeftBy(Array As Int32(), Amount As Int32, Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.ShiftLeft(Amount)
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, New Int32() {0, 1, 2, 3, 4})>
		Public Sub ShiftRight(Array As Int32(), Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.ShiftRight()
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 1, New Int32() {0, 1, 2, 3, 4})>
		Public Sub ShiftRightBy(Array As Int32(), Amount As Int32, Expected As Int32())
			Dim FA As FixedArray(Of Int32) = Array
			FA.ShiftRight(Amount)
			Assert.Equal(Expected, FA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 2, 2)>
		Public Sub Slice(Array As Int32(), Start As Int32, Length As Int32)
			Dim FA As FixedArray(Of Int32) = Array
			Dim Memory = FA.Slice(Start, Length)
			Dim A = Start
			For Each Item As Int32 In Memory.Span
				Assert.Equal(Array(A), Item)
				A += 1
			Next
			Assert.Equal(Start + Length, A)
		End Sub
	End Class
End Namespace
