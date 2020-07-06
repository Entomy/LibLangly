using System;
using Stringier;
using Defender.Exceptions;
using Xunit;

namespace Tests {
	public class ReplaceTests {
		[Fact]
		public void Replace_CharCharMap() {
			Assert.Equal("jello", "hello".Replace(('h', 'j')));
			Assert.Equal("bacon", "world".Replace(('w', 'b'), ('o', 'a'), ('r', 'c'), ('l', 'o'), ('d', 'n')));
		}

		[Fact]
		public void Replace_StringStringMap() {
			Assert.Equal("wee!", "hello".Replace(("h", "w"), ("l", "e"), ("eo", "!")));
			Assert.Equal("thot", "hello".Replace(("he", "a"), ("l", "th"), ("ath", ""), ("o", "ot")));
		}
	}
}
