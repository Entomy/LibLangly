using System;
using Collectathon.DataStructures.Counters;
using Philosoft;
using Xunit;

namespace Collectathon {
	public class Counter_Tests {
		[Theory]
		[InlineData(new Char[] { 'a', 'e', 'i', 'o', 'u' }, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }, 5)]
		public void Counts(Char[] set, Char[] input, Int64 count) {
			Counter<Char> counter = new Counter<Char>(set);
			counter.Add(input);
			Assert.Equal(count, counter.Count);
		}
	}
}
