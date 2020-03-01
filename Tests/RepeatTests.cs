using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class RepeatTests : Trial {
		[Theory]
		[InlineData('a', 3, "aaa")]
		public void Repeat_Char(Char source, Int32 count, String expected) => Claim.That(source.Repeat(count)).Equals(expected);

		[Theory]
		[InlineData("hi!", 3, "hi!hi!hi!")]
		public void Repeat_String(String source, Int32 count, String expected) => Claim.That(source.Repeat(count)).Equals(expected);
	}
}
