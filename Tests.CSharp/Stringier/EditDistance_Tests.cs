using System;
using Stringier;
using Xunit;

namespace Stringier {
	public class EditDistanceTests {
		[Theory]
		[InlineData("ram", "ram", 0)]
		[InlineData("ram", "rom", 1)]
		[InlineData("ram", "rob", 2)]
		[InlineData("ram", "rma", 2)]
		public void Hamming_String_String(String source, String other, Int32 expected) => Assert.Equal(expected, EditDistance.Hamming(source, other));

		[Theory]
		[InlineData("ram", "rom", 1)]
		[InlineData("\u0072\u0061\u006D", "\u0072\u0061\u0301\u006D", 1)]
		[InlineData("\u0072\u00E1\u006D", "\u0072\u0061\u0301\u006D", 2)]
		[InlineData("ram", "rob", 2)]
		[InlineData("ram", "random", 3)]
		[InlineData("flaw", "lawn", 2)]
		public void Levenshtein_String_String(String source, String other, Int32 expected) => Assert.Equal(expected, EditDistance.Levenshtein(source, other));
	}
}
