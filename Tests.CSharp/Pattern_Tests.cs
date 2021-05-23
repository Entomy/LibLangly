﻿using System;
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
		[InlineData("a", "a", 1, "a")]
		[InlineData("a", "a", 1, "abc")]
		[InlineData("b", "a", 1, "bbc")]
		[InlineData("abc", "abc", 1, "abc")]
		[InlineData("_bc", "abc", 1, "_bc")]
		[InlineData("a_c", "abc", 1, "a_c")]
		[InlineData("ab_", "abc", 1, "ab_")]
		public unsafe void Fuzzer_Pointer(String expected, String pattern, Int32 maxEdits, String source) {
			Pattern ptn = pattern.Fuzzy(maxEdits);
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", 1, "a", false)]
		[InlineData("a", "a", 1, "abc", false)]
		[InlineData("b", "a", 1, "bbc", false)]
		[InlineData("abc", "abc", 1, "abc", false)]
		[InlineData("_bc", "abc", 1, "_bc", false)]
		[InlineData("a_c", "abc", 1, "a_c", false)]
		[InlineData("ab_", "abc", 1, "ab_", false)]
		[InlineData("", "abc", 1, "___", true)]
		public void Fuzzer_String(String expected, String pattern, Int32 maxEdits, String source, Boolean throws) {
			Pattern ptn = pattern.Fuzzy(maxEdits);
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
		[InlineData("\u000A", "\u000A")]
		[InlineData("\u000A\u000D", "\u000A\u000D")]
		[InlineData("\u000B", "\u000B")]
		[InlineData("\u000C", "\u000C")]
		[InlineData("\u000D", "\u000D")]
		[InlineData("\u000D\u000A", "\u000D\u000A")]
		[InlineData("\u0085", "\u0085")]
		[InlineData("\u2028", "\u2028")]
		[InlineData("\u2029", "\u2029")]
		public unsafe void LineEndChecker_Pointer(String expected, String source) {
			Pattern ptn = Pattern.EndOfLine;
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("\u000A", "\u000A", false)]
		[InlineData("\u000A\u000D", "\u000A\u000D", false)]
		[InlineData("\u000B", "\u000B", false)]
		[InlineData("\u000C", "\u000C", false)]
		[InlineData("\u000D", "\u000D", false)]
		[InlineData("\u000D\u000A", "\u000D\u000A", false)]
		[InlineData("\u0085", "\u0085", false)]
		[InlineData("\u2028", "\u2028", false)]
		[InlineData("\u2029", "\u2029", false)]
		[InlineData("", "abc", true)]
		public void LineEndChecker_String(String expected, String source, Boolean throws) {
			Pattern ptn = Pattern.EndOfLine;
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
		[InlineData("", "")]
		public unsafe void SourceEndChecker_Pointer(String expected, String source) {
			Pattern ptn = Pattern.EndOfSource;
			Int32 i = 0;
			Capture? capture = null;
			fixed (Char* src = source) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture);
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("", "", false)]
		[InlineData("", "a", true)]
		public void SourceEndChecker_String(String expected, String source, Boolean throws) {
			Pattern ptn = Pattern.EndOfSource;
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
