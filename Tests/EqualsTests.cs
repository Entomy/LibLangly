using System;
using Xunit;

namespace Langly {
	public class EqualsTests {
		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_Insensitive(String source, String other, Boolean expected) {
			Assert.Equal(expected, Text.Equals(source, other, Case.Insensitive));
			Assert.Equal(expected, Text.Equals(source, other.AsSpan(), Case.Insensitive));
			Assert.Equal(expected, Text.Equals(source.AsSpan(), other, Case.Insensitive));
			Assert.Equal(expected, Text.Equals(source.AsSpan(), other.AsSpan(), Case.Insensitive));
		}

		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_Sensitive(String source, String other, Boolean expected) {
			Assert.Equal(expected, Text.Equals(source, other, Case.Sensitive));
			Assert.Equal(expected, Text.Equals(source, other.AsSpan(), Case.Sensitive));
			Assert.Equal(expected, Text.Equals(source.AsSpan(), other, Case.Sensitive));
			Assert.Equal(expected, Text.Equals(source.AsSpan(), other.AsSpan(), Case.Sensitive));
		}
	}
}
