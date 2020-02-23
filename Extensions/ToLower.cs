using System;
using System.Globalization;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts this <see cref="Char"/> to its lowercase equivalent.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Char ToLower(this Char @char) => Char.ToLower(@char);

		/// <summary>
		/// Converts this <see cref="Rune"/> to its lowercase equivalent.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Rune ToLower(this Rune rune) => Rune.ToLower(rune, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts this <see cref="Char"/> to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLower(this Char @char, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Char.ToLower(@char, culture);
		}

		/// <summary>
		/// Converts this <see cref="Rune"/> to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="rune"/>, if <paramref name="rune"/> is already lowercase or not alphabetic.</returns>
		public static Rune ToLower(this Rune rune, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Rune.ToLower(rune, culture);
		}

		/// <summary>
		/// Converts this <see cref="Char"/> to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of the <paramref name="char"/> parameter, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLowerInvariant(this Char @char) => Char.ToLowerInvariant(@char);

		/// <summary>
		/// Converts this <see cref="Rune"/> to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of the <paramref name="rune"/> parameter, or the unchanged value of <paramref name="rune"/>, if <paramref name="rune"/> is already lowercase or not alphabetic.</returns>
		public static Rune ToLowerInvariant(this Rune rune) => Rune.ToLowerInvariant(rune);
	}
}