using System;
using Xunit;

namespace Langly.DataStructures.Lists {
	public class Chain2_Tests {
		[Fact]
		public void Constructor() {
			Chain<Char, String> chain = new Chain<Char, String>();
		}

		[Theory]
		[InlineData(new Char[] { }, new String[] { })]
		[InlineData(new Char[] { 'a' }, new String[] { "alpha" })]
		[InlineData(new Char[] { 'a', 'b', 'c' }, new String[] { "alpha", "bravo", "charlie" })]
		public void Insert(Char[] indicies, String[] elements) {
			Chain<Char, String> chain = new Chain<Char, String>();
			for (nint i = 0; i < indicies.Length; i++) {
				_ = chain.Insert(indicies[i], elements[i]);
			}
			Assert.Equal(indicies.Zip(elements), chain);
		}
	}
}
