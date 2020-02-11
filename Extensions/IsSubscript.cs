using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a subscript character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a subscript character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSubscript(this Char @char) => 0x2080 <= @char && @char <= 0x209C;

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a subscript character.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a subscript character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSubscript(this Rune rune) => 0x2080 <= rune.Value && rune.Value <= 0x209C;

	}
}
