using System.Globalization;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char) => Char.ToUpper(@char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, modified according to <paramref name="culture"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char @char, CultureInfo culture) {
			if (culture is null) {
				throw new ArgumentNullException(nameof(culture));
			}
			return Char.ToUpper(@char, culture);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="char"/> parameter, or the unchanged value of <paramref name="char"/>, if <paramref name="char"/> is already uppercase or not alphabetic.</returns>
		public static Char ToUpperInvariant(this Char @char) => Char.ToUpperInvariant(@char);
	}
}
