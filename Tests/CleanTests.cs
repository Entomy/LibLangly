using System;
using System.Text;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class CleanTests : Trial {
		[Theory]
		[InlineData("hello world", "hello world")]
		[InlineData("hello  world", "hello world")]
		[InlineData(" hello  world ", "hello world")]
		public void Clean(String source, String expected) => Claim.That(source.Clean()).Equals(expected);

		[Theory]
		[InlineData("hellooo world", 'o', "hello world")]
		public void Clean_Char(String source, Char @char, String expected) => Claim.That(source.Clean(@char)).Equals(expected);

		[Theory]
		[InlineData("𝄞𝄞𝄞𝄞", 0x1D11E, "𝄞")]
		[InlineData("𝄞𝄞abcdefg𝄞𝄞", 0x1D11E, "𝄞abcdefg𝄞")]
		public void Clean_Rune(String source, Int32 scalarValue, String expected) => Claim.That(source.Clean(new Rune(scalarValue))).Equals(expected);
	}
}
