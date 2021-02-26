Imports Xunit
Imports Langly.DataStructures.Lists

Namespace Global.Langly
	Public Class NumericsTests
		<Theory>
		<MemberData(NameOf(NumericsData.Max_SByte), MemberType:=GetType(NumericsData))>
		Sub Max_SByte(expected As Single, values As SByte())
			Dim chain = New Chain(Of SByte)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Byte), MemberType:=GetType(NumericsData))>
		Sub Max_Byte(expected As Single, values As Byte())
			Dim chain = New Chain(Of Byte)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Int16), MemberType:=GetType(NumericsData))>
		Sub Max_Int16(expected As Single, values As Int16())
			Dim chain = New Chain(Of Int16)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_UInt16), MemberType:=GetType(NumericsData))>
		Sub Max_UInt16(expected As Single, values As UInt16())
			Dim chain = New Chain(Of UInt16)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Int32), MemberType:=GetType(NumericsData))>
		Sub Max_Int32(expected As Double, values As Int32())
			Dim chain = New Chain(Of Int32)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_UInt32), MemberType:=GetType(NumericsData))>
		Sub Max_UInt32(expected As Double, values As UInt32())
			Dim chain = New Chain(Of UInt32)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Int64), MemberType:=GetType(NumericsData))>
		Sub Max_Int64(expected As Double, values As Int64())
			Dim chain = New Chain(Of Int64)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_UInt64), MemberType:=GetType(NumericsData))>
		Sub Max_UInt64(expected As Double, values As UInt64())
			Dim chain = New Chain(Of UInt64)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Single), MemberType:=GetType(NumericsData))>
		Sub Max_Single(expected As Single, values As Single())
			Dim chain = New Chain(Of Single)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub

		<Theory>
		<MemberData(NameOf(NumericsData.Max_Double), MemberType:=GetType(NumericsData))>
		Sub Max_Double(expected As Double, values As Double())
			Dim chain = New Chain(Of Double)().Add(values)
			Assert.Equal(expected, chain.Max())
		End Sub
	End Class
End Namespace
