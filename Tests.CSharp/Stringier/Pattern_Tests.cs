using System;
using System.Text;
using Stringier;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;
using Xunit;

namespace Stringier {
	public class Pattern_Tests {
		[Theory]
		[InlineData("hello", "hello", "goodbye", "hello")]
		[InlineData("goodbye", "hello", "goodbye", "goodbye")]
		public unsafe void Alternator_Pointer(String expected, String first, String second, String source) {
			Pattern ptn = first.Or(second);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hello", "hello", "goodbye", "hello", false)]
		[InlineData("goodbye", "hello", "goodbye", "goodbye", false)]
		[InlineData("", "hello", "goodbye", "potato", true)]
		public void Alternator_String(String expected, String first, String second, String source, Boolean throws) {
			Pattern ptn = first.Or(second);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("A", "A")]
		[InlineData("A", "Abc")]
		[InlineData("A", "ABC")]
		public unsafe void CategoryChecker_Pointer(String expected, String source) {
			Pattern ptn = Category.UppercaseLetter;
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("A", "A", false)]
		[InlineData("A", "Abc", false)]
		[InlineData("A", "ABC", false)]
		[InlineData("", "a", true)]
		[InlineData("", "abc", true)]
		public void CategoryChecker_String(String expected, String source, Boolean throws) {
			Pattern ptn = Category.UppercaseLetter;
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("one", "one", "two", "three", "one")]
		[InlineData("two", "one", "two", "three", "two")]
		[InlineData("three", "one", "two", "three", "three")]
		public unsafe void ChainAlternator_Pointer(String expected, String first, String second, String third, String source) {
			Pattern ptn = OneOf(first, second, third);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("one", "one", "two", "three", "one", false)]
		[InlineData("two", "one", "two", "three", "two", false)]
		[InlineData("three", "one", "two", "three", "three", false)]
		[InlineData("", "one", "two", "three", "four", true)]
		public void ChainAlternator_String(String expected, String first, String second, String third, String source, Boolean throws) {
			Pattern ptn = OneOf(first, second, third);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("Black", ConsoleColor.Black, "Black")]
		[InlineData("Red", ConsoleColor.Black, "Red")]
		[InlineData("DarkYellow", ConsoleColor.Black, "DarkYellow")]
		public unsafe void ChainEnumAlternator_Pointer<TEnum>(String expected, TEnum @enum, String source) where TEnum : struct, Enum {
			Pattern ptn = OneOf<TEnum>();
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("Black", ConsoleColor.Black, "Black", false)]
		[InlineData("Red", ConsoleColor.Black, "Red", false)]
		[InlineData("DarkYellow", ConsoleColor.Black, "DarkYellow", false)]
		[InlineData("", ConsoleColor.Black, "Potato", true)]
		public void ChainEnumAlternator_String<TEnum>(String expected, TEnum @enum, String source, Boolean throws) where TEnum : struct, Enum {
			Pattern ptn = OneOf<TEnum>();
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", 'a', "a")]
		[InlineData("a", 'a', "abc")]
		public unsafe void CharLiteral_Pointer(String expected, Char pattern, String source) {
			Pattern ptn = pattern;
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
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
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hello", "he", "llo", "hello")]
		public unsafe void Concatenator_Pointer(String expected, String first, String second, String source) {
			Pattern ptn = first.Then(second);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hello", "he", "llo", "hello", false)]
		[InlineData("", "he", "lp", "hello", true)]
		public void Concatenator_String(String expected, String first, String second, String source, Boolean throws) {
			Pattern ptn = first.Then(second);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
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
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
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
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a")]
		[InlineData("aaa", "a", "aaa")]
		[InlineData("aaa", "a", "aaab")]
		[InlineData("", "a", "baaa")]
		[InlineData("", "a", "")]
		public unsafe void KleenesClosure_Pointer(String expected, String pattern, String source) {
			Pattern ptn = Maybe(Many(pattern));
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a")]
		[InlineData("aaa", "a", "aaa")]
		[InlineData("aaa", "a", "aaab")]
		[InlineData("", "a", "baaa")]
		[InlineData("", "a", "")]
		public void KleenesClosure_String(String expected, String pattern, String source) {
			Pattern ptn = Maybe(Many(pattern));
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ptn.Parse(source, ref i);
			Assert.Equal(expected, capture.ToString());
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("//This is a comment", "//", "//This is a comment")]
		[InlineData("--This is a comment", "--", "--This is a comment")]
		[InlineData("//This is a comment", "//", "//This is a comment\nwith some extra text")]
		[InlineData("--This is a comment", "--", "--This is a comment\nwith some extra text")]
		public unsafe void LineComment_Pointer(String expected, String delimiter, String source) {
			Pattern ptn = LineComment(delimiter);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("//This is a comment", "//", "//This is a comment", false)]
		[InlineData("--This is a comment", "--", "--This is a comment", false)]
		[InlineData("//This is a comment", "//", "//This is a comment\nwith some extra text", false)]
		[InlineData("--This is a comment", "--", "--This is a comment\nwith some extra text", false)]
		[InlineData("", "//", "This isn't a comment", true)]
		[InlineData("", "--", "This isn't a comment", true)]
		public void LineComment_String(String expected, String delimiter, String source, Boolean throws) {
			Pattern ptn = LineComment(delimiter);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
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
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
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
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a")]
		[InlineData("a", "a", "abc")]
		[InlineData("abc", "abc", "abc")]
		[InlineData("abc", "abc", "abcde")]
		public unsafe void MemoryLiteral_Pointer(String expected, String pattern, String source) {
			Pattern ptn = pattern;
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a", false)]
		[InlineData("a", "a", "abc", false)]
		[InlineData("abc", "abc", "abc", false)]
		[InlineData("abc", "abc", "abcde", false)]
		[InlineData("", "a", "def", true)]
		public void MemoryLiteral_String(String expected, String pattern, String source, Boolean throws) {
			Pattern ptn = pattern;
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("+-", "+", "-", "+-")]
		[InlineData("++--", "+", "-", "++--")]
		[InlineData("++  --", "+", "-", "++  --")]
		[InlineData("+ + - -", "+", "-", "+ + - -")]
		public unsafe void NestedRanger_Pointer(String expected, String start, String end, String source) {
			Pattern ptn = start.ToNested(end);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("+-", "+", "-", "+-", false)]
		[InlineData("++--", "+", "-", "++--", false)]
		[InlineData("++  --", "+", "-", "++  --", false)]
		[InlineData("+ + - -", "+", "-", "+ + - -", false)]
		[InlineData("", "+", "-", "++-", true)]
		public void NestedRanger_String(String expected, String start, String end, String source, Boolean throws) {
			Pattern ptn = start.ToNested(end);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hi!", "hi!", "hi!")]
		[InlineData("", "hi!", "")]
		[InlineData("", "hi!", "hello")]
		public unsafe void Optor_Pointer(String expected, String pattern, String source) {
			Pattern ptn = Maybe(pattern);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hi!", "hi!", "hi!")]
		[InlineData("", "hi!", "")]
		[InlineData("", "hi!", "hello")]
		public void Optor_String(String expected, String pattern, String source) {
			Pattern ptn = Maybe(pattern);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ptn.Parse(source, ref i);
			Assert.Equal(expected, capture.ToString());
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hello;", "hello", ";", "hello;")]
		[InlineData("hello;", "hello", ";", "hello;goodbye;")]
		[InlineData("hello world;", "hello", ";", "hello world;")]
		public unsafe void Ranger_Pointer(String expected, String start, String end, String source) {
			Pattern ptn = start.To(end);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hello;", "hello", ";", "hello;", false)]
		[InlineData("hello;", "hello", ";", "hello;goodbye;", false)]
		[InlineData("hello world;", "hello", ";", "hello world;", false)]
		[InlineData("", "hello", ";", "hello world", true)]
		public void Ranger_String(String expected, String start, String end, String source, Boolean throws) {
			Pattern ptn = start.To(end);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hi!", "hi!", 1, "hi!")]
		[InlineData("hi!hi!hi!", "hi!", 3, "hi!hi!hi!")]
		public unsafe void Repeater_Pointer(String expected, String pattern, Int32 count, String source) {
			Pattern ptn = Repeat(pattern, count);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("hi!", "hi!", 1, "hi!", false)]
		[InlineData("hi!hi!hi!", "hi!", 3, "hi!hi!hi!", false)]
		[InlineData("", "hi!", 3, "hi!", true)]
		public void Repeater_String(String expected, String pattern, Int32 count, String source, Boolean throws) {
			Pattern ptn = Repeat(pattern, count);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
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
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
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
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("", "")]
		public unsafe void SourceEndChecker_Pointer(String expected, String source) {
			Pattern ptn = Pattern.EndOfSource;
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("", "", false)]
		[InlineData("", "a", true)]
		public void SourceEndChecker_String(String expected, String source, Boolean throws) {
			Pattern ptn = Pattern.EndOfSource;
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a")]
		[InlineData("aa", "a", "aa")]
		[InlineData("aaa", "a", "aaa")]
		[InlineData("aaa", "a", "aaab")]
		public unsafe void Spanner_Pointer(String expected, String pattern, String source) {
			Pattern ptn = Many(pattern);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("a", "a", "a", false)]
		[InlineData("aa", "a", "aa", false)]
		[InlineData("aaa", "a", "aaa", false)]
		[InlineData("aaa", "a", "aaab", false)]
		[InlineData("", "a", "baaa", true)]
		public void Spanner_String(String expected, String pattern, String source, Boolean throws) {
			Pattern ptn = Many(pattern);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("\"Hello World\"", "\"", "\\\"", "\"Hello World\"")]
		[InlineData("\"Hello World\"", "\"", "\\\"", "\"Hello World\" Bacon")]
		[InlineData("\"Hello\\\"World\"", "\"", "\\\"", "\"Hello\\\"World\"")]
		[InlineData("\"Hello\\\"World\"", "\"", "\\\"", "\"Hello\\\"World\" Bacon")]
		public unsafe void StringLiteral_Escape_Pointer(String expected, String delimiter, String escape, String source) {
			Pattern ptn = StringLiteral(delimiter, escape);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("\"Hello World\"", "\"", "\\\"", "\"Hello World\"", false)]
		[InlineData("\"Hello World\"", "\"", "\\\"", "\"Hello World\" Bacon", false)]
		[InlineData("\"Hello\\\"World\"", "\"", "\\\"", "\"Hello\\\"World\"", false)]
		[InlineData("\"Hello\\\"World\"", "\"", "\\\"", "\"Hello\\\"World\" Bacon", false)]
		[InlineData("", "\"", "\\\"", "Hello World", true)]
		[InlineData("", "\"", "\\\"", "\"Hello World", true)]
		[InlineData("", "\"", "\\\"", "\"Hello World\\\"", true)]
		public void StringLiteral_Escape_String(String expected, String delimiter, String escape, String source, Boolean throws) {
			Pattern ptn = StringLiteral(delimiter, escape);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("\"Hello World\"", "\"", "\"Hello World\"")]
		[InlineData("\"Hello World\"", "\"", "\"Hello World\" Bacon")]
		public unsafe void StringLiteral_Pointer(String expected, String delimiter, String source) {
			Pattern ptn = StringLiteral(delimiter);
			Int32 i = 0;
			ReadOnlySpan<Char> capture;
			fixed (Char* src = source) {
				capture = ptn.Parse(src, source.Length, ref i);
				Assert.Equal(expected, capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}

		[Theory]
		[InlineData("\"Hello World\"", "\"", "\"Hello World\"", false)]
		[InlineData("\"Hello World\"", "\"", "\"Hello World\" Bacon", false)]
		[InlineData("", "\"", "Hello World", true)]
		[InlineData("", "\"", "\"Hello World", true)]
		public void StringLiteral_String(String expected, String delimiter, String source, Boolean throws) {
			Pattern ptn = StringLiteral(delimiter);
			Int32 i = 0;
			ReadOnlyMemory<Char> capture = ReadOnlyMemory<Char>.Empty;
			if (!throws) {
				capture = ptn.Parse(source, ref i);
				Assert.Equal(expected, capture.ToString());
			} else {
				_ = Assert.ThrowsAny<Exception>(() => capture = ptn.Parse(source, ref i));
				Assert.Empty(capture.ToString());
			}
			Assert.Equal(expected.Length, i);
		}
	}
}
