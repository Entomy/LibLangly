using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Is the <paramref name="value"/> a codepoint?
		/// </summary>
		/// <param name="value">The <see cref="Int32"/> value.</param>
		/// <returns><see langword="true"/> if codepoint; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsCodePoint(Int32 value) => value >= 0 && IsCodePoint((UInt32)value);

		/// <summary>
		/// Is the <paramref name="value"/> a codepoint?
		/// </summary>
		/// <param name="value">The <see cref="UInt32"/> value.</param>
		/// <returns><see langword="true"/> if codepoint; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsCodePoint(UInt32 value) => value <= 0x10FFFFu;
	}
}
