using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether this <see cref="Char"/> is categorized as white space.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is white space; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsWhiteSpace(this Char @char) => Char.IsWhiteSpace(@char);

		/// <summary>
		/// Indicates whether this <see cref="Rune"/> is categorized as white space.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is white space; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsWhiteSpace(this Rune rune) => Rune.IsWhiteSpace(rune);
	}
}
