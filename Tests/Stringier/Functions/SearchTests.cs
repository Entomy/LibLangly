using System;
using Collectathon.Tables;
using Xunit;

namespace Stringier {
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
		public void BoyerMooreHorspool(String source, String pattern, Int32 expected) => Assert.Equal(expected, Search.Horspool(source, pattern, out _));

		[Theory]
		[InlineData("hellowhitelowrider", "low", 0, 3)]
		[InlineData("hellowhitelowrider", "low", 1, 3)]
		[InlineData("hellowhitelowrider", "low", 2, 3)]
		[InlineData("hellowhitelowrider", "low", 3, 3)]
		[InlineData("hellowhitelowrider", "low", 4, 10)]
		public void BoyerMooreHorspoolContinuation(String source, String pattern, Int32 startAtIndex, Int32 expected) {
			HorspoolTable table = new HorspoolTable(pattern);
			Assert.Equal(expected, Search.Horspool(source, table, startAtIndex));
		}
	}
}
