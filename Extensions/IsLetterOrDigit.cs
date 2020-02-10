using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a letter or a decimal digit.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a letter or a decimal digit; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLetterOrDigit(this Char @char) => Char.IsLetterOrDigit(@char);

		/// <summary>
		/// Indicates whether a Unicode character is categorized as a letter or a decimal digit.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a letter or a decimal digit; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLetterOrDigit(this Rune rune) => Rune.IsLetterOrDigit(rune);
	}
}
