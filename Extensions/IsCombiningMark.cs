using System;
#if !NETSTANDARD2_0
using System.Text;
#endif

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a combining mark.
		/// </summary>
		/// <param name="char">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="char"/> is a combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsCombiningMark(this Char @char) => 0x0300 <= @char && @char <= 0x036F
			|| 0x1AB0 <= @char && @char <= 0x1ABE
			|| 0x1DC0 <= @char && @char <= 0x1DF9
			|| 0x1DFB <= @char && @char <= 0x1DFF
			|| 0x20D0 <= @char && @char <= 0x20f0
			|| 0xFE20 <= @char && @char <= 0xFE2F;

#if !NETSTANDARD2_0
		/// <summary>
		/// Indicates whether the specified Unicode character is categorized as a combining mark.
		/// </summary>
		/// <param name="rune">The Unicode character to evaluate.</param>
		/// <returns><see langword="true"/> if <paramref name="rune"/> is a combining mark; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsCombiningMark(this Rune rune) => 0x0300 <= rune.Value && rune.Value <= 0x036F
			|| 0x1AB0 <= rune.Value && rune.Value <= 0x1ABE
			|| 0x1DC0 <= rune.Value && rune.Value <= 0x1DF9
			|| 0x1DFB <= rune.Value && rune.Value <= 0x1DFF
			|| 0x20D0 <= rune.Value && rune.Value <= 0x20f0
			|| 0xFE20 <= rune.Value && rune.Value <= 0xFE2F;
#endif
	}
}
