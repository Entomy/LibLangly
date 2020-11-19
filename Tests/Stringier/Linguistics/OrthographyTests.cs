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
		[InlineData('i', 'İ', 'i')]
		[InlineData('İ', 'İ', 'i')]
		[InlineData('ı', 'I', 'ı')]
		[InlineData('I', 'I', 'ı')]
		public void Casing_AzerbaijaniLatin(Int32 value, Int32 uppercase, Int32 lowercase) {
			Rune val = new Rune(value);
			Rune upr = new Rune(uppercase);
			Rune lwr = new Rune(lowercase);
			Assert.Equal(upr, val.ToUpper(Azerbaijani[Latin]));
			Assert.Equal(lwr, val.ToLower(Azerbaijani[Latin]));
		}

		[Theory]
		[InlineData('a', 'A', 'a')]
		[InlineData('A', 'A', 'a')]
		[InlineData('i', 'I', 'i')]
		[InlineData('I', 'I', 'i')]
		public void Casing_EnglishLatin(Char value, Char uppercase, Char lowercase) {
			Assert.Equal(uppercase, value.ToUpper(English[Latin]));
			Assert.Equal(lowercase, value.ToLower(English[Latin]));
		}

		[Theory]
		[InlineData('a', 'A', 'a')]
		[InlineData('A', 'A', 'a')]
		[InlineData('i', 'İ', 'i')]
		[InlineData('İ', 'İ', 'i')]
		[InlineData('ı', 'I', 'ı')]
		[InlineData('I', 'I', 'ı')]
		public void Casing_TurkishLatin(Int32 value, Int32 uppercase, Int32 lowercase) {
			Rune val = new Rune(value);
			Rune upr = new Rune(uppercase);
			Rune lwr = new Rune(lowercase);
			Assert.Equal(upr, val.ToUpper(Turkish[Latin]));
			Assert.Equal(lwr, val.ToLower(Turkish[Latin]));
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
