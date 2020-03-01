using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class EnsureTests : Trial {
		[Theory]
		[InlineData("Bob Saget", "Mr. ", "Mr. Bob Saget")]
		[InlineData("Mr. Bob Saget", "Mr. ", "Mr. Bob Saget")]
		public void EnsureBeginsWith(String source, String required, String expected) => Claim.That(source.EnsureBeginsWith(required)).Equals(expected);

		[Theory]
		[InlineData("Gregory House", " MD", "Gregory House MD")]
		[InlineData("Gregory House MD", " MD", "Gregory House MD")]
		public void EnsureEndsWith(String source, String required, String expected) => Claim.That(source.EnsureEndsWith(required)).Equals(expected);
	}
}
