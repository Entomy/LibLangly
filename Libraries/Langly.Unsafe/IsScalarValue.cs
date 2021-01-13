using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Is the <paramref name="codePoint"/> a UNICODE Scalar Value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a UNICODE Scalar Value; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsScalarValue(UInt32 codePoint) => ((codePoint - 0x110000u) ^ 0xD800u) >= 0xFFEF0800u;
	}
}
