using System;
using Xunit;

namespace Stringier.Functions {
	public class EditDistanceTests {
		[Theory]
		[InlineData("ram", "ram", 0, Level.Char)]
		[InlineData("ram", "rom", 1, Level.Char)]
		[InlineData("ram", "rob", 2, Level.Char)]
		[InlineData("ram", "rma", 2, Level.Char)]
		[InlineData("ram", "ram", 0, Level.Rune)]
		[InlineData("ram", "rom", 1, Level.Rune)]
		[InlineData("ram", "rob", 2, Level.Rune)]
		[InlineData("ram", "rma", 2, Level.Rune)]
		[InlineData("g", "𝄞", 1, Level.Rune)]
		[InlineData("ram", "ram", 0, Level.Glyph)]
		[InlineData("ram", "rom", 1, Level.Glyph)]
		[InlineData("ram", "rob", 2, Level.Glyph)]
		[InlineData("ram", "rma", 2, Level.Glyph)]
		[InlineData("g", "𝄞", 1, Level.Glyph)]
		[InlineData("caf\u00E9", "cafe\u0301", 0, Level.Glyph)]
		public void Hamming(String source, String other, Int32 expected, Level level) => Assert.Equal(expected, EditDistance.Hamming(source, other, level));

		[Theory]
		[InlineData("ram", "rom", 1, Level.Char)]
		[InlineData("\u0072\u0061\u006D", "\u0072\u0061\u0301\u006D", 1, Level.Char)]
		[InlineData("\u0072\u00E1\u006D", "\u0072\u0061\u0301\u006D", 2, Level.Char)]
		[InlineData("ram", "rob", 2, Level.Char)]
		[InlineData("ram", "random", 3, Level.Char)]
		[InlineData("flaw", "lawn", 2, Level.Char)]
		public void Levenshtein(String source, String other, Int32 expected, Level level) => Assert.Equal(expected, EditDistance.Levenshtein(source, other, level));
	}
}
