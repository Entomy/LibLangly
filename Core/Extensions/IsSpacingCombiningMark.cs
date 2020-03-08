using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a spacing combining mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a spacing combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSpacingCombiningMark(this Char @char) => @char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark;

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a spacing combining mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a spacing combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSpacingCombiningMark(this Rune rune) => rune.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark;
	}
}
