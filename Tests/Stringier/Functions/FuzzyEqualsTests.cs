using System;
using Stringier;
using Xunit;

namespace Stringier.Functions {
	public class FuzzyEqualsTests {
		[Theory]
		[InlineData("bob", "bob", true)]
		[InlineData("bob", "mob", true)]
		[InlineData("bob", "mom", false)]
		public void FuzzyEquals(String source, String other, Boolean expected) => Assert.Equal(expected, Text.FuzzyEquals(source, other));
	}
}
