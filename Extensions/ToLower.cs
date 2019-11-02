using System.Globalization;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="Char"/>, or the unchanged value of <paramref name="Char"/> if <paramref name="Char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		public static Char ToLower(this Char Char) => Char.ToLower(Char);

		/// <summary>
		/// Converts the value of a specified Unicode character to its lowercase equivalent using specified culture-specific formatting information.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <param name="Culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of <paramref name="Char"/>, modified according to <paramref name="Culture"/>, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLower(this Char Char, CultureInfo Culture) {
			if (Culture is null) {
				throw new ArgumentNullException(nameof(Culture));
			}
			return Char.ToLower(Char, Culture);
		}

		/// <summary>
		/// Converts the value of a Unicode character to its lowercase equivalent using the casing rules of the invariant culture.
		/// </summary>
		/// <param name="Char">The Unicode character to convert.</param>
		/// <returns>The lowercase equivalent of the <paramref name="Char"/> parameter, or the unchanged value of <paramref name="Char"/>, if <paramref name="Char"/> is already lowercase or not alphabetic.</returns>
		public static Char ToLowerInvariant(this Char Char) => Char.ToLowerInvariant(Char);
	}
}