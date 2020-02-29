using System;
using Stringier;
using Xunit;

namespace Tests {
	public class FuzzyEqualsTests {
		[Theory]
		[InlineData("bob", "bob", true)]
		[InlineData("bob", "mob", true)]
		[InlineData("bob", "mom", false)]
		public void FuzzyEquals(String source, String other, Boolean expected) => Assert.Equal(expected, source.FuzzyEquals(other));
	}
}
