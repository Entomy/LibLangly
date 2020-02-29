using System;
using Stringier;
using Xunit;

namespace Tests {
	public class WordsTests {
		[Theory]
		[InlineData("", new[] { "" })]
		[InlineData("Hello world", new[] { "Hello", "world" })]
		public void Words(String source, String[] expected) => Assert.Equal(expected, source.Words());
	}
}
