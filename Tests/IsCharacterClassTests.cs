using System;
using Stringier;
using Xunit;

namespace Tests {
	public class IsCharacterClassTests {
		[Theory]
		[InlineData('̃', true)]
		[InlineData('᪵', true)]
		[InlineData('a', false)]
		[InlineData('2', false)]
		public void IsCombiningMark(Char @char, Boolean expected) => Assert.Equal(expected, @char.IsCombiningMark());

		[Theory]
		[InlineData('₂', true)]
		[InlineData('ₐ', true)]
		[InlineData('⁷', false)]
		[InlineData('2', false)]
		public void IsSubscript(Char @char, Boolean expected) => Assert.Equal(expected, @char.IsSubscript());

		[Theory]
		[InlineData('²', true)]
		[InlineData('³', true)]
		[InlineData('⁽', true)]
		[InlineData('₄', false)]
		[InlineData('2', false)]
		public void IsSuperscript(Char @char, Boolean expected) => Assert.Equal(expected, @char.IsSuperscript());
	}
}
