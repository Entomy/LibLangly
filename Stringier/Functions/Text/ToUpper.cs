using System;
using System.Text;
using Langly.Linguistics;

namespace Langly {
	public static partial class Text {
		#region ToUpper(Element)
		/// <summary>
		/// Converts the value of a UTF-16 code unit to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char) => (Char)Glyph.Info[@char].Uppercase;

		/// <summary>
		/// Converts the value of a UNICODE character to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune) => new Rune(Glyph.Info[unchecked((UInt32)rune.Value)].Uppercase);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpper(this Glyph glyph) => new Glyph(Glyph.Info[glyph.Code].Uppercase);
		#endregion

		#region ToUpper(Element, Orthography)
		/// <summary>
		/// Converts the value of a UTF-16 code unit to its uppercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char, Orthography orthography) => !(orthography is null) ? orthography.ToUpper(@char) : ToUpper(@char);

		/// <summary>
		/// Converts the value of a UNICODE character to its uppercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune, Orthography orthography) => !(orthography is null) ? orthography.ToUpper(rune) : ToUpper(rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its uppercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpper(this Glyph glyph, Orthography orthography) => !(orthography is null) ? orthography.ToUpper(glyph) : ToUpper(glyph);
		#endregion
	}
}
