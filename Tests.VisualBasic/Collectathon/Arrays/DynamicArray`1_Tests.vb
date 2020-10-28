Imports Collectathon
Imports Collectathon.Arrays
Imports Philosoft
Imports Xunit
Imports Xunit.Sdk

Namespace Collectathon.Arrays
	Public Class DynamicArray1_Tests
		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Clear(Array As Int32())
			Dim DA As DynamicArray(Of Int32) = Array
			Assert.Equal(Array.Length, DA.Length)
			DA.Clear()
			Assert.Equal(0, DA.Length)
			For Each Item As Int32 In DA
				'If this executes at all, the enumerator found elements even though the length was properly cleared.
				Throw New FalseException("", Nothing)
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3}, 0, 0, New Int32() {0, 1, 2, 3})>
		<InlineData(New Int32() {1, 2, 3}, 1, 0, New Int32() {1, 0, 2, 3})>
		<InlineData(New Int32() {1, 2, 3}, 2, 0, New Int32() {1, 2, 0, 3})>
		<InlineData(New Int32() {1, 2, 3}, 3, 0, New Int32() {1, 2, 3, 0})>
		Public Sub Insert(Array As Int32(), Index As Int32, Element As Int32, Expected As Int32())
			Dim DA As DynamicArray(Of Int32) = Array
			DA.Insert(Index, Element)
			Assert.Equal(Expected, DA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Queue(Array As Int32())
			Dim Queue As DynamicArray(Of Int32) = New DynamicArray(Of Int32)(0)
			Queue.Enqueue(Array)
			Assert.Equal(Array.Length, Queue.Length)
			For A = 0 To Array.Length - 1
				Assert.Equal(Array(A), Queue.Dequeue())
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0}, 0, New Int32() {1, 2, 3, 4, 5})>
		Public Sub Remove_Element(Array As Int32(), Item As Int32, Expected As Int32())
			Dim DA As DynamicArray(Of Int32) = Array
			Assert.Equal(Array.Length, DA.Length)
			DA.Remove(Item)
			Assert.Equal(Expected, DA)
		End Sub

		<Fact>
		Public Sub Remove_Delegate()
			Dim DA As DynamicArray(Of Int32) = New DynamicArray(Of Int32)(9) From {1, 2, 3, 4, 5, 6, 7, 8, 9}
			DA.Remove(Function(x) x Mod 2 <> 0)
			Assert.Equal(New Int32() {2, 4, 6, 8}, DA)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Stack(Array As Int32())
			Dim Stack As DynamicArray(Of Int32) = New DynamicArray(Of Int32)(0)
			Stack.Push(Array)
			Assert.Equal(Array.Length, Stack.Length)
			For A = Array.Length - 1 To 0 Step -1
				Assert.Equal(Array(A), Stack.Pop())
			Next
		End Sub

		<Fact>
		Public Sub Unique()
			Dim DA As DynamicArray(Of Int32) = New DynamicArray(Of Int32)(0, Filter.Unique)
			DA.Add(1)
			Assert.Equal(1, DA.Length)
			Assert.Equal(1, DA(0))
			DA.Add(1, 2, 3)
			Assert.Equal(3, DA.Length)
			Assert.Equal(1, DA(0))
			Assert.Equal(2, DA(1))
			Assert.Equal(3, DA(2))
		End Sub
	End Class
End Namespace
