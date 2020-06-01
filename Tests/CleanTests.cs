using System;
using System.Text;
using Stringier;
using Xunit;

namespace Tests {
	public class CleanTests {
		[Theory]
		[InlineData("hello world", "hello world")]
		[InlineData("hello  world", "hello world")]
		[InlineData(" hello  world ", "hello world")]
		public void Clean(String source, String expected) => Assert.Equal(expected, source.Clean());

		[Theory]
		[InlineData("hellooo world", 'o', "hello world")]
		public void Clean_Char(String source, Char @char, String expected) => Assert.Equal(expected, source.Clean(@char));

		[Theory]
		[InlineData("𝄞𝄞𝄞𝄞", 0x1D11E, "𝄞")]
		[InlineData("𝄞𝄞abcdefg𝄞𝄞", 0x1D11E, "𝄞abcdefg𝄞")]
		public void Clean_Rune(String source, Int32 scalarValue, String expected) => Assert.Equal(expected, source.Clean(new Rune(scalarValue)));
	}
}
