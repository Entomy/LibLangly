using System;
using System.Text;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class AsCharsTests : Trial {
		[Theory]
		[InlineData(0x41, new[] { 'A' })]
		[InlineData(0xDE, new[] { 'Þ' })]
		[InlineData(0xF6, new[] { 'ö' })]
		[InlineData(0x039E, new[] { 'Ξ' })]
		[InlineData(0x2125, new[] { '℥' })]
		[InlineData(0x2383, new[] { '⎃' })]
		[InlineData(0x1D11E, new[] { '\uD834', '\uDD1E' })] // 𝄞 which can't be represented with a single char
		public void Rune_AsChars(Int32 value, Char[] expected) => Claim.That(new Rune(value).AsChars()).SequenceEquals(expected);
	}
}
