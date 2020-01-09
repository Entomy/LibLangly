using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a separator character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a separator character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSeparator(this Char @char) => Char.IsSeparator(@char);

#if NETCOREAPP3_1
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a separator character.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a separator character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSeparator(this Rune rune) => Rune.IsSeparator(rune);
#endif
	}
}
