using System;
using System.Diagnostics.CodeAnalysis;
using Stringier;
using Xunit;

namespace Langly {
	[SuppressMessage("Maintainability", "AV1564:Parameter in public or internal member is of type bool or bool?", Justification = "This is testing, and not public API.")]
	public class Text_Tests {
		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_String_String(String source, String other, Boolean expected) => Assert.Equal(expected, Text.Equals(source, other));
	}
}
