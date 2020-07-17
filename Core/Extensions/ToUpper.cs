using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts this <see cref="Char"/> to its uppercase equivalent.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char) => Char.ToUpper(@char);

		/// <summary>
		/// Converts this <see cref="Rune"/> to its uppercase equivalent.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune) => Rune.ToUpper(rune, CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts this <see cref="Array"/> of <see cref="Char"/> to its uppercase equivalent.
		/// </summary>
		/// <param name="chars">The array of Unicode characters to convert.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char[] ToUpper(this Char[] chars) => chars.ToUpper(CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts this <see cref="IEnumerable{T}"/> of <see cref="Char"/> to its uppercase equivalent.
		/// </summary>
		/// <param name="chars">The enumerable of Unicode characters to convert.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static IEnumerable<Char> ToUpper(this IEnumerable<Char> chars) => chars.ToUpper(CultureInfo.CurrentCulture);

		/// <summary>
		/// Converts this <see cref="Array"/> of <see cref="Char"/> to its uppercase equivalents.
		/// </summary>
		/// <param name="chars">The array of Unicode characters to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char[] ToUpper(this Char[] chars, CultureInfo culture) {
			Char[] result = new Char[chars.Length];
			for (Int32 i = 0; i < chars.Length; i++) {
				result[i] = chars[i].ToUpper(culture);
			}
			return result;
		}

		/// <summary>
		/// Converts this <see cref="IEnumerable{T}"/> of <see cref="Char"/> to its uppercase equivalents.
		/// </summary>
		/// <param name="chars">The enumerable of Unicode characters to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static IEnumerable<Char> ToUpper(this IEnumerable<Char> chars, CultureInfo culture) {
			Char[] result = new Char[chars.Count()];
			Int32 r = 0;
			foreach (Char @char in chars) {
				result[r++] = @char.ToUpper(culture);
			}
			return result;
		}

		/// <summary>
		/// Converts this <see cref="Char"/> to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Char.ToUpper(@char, culture);
		}

		/// <summary>
		/// Converts this <see cref="Rune"/> to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Rune ToUpper(this Rune rune, CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			return Rune.ToUpper(rune, culture);
		}

		/// <summary>
		/// Converts this <see cref="Char"/> to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="char"/> parameter, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already uppercase or not alphabetic.</returns>
		public static Char ToUpperInvariant(this Char @char) => Char.ToUpperInvariant(@char);

		/// <summary>
		/// Converts this <see cref="Rune"/> to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="rune">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="rune"/> parameter, or the unchanged value of <paramref name="rune"/>, if <paramref name="rune"/> is already uppercase or not alphabetic.</returns>
		public static Rune ToUpperInvariant(this Rune rune) => Rune.ToUpperInvariant(rune);

		/// <summary>
		/// Converts this <see cref="Array"/> of <see cref="Char"/> to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="chars">The array of Unicode characters to convert.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char[] ToUpperInvariant(this Char[] chars) => chars.ToUpper(CultureInfo.InvariantCulture);

		/// <summary>
		/// Converts this <see cref="IEnumerable{T}"/> of <see cref="Char"/> to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="chars">The enumerable of Unicode characters to convert.</param>
		/// <returns>The uppercase equivalent of all of the <paramref name="chars"/>, with unchanged values if the <see cref="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static IEnumerable<Char> ToUpperInvariant(this IEnumerable<Char> chars) => chars.ToUpper(CultureInfo.InvariantCulture);
	}
}
