using System;
using Xunit;

namespace Stringier.Functions {
	public class ChopTests {
		[Theory]
		[InlineData("hello world", 1, new[] { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" })]
		[InlineData("hello world", 2, new[] { "he", "ll", "o ", "wo", "rl", "d" })]
		[InlineData("hello world", 3, new[] { "hel", "lo ", "wor", "ld" })]
		[InlineData("hello world", 4, new[] { "hell", "o wo", "rld" })]
		[InlineData("hello world", 5, new[] { "hello", " worl", "d" })]
		[InlineData("hello world", 6, new[] { "hello ", "world" })]
		[InlineData("hello world", 7, new[] { "hello w", "orld" })]
		[InlineData("hello world", 8, new[] { "hello wo", "rld" })]
		[InlineData("hello world", 9, new[] { "hello wor", "ld" })]
		[InlineData("hello world", 10, new[] { "hello worl", "d" })]
		[InlineData("hello world", 11, new[] { "hello world" })]
		[InlineData("hello world", 12, new[] { "hello world" })]
		public void Chop(String text, Int32 size, String[] expected) {
			Int32 i = 0;
			foreach (ReadOnlySpan<Char> chunk in Text.Chop(text, size)) {
				Assert.Equal(expected[i++], chunk.ToString());
			}
		}

		[Fact]
		public void Chop_Invalid() => Assert.ThrowsAny<Langly.ArgumentException>(() => Text.Chop("hello world", 0));
	}
}
