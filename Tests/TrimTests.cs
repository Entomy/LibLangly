using System;
using System.Text;
using Stringier;
using Xunit;

namespace Tests {
	public class TrimTests {
		[Theory]
		[InlineData("  hello  ", ' ', "hello")]
		[InlineData("𝄞𝄞hello𝄞𝄞", 0x1D11E, "hello")]
		public void Trim(String source, Int32 trimSV, String expected) => Assert.Equal(expected, source.Trim(new Rune(trimSV)));

		[Theory]
		[InlineData("hello  ", ' ', "hello")]
		[InlineData("hello𝄞𝄞", 0x1D11E, "hello")]
		public void TrimEnd(String source, Int32 trimSV, String expected) => Assert.Equal(expected, source.TrimEnd(new Rune(trimSV)));

		[Theory]
		[InlineData("  hello", ' ', "hello")]
		[InlineData("𝄞𝄞hello", 0x1D11E, "hello")]
		public void TrimStart(String source, Int32 trimSV, String expected) => Assert.Equal(expected, source.TrimStart(new Rune(trimSV)));
	}
}
