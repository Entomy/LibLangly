using System;
using System.Collections.Generic;
using Stringier;
using Xunit;

namespace Tests {
	public class ContainsTests {
		[Theory]
		[InlineData("apple", 'a', true)]
		[InlineData("hello", 'a', false)]
		public void String_Contains_Char(String source, Char value, Boolean expected) => Assert.Equal(expected, source.Contains(value));

		[Theory]
		[InlineData("hello world", "hello", true)]
		[InlineData("goodnight everyone", "hello", false)]
		public void String_Contains_String(String source, String value, Boolean expected) => Assert.Equal(expected, source.Contains(value));

		[Theory]
		[InlineData(new[] { "ab","cd","ef","gh"}, 'g', true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, 'i', false)]
		public void Array_Contains_Char(String[] source, Char value, Boolean expected) => Assert.Equal(expected, source.Contains(value));

		[Theory]
		[InlineData(new[] { "ab","cd","ef","gh"}, "cd", true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, "de", false)]
		public void Array_Contains_String(String[] source, String value, Boolean expected) => Assert.Equal(expected, source.Contains(value));

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, 'g', true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, 'i', false)]
		public void List_Contains_Char(String[] source, Char value, Boolean expected) => Assert.Equal(expected, new List<String>(source).Contains(value));

		[Theory]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, "cd", true)]
		[InlineData(new[] { "ab", "cd", "ef", "gh" }, "de", false)]
		public void List_Contains_String(String[] source, String value, Boolean expected) => Assert.Equal(expected, new List<String>(source).Contains(value));
	}
}
