using System;
using System.Text;
using Xunit;

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
		}

		[Fact]
		public void Indexer() {
			Rope rope = new Rope() { "a", "bb", "ccc" };
			Assert.Equal('a', rope[0]);
			Assert.Equal('b', rope[1]);
			Assert.Equal('b', rope[2]);
			Assert.Equal('c', rope[3]);
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
	}
}
