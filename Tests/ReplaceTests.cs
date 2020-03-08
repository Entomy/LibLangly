using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class ReplaceTests : Trial {
		[Fact]
		public void Replace_CharCharMap() {
			Claim.That("hello".Replace(('h', 'j')))
				.Equals("jello");
			Claim.That("world".Replace(('w', 'b'), ('o', 'a'), ('r', 'c'), ('l', 'o'), ('d', 'n')))
				.Equals("bacon");
			Claim.That(() => "hello".Replace())
				.Throws<ArgumentSizeException>();
		}
	}
}
