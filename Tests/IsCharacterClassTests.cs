using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class IsCharacterClassTests : Trial {
		[Theory]
		[InlineData('̃', true)]
		[InlineData('᪵', true)]
		[InlineData('a', false)]
		[InlineData('2', false)]
		public void IsCombiningMark(Char @char, Boolean expected) => Claim.That(@char.IsCombiningMark()).Equals(expected);

		[Theory]
		[InlineData('₂', true)]
		[InlineData('ₐ', true)]
		[InlineData('⁷', false)]
		[InlineData('2', false)]
		public void IsSubscript(Char @char, Boolean expected) => Claim.That(@char.IsSubscript()).Equals(expected);

		[Theory]
		[InlineData('²', true)]
		[InlineData('³', true)]
		[InlineData('⁽', true)]
		[InlineData('₄', false)]
		[InlineData('2', false)]
		public void IsSuperscript(Char @char, Boolean expected) => Claim.That(@char.IsSuperscript()).Equals(expected);
	}
}
