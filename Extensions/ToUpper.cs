using System.Globalization;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="Char"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char Char) => Char.ToUpper(Char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <param name="Culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of <paramref name="Char"/>, modified according to <paramref name="Culture"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		public static Char ToUpper(this Char Char, CultureInfo Culture) {
			if (Culture is null) {
				throw new ArgumentNullException(nameof(Culture));
			}
			return Char.ToUpper(Char, Culture);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The uppercase equivalent of the <paramref name="Char"/> parameter, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already uppercase or not alphabetic.</returns>
		public static Char ToUpperInvariant(this Char Char) => Char.ToUpperInvariant(Char);
	}
}
