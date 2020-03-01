using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class JoinTests : Trial {
		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, "abcd")]
		public void Join_CharArray(Char[] source, String expected) => Claim.That(source.Join()).Equals(expected);

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Camel", "Case" }, "ThisWindsUpCamelCase")]
		public void Join_StringArray(String[] source, String expected) => Claim.That(source.Join()).Equals(expected);

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd' }, '-', "a-b-c-d")]
		public void Join_CharArray_WithChar(Char[] source, Char joinChar, String expected) => Claim.That(source.Join(joinChar)).Equals(expected);

		[Theory]
		[InlineData(new[] { "This", "Winds", "Up", "Kebab", "Case" }, '-',  "This-Winds-Up-Kebab-Case")]
		public void Join_StringArray_WithChar(String[] source, Char joinChar, String expected) => Claim.That(source.Join(joinChar)).Equals(expected);
	}
}
