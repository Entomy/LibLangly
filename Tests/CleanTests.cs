using System;
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
	}
}
