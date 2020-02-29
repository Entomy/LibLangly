using System;
using Stringier;
using Xunit;

namespace Tests {
	public class ChopTests {
		[Theory]
		[InlineData(new[] { "h", "e", "l", "l", "o", " ", "w", "o", "r", "l", "d" }, "hello world", 1)]
		[InlineData(new[] { "he", "ll", "o ", "wo", "rl", "d" }, "hello world", 2)]
		[InlineData(new[] { "hel", "lo ", "wor", "ld" }, "hello world", 3)]
		[InlineData(new[] { "hell", "o wo", "rld"}, "hello world", 4)]
		[InlineData(new[] { "hello", " worl", "d" }, "hello world", 5)]
		[InlineData(new[] { "hello ", "world" }, "hello world", 6)]
		[InlineData(new[] { "hello w", "orld" }, "hello world", 7)]
		[InlineData(new[] { "hello wo", "rld" }, "hello world", 8)]
		[InlineData(new[] { "hello wor", "ld" }, "hello world", 9)]
		[InlineData(new[] { "hello worl", "d" }, "hello world", 10)]
		[InlineData(new[] { "hello world" }, "hello world", 11)]
		[InlineData(new[] { "hello world" }, "hello world", 12)]
		public void Chop(String[] expected, String text, Int32 size) => Assert.Equal(expected, text.Chop(size));

		[Fact]
		public void Chop_Invalid() => Assert.Throws<ArgumentOutOfRangeException>(() => "hello world".Chop(0));
	}
}
