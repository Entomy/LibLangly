using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class FuzzyEqualsTests : Trial {
		[Theory]
		[InlineData("bob", "bob", true)]
		[InlineData("bob", "mob", true)]
		[InlineData("bob", "mom", false)]
		public void FuzzyEquals(String source, String other, Boolean expected) => Claim.That(source.FuzzyEquals(other)).Equals(expected);
	}
}
