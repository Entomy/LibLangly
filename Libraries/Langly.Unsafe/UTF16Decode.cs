using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Decodes the UTF-16 Surrogate Pairs into a UNICODE Scalar Value.
		/// </summary>
		/// <param name="highSurrogate">The <see cref="UInt32"/> interpreted as the high surrogate.</param>
		/// <param name="lowSurrogate">The <see cref="UInt32"/> interpreted as the low surrogate.</param>
		/// <returns>A <see cref="UInt32"/> representing the UNICODE Scalar Value.</returns>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a value back. That value may be incorrect, and there's no error to tell you if it is.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 UTF16Decode(UInt32 highSurrogate, UInt32 lowSurrogate) => unchecked((highSurrogate << 10) + lowSurrogate - ((0xD800u << 10) + 0xDC00u - (1 << 16)));
	}
}
