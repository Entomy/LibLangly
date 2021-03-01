using System;
using Xunit;

namespace Langly.DataStructures.Lists {
	public class Chain2_Tests {
		[Fact]
		public void Constructor() {
			Chain<Char, String> chain = new Chain<Char, String>();
		}

		[Theory]
		[MemberData(nameof(Collection2_Data.Insert), MemberType = typeof(Collection2_Data))]
		public void Insert(Char[] indicies, String[] elements) {
			Chain<Char, String> chain = new Chain<Char, String>();
			for (nint i = 0; i < indicies.Length; i++) {
				_ = chain.Insert(indicies[i], elements[i]);
			}
			Assert.Equal(indicies.Zip(elements), chain);
		}
	}
}
