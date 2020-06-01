using System;
using System.Text;
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
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, '-', "a-b-c-d")]
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, 0x1D11E, "a𝄞b𝄞c𝄞d")]
		public void Join_CharArray_WithRune(Char[] source, Int32 joinSV, String expected) {
			Rune rune = new Rune(joinSV);
			String joined = source.Join(rune);
			Assert.Equal(expected, joined);
		}

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Kebab", "Case" }, '-',  "This-Winds-Up-Kebab-Case")]
		public void Join_StringArray_WithChar(String[] source, Char joinChar, String expected) => Assert.Equal(expected, source.Join(joinChar));

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Kebab", "Case" }, '-', "This-Winds-Up-Kebab-Case")]
		[InlineData(new[] { "This", "Winds", "Up", "Oddly", "Cased" }, 0x1D11E, "This𝄞Winds𝄞Up𝄞Oddly𝄞Cased")]
		public void Join_StringArray_WithRune(String[] source, Int32 joinSV, String expected) {
			Rune rune = new Rune(joinSV);
			String joined = source.Join(rune);
			Assert.Equal(expected, joined);
		}
	}
}
