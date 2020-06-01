using System;
using Stringier;
using Xunit;

namespace Tests {
	public class PadTests {
		[Theory]
		[InlineData("hello", 0, "hello")]
		[InlineData("hello", 5, "hello")]
		[InlineData("hello", 10, "  hello   ")]
		public void Pad(String source, Int32 width, String expected) => Assert.Equal(expected, source.Pad(width));

		[Theory]
		[InlineData("hello", 0, '-', "hello")]
		[InlineData("hello", 5, '-', "hello")]
		[InlineData("hello", 10, '-', "--hello---")]
		public void Pad_WithChar(String source, Int32 width, Char paddingChar, String expected) => Assert.Equal(expected, source.Pad(width, paddingChar));
	}
}
