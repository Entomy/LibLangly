using System;
using System.Text;
using Xunit;
using Langly.Linguistics;
using static Langly.Linguistics.Language;
using static Langly.Linguistics.Script;

namespace Langly {
	public class RopeTests {
		[Fact]
		public void Constructor() {
			Rope empty = new Rope();
		}

		[Theory]
		[InlineData('a')]
		[InlineData('a', 'b', 'c')]
		public void Add_Char(params Char[] text) {
			Rope rope = new Rope();
			foreach (Char @char in text) {
				rope.Add(@char);
			}
			Assert.Equal(text, rope);
		}

		[Theory]
		[InlineData("aa")]
		[InlineData("aa", "bb", "cc")]
		public void Add_String(params String[] text) {
			Rope rope = new Rope();
			StringBuilder builder = new StringBuilder();
			foreach (String @string in text) {
				rope.Add(@string);
				_ = builder.Append(@string);
			}
			Assert.Equal(builder.ToString(), rope);
		}

		[Fact]
		public void Equality() {
			Rope first = null;
			Rope second = null;

			Assert.Equal(second, first);
			Assert.Equal(first, second);
			Assert.True(first == second);
			Assert.True(second == first);
			Assert.False(first != second);
			Assert.False(second != first);

			first = new Rope("hello");

			Assert.NotEqual(second, first);
			Assert.NotEqual(first, second);
			Assert.False(first == second);
			Assert.False(second == first);
			Assert.True(first != second);
			Assert.True(second != first);

			Assert.Equal("hello", first);
			Assert.True(first == "hello");
			Assert.True("hello" == first);
			Assert.False(first != "hello");
			Assert.False("hello" != first);

			second = new Rope("he");

			Assert.NotEqual(second, first);
			Assert.NotEqual(first, second);
			Assert.False(first == second);
			Assert.False(second == first);
			Assert.True(first != second);
			Assert.True(second != first);

			second.Add("llo");

			Assert.Equal(second, first);
			Assert.Equal(first, second);
			Assert.True(first == second);
			Assert.True(second == first);
			Assert.False(first != second);
			Assert.False(second != first);

			Assert.Equal("hello", second);
			Assert.True(second == "hello");
			Assert.True("hello" == second);
			Assert.False(second != "hello");
			Assert.False("hello" != second);
		}

		[Fact]
		public void Indexer() {
			Rope rope = new Rope() { "a", "bb", "ccc" };
			Assert.Equal('a', rope[0]);
			Assert.Equal('b', rope[1]);
			Assert.Equal('b', rope[2]);
			Assert.Equal('c', rope[3]);
		}

		[Theory]
		[InlineData("hello", "hello")]
		[InlineData("hello", "he", "ll", "o")]
		[InlineData("hello", "HELLO")]
		[InlineData("hello", "HE", "LL", "O")]
		public void ToLower_Invariant(String expected, params String[] parts) {
			Rope rope = new Rope() { parts };
			Assert.Equal(expected, rope.ToLower());
		}

		[Theory]
		[InlineData("giriş", "giriş")]
		[InlineData("giriş", "g", "iri", "ş")]
		[InlineData("giriş", "gi", "riş")]
		[InlineData("giriş", "GİRİŞ")]
		[InlineData("giriş", "G", "İRİ", "Ş")]
		[InlineData("giriş", "Gİ", "RİŞ")]
		public void ToLower_trTR(String expected, params String[] parts) {
			Rope rope = new Rope() { parts };
			Assert.Equal(expected, rope.ToLower(Turkish[Latin]));
		}

		[Fact]
		override public String ToString() {
			Rope rope = new Rope("hello");
			Assert.Equal("hello", rope.ToString());
			rope.Add(" ");
			rope.Add("world");
			Assert.Equal("hello world", rope.ToString());
			return String.Empty;
		}

		[Theory]
		[InlineData("HELLO", "hello")]
		[InlineData("HELLO", "he", "ll", "o")]
		[InlineData("HELLO", "HELLO")]
		[InlineData("HELLO", "HE", "LL", "O")]
		public void ToUpper_Invariant(String expected, params String[] parts) {
			Rope rope = new Rope() { parts };
			Assert.Equal(expected, rope.ToUpper());
		}

		[Theory]
		[InlineData("GİRİŞ", "giriş")]
		[InlineData("GİRİŞ", "g", "iri", "ş")]
		[InlineData("GİRİŞ", "gi", "riş")]
		[InlineData("GİRİŞ", "GİRİŞ")]
		[InlineData("GİRİŞ", "G", "İRİ", "Ş")]
		[InlineData("GİRİŞ", "Gİ", "RİŞ")]
		public void ToUpper_trTR(String expected, params String[] parts) {
			Rope rope = new Rope() { parts };
			Assert.Equal(expected, rope.ToUpper(Turkish[Latin]));
		}
	}
}
