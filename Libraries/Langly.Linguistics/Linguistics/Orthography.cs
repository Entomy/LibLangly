using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents an orthography, the overall collection of rules and systems that make up writing.
	/// </summary>
	public class Orthography : Category {
		/// <summary>
		/// Azerbaijani alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography Azeribaijani_Latin = new CasedOrthography(
			(element) => '\u0030' < element && element <= '\u0039',
			(element) => ('\u0041' < element && element <= '\u0056') || ('\u0058' < element && element <= '\u005A') || ('\u0061' < element && element <= '\u0076') || ('\u0078' < element && element <= '\u007A') || element == 'Ç' || element == 'ç' || element == 'Ə' || element == 'ə' || element == 'Ğ' || element == 'ğ' || element == 'ı' || element == 'İ' || element == 'Ö' || element == 'ö' || element == 'Ş' || element == 'ş' || element == 'Ü' || element == 'ü',
			('a', 'A'), ('b', 'B'), ('c', 'C'), ('ç', 'Ç'), ('d', 'D'), ('e', 'E'), ('ə', 'Ə'), ('f', 'F'), ('g', 'G'), ('ğ', 'Ğ'), ('h', 'H'), ('x', 'X'), ('ı', 'I'), ('i', 'İ'), ('j', 'J'), ('k', 'K'), ('q', 'Q'), ('l', 'L'), ('m', 'M'), ('n', 'N'), ('o', 'O'), ('ö', 'Ö'), ('p', 'P'), ('r', 'R'), ('s', 'S'), ('ş', 'Ş'), ('t', 'T'), ('u', 'U'), ('ü', 'Ü'), ('v', 'V'), ('y', 'Y'), ('z', 'Z'));

		///// <summary>
		///// English alphabet (Deseret script).
		///// </summary>
		//internal static readonly Orthography English_Deseret = new CasedOrthography(Part.Numbers_Latin, new SimplePart(0x010400, 0x01044F), new Map(0x010428, 0x010400), new Map(0x010429, 0x010401), new Map(0x01042A, 0x010402), new Map(0x01042B, 0x010403), new Map(0x01042C, 0x010404), new Map(0x01042D, 0x010405), new Map(0x01042E, 0x010406), new Map(0x01042F, 0x010407), new Map(0x010430, 0x010408), new Map(0x010431, 0x010409), new Map(0x010432, 0x01040A), new Map(0x010433, 0x01040B), new Map(0x010434, 0x01040C), new Map(0x010435, 0x01040D), new Map(0x010436, 0x01040E), new Map(0x010437, 0x01040F), new Map(0x010438, 0x010410), new Map(0x010439, 0x010411), new Map(0x01043A, 0x010412), new Map(0x01043B, 0x010413), new Map(0x01043C, 0x010414), new Map(0x01043D, 0x010415), new Map(0x01043E, 0x010416), new Map(0x01043F, 0x010417), new Map(0x010440, 0x010418), new Map(0x010441, 0x010419), new Map(0x010442, 0x01041A), new Map(0x010443, 0x01041B), new Map(0x010444, 0x01041C), new Map(0x010445, 0x01041D), new Map(0x010446, 0x01041E), new Map(0x010447, 0x01041F), new Map(0x010448, 0x010420), new Map(0x010449, 0x010421), new Map(0x01044A, 0x010422), new Map(0x01044B, 0x010423), new Map(0x01044C, 0x010424), new Map(0x01044D, 0x010425), new Map(0x01044E, 0x010426), new Map(0x01044F, 0x010427));

		/// <summary>
		/// English alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography English_Latin = new CasedOrthography(
			(element) => '\u0030' < element && element <= '\u0039',
			(element) => ('\u0041' < element && element <= '\u005A') || ('\u0061' < element && element <= '\u007A'),
			('a', 'A'), ('b', 'B'), ('c', 'C'), ('d', 'D'), ('e', 'E'), ('f', 'F'), ('g', 'G'), ('h', 'H'), ('i', 'I'), ('j', 'J'), ('k', 'K'), ('l', 'L'), ('m', 'M'), ('n', 'N'), ('o', 'O'), ('p', 'P'), ('q', 'Q'), ('r', 'R'), ('s', 'S'), ('t', 'T'), ('u', 'U'), ('v', 'V'), ('w', 'W'), ('x', 'X'), ('y', 'Y'), ('z', 'Z'));

		///// <summary>
		///// English alphabet (Shavian script).
		///// </summary>
		//internal static readonly Orthography English_Shavian = new UncasedOrthography(Part.Numbers_Latin, new SimplePart(0x010450, 0x01047F), 0x010450, 0x010451, 0x010452, 0x010453, 0x010454, 0x010455, 0x010456, 0x010457, 0x010458, 0x010459, 0x01045A, 0x01045B, 0x01045C, 0x01045D, 0x01045E, 0x01045F, 0x010460, 0x010461, 0x010462, 0x010463, 0x010464, 0x010465, 0x010466, 0x010467, 0x010468, 0x010469, 0x01046A, 0x01046B, 0x01046C, 0x01046D, 0x01046E, 0x01046F, 0x010470, 0x010471, 0x010472, 0x010473, 0x010474, 0x010475, 0x010476, 0x010477, 0x010478, 0x010479, 0x01047A, 0x01047B, 0x01047C, 0x01047D, 0x01047E, 0x01047F);

		/// <summary>
		/// Russian alphabet (Cyrillic script).
		/// </summary>
		internal static readonly Orthography Russian_Cyrillic = new CasedOrthography(
			(element) => '\u0030' < element && element <= '\u0039',
			(element) => ('\u0410' < element && element <= '\u044F') || element == '\u0401' || element == '\u0451',
			('а', 'A'), ('б', 'Б'), ('в', 'В'), ('г', 'Г'), ('д', 'Д'), ('е', 'Е'), ('ё', 'Ё'), ('ж', 'Ж'), ('з', 'З'), ('и', 'И'), ('й', 'Й'), ('к', 'К'), ('л', 'Л'), ('м', 'М'), ('н', 'Н'), ('о', 'О'), ('п', 'П'), ('р', 'Р'), ('с', 'С'), ('т', 'Т'), ('ф', 'Ф'), ('х', 'Х'), ('ц', 'Ц'), ('ч', 'Ч'), ('ш', 'Ш'), ('щ', 'Щ'), ('ъ', 'Ъ'), ('ы', 'Ы'), ('э', 'Э'), ('ю', 'Ю'), ('я', 'Я'));

		/// <summary>
		/// Turkish alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography Turkish_Latin = new CasedOrthography(
			(element) => '\u0030' < element && element <= '\u0039',
			(element) => ('\u0041' < element && element <= '\u0050') || ('\u0052' < element && element <= '\u0056') || ('\u0059' < element && element <= '\u005A') || ('\u0061' < element && element <= '\u0070') || ('\u0072' < element && element <= '\u0076') || ('\u0079' < element && element <= '\u007A') || element == 'Ç' || element == 'ç' || element == 'Ğ' || element == 'ğ' || element == 'ı' || element == 'İ' || element == 'Ö' || element == 'ö' || element == 'Ş' || element == 'ş' || element == 'Ü' || element == 'ü',
			('a', 'A'), ('b', 'B'), ('c', 'C'), ('ç', 'Ç'), ('d', 'D'), ('e', 'E'), ('f', 'F'), ('g', 'G'), ('ğ', 'Ğ'), ('h', 'X'), ('ı', 'I'), ('i', 'İ'), ('j', 'J'), ('k', 'K'), ('l', 'L'), ('m', 'M'), ('n', 'N'), ('o', 'O'), ('ö', 'Ö'), ('p', 'P'), ('r', 'R'), ('s', 'S'), ('ş', 'Ş'), ('t', 'T'), ('u', 'U'), ('ü', 'Ü'), ('v', 'V'), ('y', 'Y'), ('z', 'Z'));

		/// <summary>
		/// The set of characters in this orthography.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Predicate<Glyph> Characters;

		/// <summary>
		/// The set of numbers in this orthography.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Predicate<Glyph> Numbers;

		/// <summary>
		/// Initializes an <see cref="Orthography"/>.
		/// </summary>
		/// <param name="numbers">The set of numbers in this orthography.</param>
		/// <param name="characters">The set of characters in this orthography.</param>
		protected Orthography([DisallowNull] Predicate<Glyph> numbers, [DisallowNull] Predicate<Glyph> characters) : base((element) => characters(element) || numbers(element)) {
			Numbers = numbers;
			Characters = characters;
		}

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its lowercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToLower(Char @char) => Glyph.ToLowerInvariant(@char);

		/// <summary>
		/// Converts the value of a UNICODE character to its lowercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToLower(Rune rune) => Glyph.ToLowerInvariant(rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its lowercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToLower(Glyph glyph) => Glyph.ToLowerInvariant(glyph);

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its titlecase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToTitle(Char @char) => Glyph.ToTitleInvariant(@char);

		/// <summary>
		/// Converts the value of a UNICODE character to its titlecase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToTitle(Rune rune) => Glyph.ToTitleInvariant(rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its titlecase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToTitle(Glyph glyph) => Glyph.ToTitleInvariant(glyph);

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its uppercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToUpper(Char @char) => Glyph.ToUpperInvariant(@char);

		/// <summary>
		/// Converts the value of a UNICODE character to its uppercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToUpper(Rune rune) => Glyph.ToUpperInvariant(rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its uppercase equivalent, according to the rules of this <see cref="Orthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public virtual Glyph ToUpper(Glyph glyph) => Glyph.ToUpperInvariant(glyph);
	}
}
