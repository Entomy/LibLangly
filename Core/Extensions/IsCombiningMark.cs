using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a combining mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsCombiningMark(this Char @char) {
			switch (@char.GetUnicodeCategory()) {
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
				return true;
			default:
				return false;
			}
		}

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a combining mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsCombiningMark(this Rune rune) {
			switch (rune.GetUnicodeCategory()) {
			case UnicodeCategory.NonSpacingMark:
			case UnicodeCategory.SpacingCombiningMark:
			case UnicodeCategory.EnclosingMark:
				return true;
			default:
				return false;
			}
		}
	}
}
