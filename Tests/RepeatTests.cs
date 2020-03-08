using System;
using System.Text;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class RepeatTests : Trial {
		[Theory]
		[InlineData('a', 0, "")]
		[InlineData('a', 3, "aaa")]
		public void Repeat_Char(Char source, Int32 count, String expected) => Claim.That(source.Repeat(count)).Equals(expected);

		[Theory]
		[InlineData('a', 0, "")]
		[InlineData('a', 3, "aaa")]
		[InlineData(0x1D11E, 3, "𝄞𝄞𝄞")]
		public void Repeat_Rune(Int32 scalarValue, Int32 count, String expected) => Claim.That(new Rune(scalarValue).Repeat(count)).Equals(expected);

		[Theory]
		[InlineData("", 0, "")]
		[InlineData("", 1, "")]
		[InlineData("", 10, "")]
		[InlineData("hi!", 0, "")]
		[InlineData("hi!", 3, "hi!hi!hi!")]
		public void Repeat_String(String source, Int32 count, String expected) => Claim.That(source.Repeat(count)).Equals(expected);
	}
}
