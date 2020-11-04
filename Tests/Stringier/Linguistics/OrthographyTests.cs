using System;
using System.Text;
using Xunit;
using Philosoft;
using static Stringier.Linguistics.Language;
using static Stringier.Linguistics.Script;

namespace Stringier.Linguistics {
	public class OrthographyTests {
		[Theory]
		[InlineData('a', 'A', 'a')]
		[InlineData('A', 'A', 'a')]
		public void Casing_EnglishLatin(Char value, Char uppercase, Char lowercase) {
			Assert.Equal(uppercase, value.ToUpper(English[Latin]));
			Assert.Equal(lowercase, value.ToLower(English[Latin]));
		}

		[Theory]
		[InlineData(0x010428, 0x010400, 0x010428)]
		[InlineData(0x010400, 0x010400, 0x010428)]
		public void Casing_EnglishDeseret(Int32 value, Int32 uppercase, Int32 lowercase) {
			Rune val = new Rune(value);
			Rune upr = new Rune(uppercase);
			Rune lwr = new Rune(lowercase);
			Assert.Equal(upr, val.ToUpper(English[Deseret]));
			Assert.Equal(lwr, val.ToLower(English[Deseret]));
		}

		[Theory]
		[InlineData('a', true)]
		[InlineData('z', true)]
		[InlineData('A', true)]
		[InlineData('Z', true)]
		[InlineData('0', true)]
		[InlineData('9', true)]
		[InlineData('з', false)]
		[InlineData('ж', false)]
		public void Contains_EnglishLatin(Char value, Boolean expected) => Assert.Equal(expected, English[Latin].Contains(value));
	}
}
