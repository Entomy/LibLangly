using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a lowercase letter.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a lowercase letter; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLower(this Char @char) => Char.IsLower(@char);

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a lowercase letter.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a lowercase letter; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsLower(this Rune rune) => Rune.IsLower(rune);
	}
}
