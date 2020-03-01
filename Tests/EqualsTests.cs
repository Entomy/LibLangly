using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class EqualsTests : Trial {
		[Theory]
		[InlineData("", "", true)]
		[InlineData("", "hello", false)]
		[InlineData("hello", "", false)]
		[InlineData("hello", "hello", true)]
		public void Equals_Mixed(String source, String other, Boolean expected) {
			Claim.That(source.Equals(other.AsSpan(), StringComparison.CurrentCulture)).Equals(expected);
			Claim.That(source.AsSpan().Equals(other, StringComparison.CurrentCulture)).Equals(expected);
		}
	}
}
