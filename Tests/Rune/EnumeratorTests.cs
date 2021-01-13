using System.Collections.Generic;
using Xunit;

namespace System.Text.Tests {
	public static class EnumeratorTests {
		[Theory]
		[InlineData("hello", new Int32[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f })]
		[InlineData("𝄞𝄋𝅘𝅥𝅯", new Int32[] { 0x01D11E, 0x01D10B, 0x01D161 })]
		public static void String_Enumerator(String @string, Int32[] enumVals) {
			Int32 i = 0;
			foreach (Rune rune in @string.EnumerateRunes()) {
				Assert.Equal(enumVals[i++], rune.Value);
			}
			Assert.Equal(enumVals.Length, i);
		}

		[Theory]
		[InlineData("hello", new Int32[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f })]
		[InlineData("𝄞𝄋𝅘𝅥𝅯", new Int32[] { 0x01D11E, 0x01D10B, 0x01D161 })]
		public static void Span_Enumerator(String @string, Int32[] enumVals) {
			Int32 i = 0;
			foreach (Rune rune in @string.AsSpan().EnumerateRunes()) {
				Assert.Equal(enumVals[i++], rune.Value);
			}
			Assert.Equal(enumVals.Length, i);
		}

		[Theory]
		[InlineData("hello", new Int32[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f })]
		[InlineData("𝄞𝄋𝅘𝅥𝅯", new Int32[] { 0x01D11E, 0x01D10B, 0x01D161 })]
		public static void Sequence_Enumerator(IEnumerable<Char> sequence, Int32[] enumVals) {
			Int32 i = 0;
			foreach (Rune rune in sequence.EnumerateRunes()) {
				Assert.Equal(enumVals[i++], rune.Value);
			}
			Assert.Equal(enumVals.Length, i);
		}
	}
}
