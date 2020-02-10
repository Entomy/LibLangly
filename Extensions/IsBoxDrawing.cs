using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a box drawing character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a box drawing character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsBoxDrawing(this Char @char) => 0x2500 <= @char && @char <= 0x257F;

		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a box drawing character.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a box drawing character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsBoxDrawing(this Rune rune) => 0x2500 <= rune.Value && rune.Value <= 0x257F;
	}
}
