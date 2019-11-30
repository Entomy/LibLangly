using System;
using System.Globalization;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Char ToLower(this Char @char) => Char.ToLower(@char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLower(this Char @char, CultureInfo culture) {
			if (culture is null) {
				throw new ArgumentNullException(nameof(culture));
			}
			return Char.ToLower(@char, culture);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of the <paramref name="char"/> parameter, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLowerInvariant(this Char @char) => Char.ToLowerInvariant(@char);
	}
}