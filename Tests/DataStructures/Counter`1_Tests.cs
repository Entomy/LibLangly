using System;
using Xunit;

namespace Langly.DataStructures {
	public class Counter1_Tests {
		[Fact]
		public void Constructor() => new Counter<Char>();

		[Theory]
		[InlineData(new Char[] { 'a' }, new Int32[] { 1 }, new Char[] { 'a' })]
		[InlineData(new Char[] { 'a' }, new Int32[] { 2 }, new Char[] { 'a', 'a' })]
		[InlineData(new Char[] { 'a', 'b' }, new Int32[] { 2, 1 }, new Char[] { 'a', 'b', 'a' })]
		public void Indexer(Char[] indicies, Int32[] counts, Char[] values) {
			Counter<Char> counter = new Counter<Char>().Add(values);
			for (nint i = 0; i < counts.Length; i++) {
				Assert.Equal(counts[i], counter[indicies[i]]);
			}
		}

		[Theory]
		[InlineData('a', new Char[] { 'a', 'a', 'a', 'b', 'b', 'c' })]
		[InlineData('c', new Char[] { 'a', 'b', 'b', 'c', 'c', 'c' })]
		public void Highest(Char expected, Char[] values) {
			Counter<Char> counter = new Counter<Char>().Add(values);
			Assert.Equal(expected, counter.Highest);
		}

		[Theory]
		[InlineData('c', new Char[] { 'a', 'a', 'a', 'b', 'b', 'c' })]
		[InlineData('a', new Char[] { 'a', 'b', 'b', 'c', 'c', 'c' })]
		public void Lowest(Char expected, Char[] values) {
			Counter<Char> counter = new Counter<Char>().Add(values);
			Assert.Equal(expected, counter.Lowest);
		}
	}
}
