Imports Defender
Imports Defender.Exceptions
Imports Xunit

Public Class GuardTests
	<Theory>
	<InlineData(1, 1, False)>
	<InlineData(1, 2, True)>
	<InlineData(2, 1, True)>
	<InlineData("a"c, "a"c, False)>
	<InlineData("a"c, "b"c, True)>
	<InlineData("b"c, "a"c, True)>
	<InlineData("hi", "hi", False)>
	<InlineData("hi", "no", True)>
	<InlineData("no", "hi", True)>
	Public Sub Equal(Of T)(Value As T, Other As T, Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentNotEqualException)(Sub() Guard.Equal(Value, "Value", Other))
		Else
			Guard.Equal(Value, "Value", Other)
		End If
	End Sub

	<Theory>
	<InlineData(0, 1, False)>
	<InlineData(1, 1, False)>
	<InlineData(2, 1, True)>
	Public Sub GreaterThan(Value As Integer, Lower As Integer, Throws As Boolean)
		If Throws Then
			Assert.ThrowsAny(Of ArgumentException)(Sub() Guard.GreaterThan(Value, "Value", Lower))
		Else
			Guard.GreaterThan(Value, "Value", Lower)
		End If
	End Sub

	<Theory>
	<InlineData(0, 1, True)>
	<InlineData(1, 1, False)>
	<InlineData(2, 1, False)>
	Public Sub LesserThan(Value As Integer, Upper As Integer, Throws As Boolean)
		If Throws Then
			Assert.ThrowsAny(Of ArgumentException)(Sub() Guard.LesserThan(Value, "Value", Upper))
		Else
			Guard.LesserThan(Value, "Value", Upper)
		End If
	End Sub

	<Theory>
	<InlineData(Nothing, True)>
	<InlineData(1, False)>
	<InlineData(1.5, True)>
	<InlineData("a"c, True)>
	<InlineData("hi", True)>
	Public Sub OfType(Value As Object, Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentNotTypeException)(Sub() Guard.OfType(Of Integer)(Value, "Value"))
		Else
			Guard.OfType(Of Integer)(Value, "Value")
		End If
	End Sub

	<Theory>
	<InlineData(New Integer() {}, True)>
	<InlineData(New Integer() {1, 2, 3}, False)>
	Public Sub NotEmpty(Value As Integer(), Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentEmptyException)(Sub() Guard.NotEmpty(Value, "Value"))
		Else
			Guard.NotEmpty(Value, "Value")
		End If
	End Sub

	<Theory>
	<InlineData("", False)>
	<InlineData(Nothing, True)>
	Public Sub NotNull(Value As String, Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentNullException)(Sub() Guard.NotNull(Value, "Value"))
		Else
			Guard.NotNull(Value, "Value")
		End If
	End Sub

	<Theory>
	<InlineData(-1, True)>
	<InlineData(0, False)>
	<InlineData(1, False)>
	<InlineData(15, False)>
	<InlineData(16, True)>
	Public Sub Valid(Value As Integer, Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentNotValidException)(Sub() Guard.Valid(CType(Value, ConsoleColor), "Value"))
		Else
			Guard.Valid(CType(Value, ConsoleColor), "Value")
		End If
	End Sub

	<Theory>
	<InlineData(0, 1, 5, True)>
	<InlineData(1, 1, 5, False)>
	<InlineData(2, 1, 5, False)>
	<InlineData(4, 1, 5, False)>
	<InlineData(5, 1, 5, False)>
	<InlineData(6, 1, 5, True)>
	Public Sub Within(Value As Integer, Lower As Integer, Upper As Integer, Throws As Boolean)
		If Throws Then
			Assert.Throws(Of ArgumentNotWithinException)(Sub() Guard.Within(Value, "Value", Lower, Upper))
		Else
			Guard.Within(Value, "Value", Lower, Upper)
		End If
	End Sub
End Class
