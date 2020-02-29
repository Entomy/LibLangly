using System;
using Stringier;
using Xunit;

namespace Tests {
	public class JoinTests {
		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, "abcd")]
		public void Join_CharArray(Char[] source, String expected) => Assert.Equal(expected, source.Join());

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Camel", "Case" }, "ThisWindsUpCamelCase")]
		public void Join_StringArray(String[] source, String expected) => Assert.Equal(expected, source.Join());

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, '-', "a-b-c-d")]
		public void Join_CharArray_WithChar(Char[] source, Char joinChar, String expected) => Assert.Equal(expected, source.Join(joinChar));

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Kebab", "Case" }, '-',  "This-Winds-Up-Kebab-Case")]
		public void Join_StringArray_WithChar(String[] source, Char joinChar, String expected) => Assert.Equal(expected, source.Join(joinChar));
	}
}
