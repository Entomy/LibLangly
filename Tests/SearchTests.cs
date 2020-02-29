using System;
using Stringier;
using Xunit;

namespace Tests {
	public class SearchTests {
		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void BruteForce(String source, String pattern, Int32 expected) => Assert.Equal(expected, Search.BruteForce(source, pattern));

		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void RabinKarp(String source, String pattern, Int32 expected) => Assert.Equal(expected, Search.RabinKarp(source, pattern));

		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void BoyerMooreHorspool(String source, String pattern, Int32 expected) => Assert.Equal(expected, Search.Horspool(source, pattern));
	}
}
