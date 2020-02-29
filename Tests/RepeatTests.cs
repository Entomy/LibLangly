using System;
using Stringier;
using Xunit;

namespace Tests {
	public class RepeatTests {
		[Theory]
		[InlineData('a', 3, "aaa")]
		public void Repeat_Char(Char source, Int32 count, String expected) => Assert.Equal(expected, source.Repeat(count));

		[Theory]
		[InlineData("hi!", 3, "hi!hi!hi!")]
		public void Repeat_String(String source, Int32 count, String expected) => Assert.Equal(expected, source.Repeat(count));
	}
}
