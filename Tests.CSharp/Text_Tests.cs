using System;
using Stringier;
using Xunit;

namespace Langly {
	public class Text_Tests {
		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_String_String(String source, String other, Boolean expected) => Assert.Equal(expected, Text.Equals(source, other));
	}
}
