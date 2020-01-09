using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a symbol character.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a symbol character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSymbol(this Char @char) => Char.IsSymbol(@char);

#if NETCOREAPP3_0 || NETCOREAPP3_1
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a symbol character.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a symbol character; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsSymbol(this Rune rune) => Rune.IsSymbol(rune);
#endif
	}
}
