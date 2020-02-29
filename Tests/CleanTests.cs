using System;
using Stringier;
using Xunit;

namespace Tests {
	public class CleanTests {
		[Theory]
		[InlineData("hello world", "hello world")]
		[InlineData("hello world", "hello  world")]
		[InlineData("hello world", " hello  world ")]
		public void Clean(String expected, String source) => Assert.Equal(expected, source.Clean());

		[Theory]
		[InlineData("hello world", "hellooo world", 'o')]
		public void Clean_Char(String expected, String source, Char @char) => Assert.Equal(expected, source.Clean(@char));
	}
}
