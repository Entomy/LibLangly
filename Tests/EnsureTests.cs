using System;
using Stringier;
using Xunit;

namespace Tests {
	public class EnsureTests {
		[Theory]
		[InlineData("Bob Saget", "Mr. ", "Mr. Bob Saget")]
		[InlineData("Mr. Bob Saget", "Mr. ", "Mr. Bob Saget")]
		public void EnsureBeginsWith(String source, String required, String expected) => Assert.Equal(expected, source.EnsureBeginsWith(required));

		[Theory]
		[InlineData("Gregory House", " MD", "Gregory House MD")]
		[InlineData("Gregory House MD", " MD", "Gregory House MD")]
		public void EnsureEndsWith(String source, String required, String expected) => Assert.Equal(expected, source.EnsureEndsWith(required));
	}
}
