using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Is the <paramref name="codePoint"/> ASCII?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if ASCII; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsAscii(UInt32 codePoint) => codePoint <= 0x7Fu;
	}
}
