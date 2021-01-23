using System;
using Xunit;

namespace Langly.DataStructures.Views {
	public class ZipView4_Tests {
		[Fact]
		public void Constructor() {
			var zip = new Char[] { 'a', 'b', 'c' }.Zip(new String[] { "alpha", "bravo", "charlie" });
			Assert.Throws<ArgumentException>(() => new Char[] { 'a', 'b', 'c' }.Zip(new String[] { "alpha", "bravo" }));
		}

		[Theory]
		[InlineData(new Char[] { }, new String[] { })]
		[InlineData(new Char[] { 'a' }, new String[] { "alpha" })]
		[InlineData(new Char[] { 'a', 'b', 'c' }, new String[] { "alpha", "bravo", "charlie" })]
		public void Enumerator(Char[] indicies, String[] elements) {
			var zip = CoreExtensions.Zip(indicies, elements);
			var z = zip.GetEnumerator();
			for (nint i = 0; i < indicies.Length; i++) {
				_ = z.MoveNext();
				Assert.Equal((indicies[i], elements[i]), z.Current);
			}
		}
	}
}
