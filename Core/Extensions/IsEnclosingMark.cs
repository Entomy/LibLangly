using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as an enclosing mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is an enclosing mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsEnclosingMark(this Char @char) => @char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark;

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as an enclosing mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is an enclosing mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsEnclosingMark(this Rune rune) => rune.GetUnicodeCategory() == UnicodeCategory.EnclosingMark;
	}
}
