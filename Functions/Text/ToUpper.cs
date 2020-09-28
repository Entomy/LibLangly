using Defender;
using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class Text {
		#region ToUpper(Element)
		/// <summary>
		/// Converts the value of a UNICODE Character to its uppercase equivalent.
		/// </summary>
		/// <param name="char">The UNICODE Character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Char ToUpper(this Char @char) => CultureInfo.CurrentCulture.TextInfo.ToUpper(@char);

		/// <summary>
		/// Converts the value of a UNICODE Character to its uppercase equivalent.
		/// </summary>
		/// <param name="rune">The UNICODE Character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Rune ToUpper(this Rune rune) => Rune.ToUpper(rune, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts the value of a UNICODE Grapheme Cluster to its uppercase equivalent.
		/// </summary>
		/// <param name="glyph">The UNICODE Grapheme Cluster to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		/// <remarks>
		/// Casing rules are obtained from the current culture's orthography.
		/// </remarks>
		[Obsolete("The behavior of this method is inconsistent and often misunderstood: consider using an explicit CultureInfo or Orthography.")]
		public static Glyph ToUpper(this Glyph glyph) => Glyph.ToUpper(glyph, CultureInfo.CurrentCulture);
		#endregion

		#region ToUpper(Element, CultureInfo)
		/// <summary>
		/// Converts the value of a UNICODE Character to its uppercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="char">The UNICODE Character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return culture.TextInfo.ToUpper(@char);
		}

		/// <summary>
		/// Converts the value of a UNICODE Character to its uppercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="rune">The UNICODE Character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Rune.ToUpper(rune, culture);
		}

		/// <summary>
		/// Converts the value of a UNICODE Grapheme Cluster to its uppercase equivalent, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="glyph">The UNICODE Grapheme Cluster to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Glyph ToUpper(this Glyph glyph, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Glyph.ToUpper(glyph, culture);
		}
		#endregion
	}
}
