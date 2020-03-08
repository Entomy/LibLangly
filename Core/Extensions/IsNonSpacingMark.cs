using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a non-spacing mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a non-spacing mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsNonSpacingMark(this Char @char) => @char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark;

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a non-spacing mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a non-spacing mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsNonSpacingMark(this Rune rune) => rune.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark;
	}
}
