using System;
using System.Globalization;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char) => Char.ToUpper(@char);

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune) => Rune.ToUpper(rune, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Char.ToUpper(@char, culture);
		}

		/// <summary>
		/// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Rune.ToUpper(rune, culture);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="char"/> parameter, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already uppercase or not alphabetic.</returns>
		public static Char ToUpperInvariant(this Char @char) => Char.ToUpperInvariant(@char);

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="rune"/> parameter, or the unchanged value of <paramref name="rune"/>, if <paramref name="rune"/> is already uppercase or not alphabetic.</returns>
		public static Rune ToUpperInvariant(this Rune rune) => Rune.ToUpperInvariant(rune);
	}
}
