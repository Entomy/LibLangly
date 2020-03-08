using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class ReplaceTests {
		[Fact]
		public void Replace_CharChar() {
			Assert.Equal("jello", "hello".Replace(('h', 'j')));
			Assert.Equal("bacon", "world".Replace(('w', 'b'), ('o', 'a'), ('r', 'c'), ('l', 'o'), ('d', 'n')));
		}
	}
}
