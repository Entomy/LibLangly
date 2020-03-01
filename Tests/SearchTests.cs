using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class SearchTests : Trial {
		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void BruteForce(String source, String pattern, Int32 expected) => Claim.That(Search.BruteForce(source, pattern)).Equals(expected);

		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void RabinKarp(String source, String pattern, Int32 expected) => Claim.That(Search.RabinKarp(source, pattern)).Equals(expected);

		[Theory]
		[InlineData("helloworld", "low", 3)]
		[InlineData("helloworld", "bacon", -1)]
		public void BoyerMooreHorspool(String source, String pattern, Int32 expected) => Claim.That(Search.Horspool(source, pattern)).Equals(expected);
	}
}
