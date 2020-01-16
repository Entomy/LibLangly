using System;
#if !NETSTANDARD1_6 && !NETSTANDARD2_0
using System.Text;
#endif

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is white space; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsWhiteSpace(this Char @char) => Char.IsWhiteSpace(@char);

#if !NETSTANDARD1_6 && !NETSTANDARD2_0
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as white space.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is white space; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsWhiteSpace(this Rune rune) => Rune.IsWhiteSpace(rune);
#endif
	}
}
