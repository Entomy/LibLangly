using System;
#if !NETSTANDARD1_6 && !NETSTANDARD2_0
using System.Text;
#endif

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a number.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a number; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsNumber(this Char @char) => Char.IsNumber(@char);

#if !NETSTANDARD1_6 && !NETSTANDARD2_0
		/// <summary>
		/// Indicates whether a Unicode character is categorized as a number.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a number; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsNumber(this Rune rune) => Rune.IsNumber(rune);
#endif
	}
}
