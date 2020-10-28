Imports Collectathon
Imports Collectathon.Lists
Imports Philosoft
Imports Xunit
Imports Xunit.Sdk

Namespace Collectathon.Lists
	Public Class DoublyLinkedList_1_Tests
		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Clear(Array As Int32())
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			Assert.Equal(Array.Length, List.Count)
			List.Clear()
			Assert.Equal(0, List.Count)
			For Each Item As Int32 In List
				'If this executes at all, the enumerator found elements even though the length was properly cleared.
				Throw New FalseException("", Nothing)
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 0, False)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 3, True)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 5, True)>
		Public Sub Contains(Array As Int32(), Item As Int32, Expected As Boolean)
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			Assert.Equal(Expected, List.Contains(Item))
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Enumerator(Array As Int32())
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			Dim A = 0
			For Each Item As Int32 In List
				Assert.Equal(Array(A), Item)
				A += 1
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 0, -1)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 3, 2)>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 5, 4)>
		Public Sub IndexOf(Array As Int32(), Item As Int32, Expected As Int64)
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			Assert.Equal(Expected, List.IndexOf(Item))
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3}, 0, 0, New Int32() {0, 1, 2, 3})>
		<InlineData(New Int32() {1, 2, 3}, 1, 0, New Int32() {1, 0, 2, 3})>
		<InlineData(New Int32() {1, 2, 3}, 2, 0, New Int32() {1, 2, 0, 3})>
		<InlineData(New Int32() {1, 2, 3}, 3, 0, New Int32() {1, 2, 3, 0})>
		Public Sub Insert(Array As Int32(), Index As Int32, Element As Int32, Expected As Int32())
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			List.Insert(Index, Element)
			Assert.Equal(Expected, List)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Queue(Array As Int32())
			Dim Queue = New DoublyLinkedList(Of Int32)
			Queue.Enqueue(Array)
			Assert.Equal(Array.Length, Queue.Count)
			For A = 0 To Array.Length - 1
				Assert.Equal(Array(A), Queue.Dequeue())
			Next
		End Sub

		<Theory>
		<InlineData(New Int32() {0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0}, 0, New Int32() {1, 2, 3, 4, 5})>
		Public Sub Remove_Element(Array As Int32(), Item As Int32, Expected As Int32())
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			Assert.Equal(Array.Length, List.Count)
			List.Remove(Item)
			Assert.Equal(Expected, List)
		End Sub

		<Fact>
		Public Sub Remove_Delegate()
			Dim List = New DoublyLinkedList(Of Int32) From {1, 2, 3, 4, 5, 6, 7, 8, 9}
			List.Remove(Function(x) x Mod 2 <> 0)
			Assert.Equal(New Int32() {2, 4, 6, 8}, List)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5}, 2, 4, New Int32() {1, 4, 3, 4, 5})>
		Public Sub Replace(Array As Int32(), OldItem As Int32, NewItem As Int32, Expected As Int32())
			Dim List = New DoublyLinkedList(Of Int32) From {Array}
			List.Replace(OldItem, NewItem)
			Assert.Equal(Expected, List)
		End Sub

		<Theory>
		<InlineData(New Int32() {1, 2, 3, 4, 5})>
		Public Sub Stack(Array As Int32())
			Dim Stack = New DoublyLinkedList(Of Int32)
			Stack.Push(Array)
			Assert.Equal(Array.Length, Stack.Count)
			For A = Array.Length - 1 To 0 Step -1
				Assert.Equal(Array(A), Stack.Pop())
			Next
		End Sub

		<Fact>
		Public Sub Unique()
			Dim List = New DoublyLinkedList(Of Int32)(Filter.Unique)
			List.Add(1)
			Assert.Equal(1, List.Count)
			Assert.Equal(1, List(0))
			List.Add(1, 2, 3)
			Assert.Equal(3, List.Count)
			Assert.Equal(1, List(0))
			Assert.Equal(2, List(1))
			Assert.Equal(3, List(2))
		End Sub

	End Class
End Namespace

