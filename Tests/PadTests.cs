using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class PadTests : Trial {
		[Theory]
		[InlineData("hello", 0, "hello")]
		[InlineData("hello", 5, "hello")]
		[InlineData("hello", 10, "  hello   ")]
		public void Pad(String source, Int32 width, String expected) => Claim.That(source.Pad(width)).Equals(expected);

		[Theory]
		[InlineData("hello", 0, '-', "hello")]
		[InlineData("hello", 5, '-', "hello")]
		[InlineData("hello", 10, '-', "--hello---")]
		public void Pad_WithChar(String source, Int32 width, Char paddingChar, String expected) => Claim.That(source.Pad(width, paddingChar)).Equals(expected);
	}
}
