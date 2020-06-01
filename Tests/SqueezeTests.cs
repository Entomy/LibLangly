using System;
using Stringier;
using Xunit;

namespace Tests {
	public class SqueezeTests {
		[Theory]
		[InlineData("hello", "helo")]
		[InlineData("Leeeeeeeerooooooooooyyyyyyyy Jeeeeeeeenkiiiiiiiiins", "Leroy Jenkins")]
		public void Squeeze(String source, String expected) => Assert.Equal(expected, source.Squeeze());
	}
}
