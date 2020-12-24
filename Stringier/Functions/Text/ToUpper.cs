using System;
using System.Diagnostics.CodeAnalysis;
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

		/// <summary>
		/// Converts the text to its uppercase equivalent, invariant of orthography.
		/// </summary>
		/// <typeparam name="TText">The type of the text.</typeparam>
		/// <param name="text">The text to convert.</param>
		/// <returns>The upper equivalent of <paramref name="text"/>, or the unchanged <paramref name="text"/> if <paramref name="text"/> is already uppercase, has no uppercase equivalent, or is not alphabetic. If <paramref name="text"/> is <see langword="null"/> then this method returns <see langword="null"/>, otherwise there is always an instance.</returns>
		[return: MaybeNull, NotNullIfNotNull("text")]
		public static TText ToUpper<TText>([AllowNull] this ICased<TText> text) where TText : class, ICased<TText> => text?.ToUpper();
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

		/// <summary>
		/// Converts the text to its uppercase equivalent, using the casing rules of the specified orthography.
		/// </summary>
		/// <typeparam name="TText">The type of the text.</typeparam>
		/// <param name="text">The text to convert.</param>
		/// <param name="orthography">The <see cref="Orthography"/> instance describing the rules of the orthography.</param>
		/// <returns>The uppercase equivalent of <paramref name="text"/>, or the unchanged <paramref name="text"/> if <paramref name="text"/> is already uppercase, has no uppercase equivalent, or is not alphabetic. If <paramref name="text"/> is <see langword="null"/> then this method returns <see langword="null"/>, otherwise there is always an instance.</returns>
		/// <remarks>
		/// If <paramref name="orthography"/> is <see langword="null"/>, then the invariant should be used.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("text")]
		public static TText ToUpper<TText>([AllowNull] this ICased<TText> text, [AllowNull] Orthography orthography) where TText : class, ICased<TText> => text?.ToUpper(orthography);
		#endregion
	}
}
