using Defender;
using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class Text {
		#region ToLower(Element)
		/// <summary>
		/// Converts the value of a UNICODE Character to its lowercase equivalent.
		/// </summary>
		/// <param name="char">The UNICODE Character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Char ToLower(this Char @char) => CultureInfo.CurrentCulture.TextInfo.ToLower(@char);

		/// <summary>
		/// Converts the value of a UNICODE Character to its lowercase equivalent.
		/// </summary>
		/// <param name="rune">The UNICODE Character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Rune ToLower(this Rune rune) => Rune.ToLower(rune, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts the value of a UNICODE Grapheme Cluster to its lowercase equivalent.
		/// </summary>
		/// <param name="glyph">The UNICODE Grapheme Cluster to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Glyph ToLower(this Glyph glyph) => Glyph.ToLower(glyph, CultureInfo.CurrentCulture);
		#endregion

		#region ToLower(Element, CultureInfo)
		/// <summary>
		/// Converts the value of a UNICODE Character to its lowercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="char">The UNICODE Character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Char ToLower(this Char @char, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return culture.TextInfo.ToLower(@char);
		}

		/// <summary>
		/// Converts the value of a UNICODE Character to its lowercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="rune">The UNICODE Character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Rune ToLower(this Rune rune, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Rune.ToLower(rune, culture);
		}

		/// <summary>
		/// Converts the value of a UNICODE Grapheme Cluster to its lowercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="glyph">The UNICODE Grapheme Cluster to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToLower(this Glyph glyph, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Glyph.ToLower(glyph, culture);
		}
		#endregion
	}
}
