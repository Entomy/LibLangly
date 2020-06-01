using System;
using Stringier;
using Xunit;

namespace Tests {
	public class EqualsTests {
		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_Mixed(String source, String other, Boolean expected) {
			Assert.Equal(expected, source.Equals(other.AsSpan(), StringComparison.CurrentCulture));
			Assert.Equal(expected, source.AsSpan().Equals(other, StringComparison.CurrentCulture));
		}
	}
}
