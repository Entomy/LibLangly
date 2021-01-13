using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Which UNICODE Plane does the <paramref name="codePoint"/> belong to?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns>A <see cref="UInt32"/> value corresponding to the UNICODE Plane.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Plane(UInt32 codePoint) => unchecked(codePoint >> 16);
	}
}
