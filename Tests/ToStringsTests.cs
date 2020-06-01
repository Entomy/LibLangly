using System;
using Stringier;
using Xunit;

namespace Tests {
	public class ToStringsTests {
		[Theory]
		[InlineData(new Int32[] { 1, 2, 3 }, new[] { "1", "2", "3" })]
		public void ToStrings_Structs(Int32[] source, String[] expected) => Assert.Equal(expected, source.ToStrings());

		[Theory]
		[InlineData(new Object[] { }, new String[] { })]
		[InlineData(new Object[] { null }, new[] { "" })]
		[InlineData(new Object[] { 1, 2, null }, new[] { "1", "2", "" })]
		public void ToStrings_Classes(Object[] source, String[] expected) => Assert.Equal(expected, source.ToStrings(""));
	}
}
