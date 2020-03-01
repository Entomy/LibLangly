using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class SqueezeTests : Trial {
		[Theory]
		[InlineData("hello", "helo")]
		[InlineData("Leeeeeeeerooooooooooyyyyyyyy Jeeeeeeeenkiiiiiiiiins", "Leroy Jenkins")]
		public void Squeeze(String source, String expected) => Claim.That(source.Squeeze()).Equals(expected);
	}
}
