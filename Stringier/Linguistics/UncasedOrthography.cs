using System;
using System.Text;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents an <see cref="Orthography"/> without casing.
	/// </summary>
	internal sealed class UncasedOrthography : Orthography<Glyph> {
		/// <inheritdoc/>
		internal UncasedOrthography(Part numbers, Part characters, params Glyph[] glyphs) : base(numbers, characters, glyphs) { }

		internal UncasedOrthography(Part numbers, Part characters, params Char[] glyphs) : base(numbers, characters, ToGlyphArray(glyphs)) { }

		internal UncasedOrthography(Part numbers, Part characters, params UInt32[] glyphs) : base(numbers, characters, ToGlyphArray(glyphs)) { }

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected override Char ToLower(Char @char) => @char.ToLower();

		/// <summary>
		/// Converts the value of a UNICODE character to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected override Rune ToLower(Rune rune) => rune.ToLower();

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected override Glyph ToLower(Glyph glyph) => glyph.ToLower();

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected override Char ToTitle(Char @char) => @char.ToTitle();

		/// <summary>
		/// Converts the value of a UNICODE character to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected override Rune ToTitle(Rune rune) => rune.ToTitle();

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected override Glyph ToTitle(Glyph glyph) => glyph.ToTitle();

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected override Char ToUpper(Char @char) => @char.ToUpper();

		/// <summary>
		/// Converts the value of a UNICODE character to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected override Rune ToUpper(Rune rune) => rune.ToUpper();

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected override Glyph ToUpper(Glyph glyph) => glyph.ToUpper();

		private static Glyph[] ToGlyphArray(Char[] chars) {
			Glyph[] result = new Glyph[chars.Length];
			for (Int32 i = 0; i < chars.Length; i++) {
				result[i] = new Glyph(chars[i]);
			}
			return result;
		}

		private static Glyph[] ToGlyphArray(UInt32[] codes) {
			Glyph[] result = new Glyph[codes.Length];
			for (Int32 i = 0; i < codes.Length; i++) {
				result[i] = new Glyph(codes[i]);
			}
			return result;
		}
	}
}
