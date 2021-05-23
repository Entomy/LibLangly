using System;
using Stringier.Patterns;
using Xunit;

namespace Langly {
	public class Pattern_Tests {
		[Theory]
		[InlineData("a", 'a', "a", false)]
		[InlineData("a", 'a', "abc", false)]
		[InlineData("", 'a', "def", true)]
		public void CharLiteral(String expected, Char pattern, String source, Boolean throws) {
			Pattern ptn = pattern;
			Int32 i = 0;
			Capture? capture = null;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture);
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Null(capture);
			}
			Assert.Equal(expected.Length, i);
		}
	}
}
