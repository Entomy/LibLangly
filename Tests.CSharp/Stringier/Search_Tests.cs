using System;
using Stringier;
using Xunit;

namespace Stringier {
	public class Search_Tests {
		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void RabinKarp(String source, String pattern, Int32 expected) => Assert.Equal(expected, Search.RabinKarp(source, pattern));
	}
}
