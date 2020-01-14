using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a subscript character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a subscript character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSubscript(this Char @char) => 0x2080 <= @char && @char <= 0x209C;
	}
}
