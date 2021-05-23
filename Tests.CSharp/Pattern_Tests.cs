using System;
using System.Text;
using Stringier.Patterns;
using Xunit;

namespace Langly {
	public class Pattern_Tests {
		[Theory]
		[InlineData("a", 'a', "a")]
		[InlineData("a", 'a', "abc")]
		public unsafe void CharLiteral_Pointer(String expected, Char pattern, String source) {
			Pattern ptn = pattern;
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", 'a', "a", false)]
		[InlineData("a", 'a', "abc", false)]
		[InlineData("", 'a', "def", true)]
		public void CharLiteral_String(String expected, Char pattern, String source, Boolean throws) {
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

		[Theory]
		[InlineData("a", 'a', "a")]
		[InlineData("a", 'a', "abc")]
		[InlineData("𝄞", 0x1D11E, "𝄞")]
		[InlineData("𝄞", 0x1D11E, "𝄞abc")]
		public unsafe void RuneLiteral_Pointer(String expected, Int32 scalar, String source) {
			Pattern ptn = new Rune(scalar);
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", 'a', "a", false)]
		[InlineData("a", 'a', "abc", false)]
		[InlineData("", 'a', "def", true)]
		[InlineData("𝄞", 0x1D11E, "𝄞", false)]
		[InlineData("𝄞", 0x1D11E, "𝄞abc", false)]
		[InlineData("", 0x1D11E, "def", true)]
		public void RuneLiteral_String(String expected, Int32 scalar, String source, Boolean throws) {
			Pattern ptn = new Rune(scalar);
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

		[Theory]
		[InlineData("a", "a", "a")]
		[InlineData("a", "a", "abc")]
		[InlineData("abc", "abc", "abc")]
		[InlineData("abc", "abc", "abcde")]
		public unsafe void StringLiteral_Pointer(String expected, String pattern, String source) {
			Pattern ptn = pattern;
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a", false)]
		[InlineData("a", "a", "abc", false)]
		[InlineData("abc", "abc", "abc", false)]
		[InlineData("abc", "abc", "abcde", false)]
		[InlineData("", "a", "def", true)]
		public void StringLiteral_String(String expected, String pattern, String source, Boolean throws) {
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
