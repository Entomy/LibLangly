using System;
using System.Text;
using Stringier;
using Xunit;

namespace Tests {
	public class AsCharsTests {
		[Theory]
		[InlineData(new[] { 'A' }, 0x41)]
		[InlineData(new[] { 'Þ' }, 0xDE)]
		[InlineData(new[] { 'ö' }, 0xF6)]
		[InlineData(new[] { 'Ξ' }, 0x39E)]
		[InlineData(new[] { '℥' }, 0x2125)]
		[InlineData(new[] { '⎃' }, 0x2383)]
		[InlineData(new[] { '\uD834', '\uDD1E' }, 0x1D11E)] // 𝄞 which can't be represented with a single char
		public void Rune_AsChars(Char[] expected, Int32 value) => Assert.Equal(expected, new Rune(value).AsChars());
	}
}
