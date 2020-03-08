using System;
using System.Collections.Generic;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class ContainsAnyTests : Trial {
		[Theory]
		[InlineData("apple", new[] { 'a', 'b' }, true)]
		[InlineData("hello", new[] { 'a', 'b' }, false)]
		public void String_ContainsAny_Char(String source, Char[] values, Boolean expected) => Claim.That(source.ContainsAny(values)).Equals(expected);

		[Theory]
		[InlineData("hello world", new[] { "hello", "goodbye" }, true)]
		[InlineData("goodnight everyone", new[] { "hello", "goodbye" }, false)]
		public void String_ContainsAny_String(String source, String[] values, Boolean expected) {
			Boolean result = source.ContainsAny(values);
			Claim.That(result).Equals(expected);
		}

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { 'g', 'i' }, true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { 'i', 'j' }, false)]
		public void Array_ContainsAny_Char(String[] source, Char[] values, Boolean expected) => Claim.That(source.ContainsAny(values)).Equals(expected);

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { "cd", "de" }, true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { "de", "fg" }, false)]
		public void Array_ContainsAny_String(String[] source, String[] values, Boolean expected) => Claim.That(source.ContainsAny(values)).Equals(expected);

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { 'g', 'i' }, true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { 'i', 'j' }, false)]
		public void List_ContainsAny_Char(String[] source, Char[] values, Boolean expected) => Claim.That(new List<String>(source).ContainsAny(values)).Equals(expected);

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { "cd", "de" }, true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, new[] { "de", "fg" }, false)]
		public void List_ContainsAny_String(String[] source, String[] values, Boolean expected) => Claim.That(new List<String>(source).ContainsAny(values)).Equals(expected);
	}
}
