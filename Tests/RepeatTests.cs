using System;
using System.Text;
using Stringier;
using Xunit;

namespace Tests {
	public class RepeatTests {
		[Theory]
		[InlineData('a', 0, "")]
		[InlineData('a', 3, "aaa")]
		public void Repeat_Char(Char source, Int32 count, String expected) => Assert.Equal(expected, source.Repeat(count));

		[Theory]
		[InlineData('a', 0, "")]
		[InlineData('a', 3, "aaa")]
		[InlineData(0x1D11E, 3, "𝄞𝄞𝄞")]
		public void Repeat_Rune(Int32 scalarValue, Int32 count, String expected) => Assert.Equal(expected, new Rune(scalarValue).Repeat(count));

		[Theory]
		[InlineData("", 0, "")]
		[InlineData("", 1, "")]
		[InlineData("", 10, "")]
		[InlineData("hi!", 0, "")]
		[InlineData("hi!", 3, "hi!hi!hi!")]
		public void Repeat_String(String source, Int32 count, String expected) => Assert.Equal(expected, source.Repeat(count));
	}
}
