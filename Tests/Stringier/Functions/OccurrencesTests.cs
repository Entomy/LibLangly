using System;
using Xunit;

namespace Langly {
	public class OccurrencesTests {
		[Theory]
		[InlineData("hello", 'o', 1)]
		[InlineData("hello", 'l', 2)]
		[InlineData("hello", '?', 0)]
		public void Occurrences_String_Char(String source, Char charToCount, Int32 expected) => Assert.Equal(expected, Text.Occurrences(source, charToCount));

		[Theory]
		[InlineData("hello", new[] { 'e', 'o' }, 2)]
		[InlineData("hello", new[] { 'l', '?' }, 2)]
		public void Occurrences_String_CharArray(String source, Char[] charsToCount, Int32 expected) => Assert.Equal(expected, Text.Occurrences(source, charsToCount));
	}
}
