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
			Assert.Throws<ArgumentSizeException>(() => "hello".Replace());
		}
	}
}
