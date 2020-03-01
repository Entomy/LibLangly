using System;
using Stringier;
using static Stringier.Metrics;
using Defender;
using Xunit;

namespace Tests {
	public class EditDistanceTests : Trial {
		[Theory]
		[InlineData("ram", "ram", 0)]
		[InlineData("ram", "rom", 1)]
		[InlineData("ram", "rob", 2)]
		[InlineData("ram", "rma", 2)]
		public void Hamming(String source, String other, Int32 expected) => Claim.That(HammingDistance(source, other)).Equals(expected);

		[Theory]
		[InlineData("ram", "rom", 1)]
		[InlineData("\u0072\u0061\u006D", "\u0072\u0061\u0301\u006D", 1)]
		[InlineData("\u0072\u00E1\u006D", "\u0072\u0061\u0301\u006D", 2)]
		[InlineData("ram", "rob", 2)]
		[InlineData("ram", "random", 3)]
		[InlineData("flaw", "lawn", 2)]
		public void Levenshtein(String source, String other, Int32 expected) => Claim.That(LevenshteinDistance(source, other)).Equals(expected);
	}
}
