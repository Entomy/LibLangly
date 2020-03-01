using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class WordsTests : Trial {
		[Theory]
		[InlineData("", new[] { "" })]
		[InlineData("Hello world", new[] { "Hello", "world" })]
		public void Words(String source, String[] expected) => Claim.That(source.Words()).SequenceEquals(expected);
	}
}
