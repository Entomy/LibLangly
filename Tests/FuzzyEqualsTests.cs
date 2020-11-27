using System;
using Xunit;

namespace Langly {
	public class FuzzyEqualsTests {
		[Theory]
		[InlineData("bob", "bob", true)]
		[InlineData("bob", "mob", true)]
		[InlineData("bob", "mom", false)]
		public void FuzzyEquals(String source, String other, Boolean expected) => Assert.Equal(expected, Text.FuzzyEquals(source, other));
	}
}
