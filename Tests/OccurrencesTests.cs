using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class OccurrencesTests : Trial {
		[Theory]
		[InlineData("hello", 'o', 1)]
		[InlineData("hello", 'l', 2)]
		[InlineData("hello", '?', 0)]
		public void Occurrences_String_Char(String source, Char charToCount, Int32 expected) => Claim.That(source.Occurrences(charToCount)).Equals(expected);

		[Theory]
		[InlineData("hello", new[] { 'e', 'o' }, 2)]
		[InlineData("hello", new[] { 'l', '?' }, 2)]
		public void Occurrences_String_CharArray(String source, Char[] charsToCount, Int32 expected) => Claim.That(source.Occurrences(charsToCount)).Equals(expected);

		[Theory]
		[InlineData(new[] { "hello", "world" }, 'e', 1)]
		[InlineData(new[] { "hello", "world" }, 'o', 2)]
		[InlineData(new[] { "hello", "world" }, 'l', 3)]
		public void Occurrences_StringArray_Char(String[] source, Char charToCount, Int32 expected) => Claim.That(source.Occurrences(charToCount)).Equals(expected);

		[Theory]
		[InlineData(new[] { "hello", "world" }, new[] { 'a', 'e', 'i', 'o', 'u' }, 3)]
		public void Occurrences_StringArray_CharArray(String[] source, Char[] charsToCount, Int32 expected) => Claim.That(source.Occurrences(charsToCount)).Equals(expected);
	}
}
