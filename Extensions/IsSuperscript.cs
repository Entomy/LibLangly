using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as a superscript character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a superscript character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSuperscript(this Char @char) => @char == 0xB2 || @char == 0xB3 || @char == 0xB9 || (0x2070 <= @char && @char <= 0x207F);

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as a superscript character.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a superscript character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSuperscript(this Rune rune) => rune.Value == 0xB2 || rune.Value == 0xB3 || rune.Value == 0xB9 || (0x2070 <= rune.Value && rune.Value <= 0x207F);
	}
}
