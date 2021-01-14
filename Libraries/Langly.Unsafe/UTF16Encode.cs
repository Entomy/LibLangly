using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Encodes the UNICODE Scalar Value into UTF-16 high and low surrogates, assuming <paramref name="smpScalarValue"/> is in the Supplimentary Multilingual Plane.
		/// </summary>
		/// <param name="smpScalarValue">The <see cref="UInt32"/> interpreted as the UNICODE Scalar Value in the Supplimentary Multilingual Plane.</param>
		/// <param name="highSurrogate">A <see cref="UInt32"/> representing the high surrogate.</param>
		/// <param name="lowSurrogate">A <see cref="UInt32"/> representing the low surrogate.</param>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a surrogate pair back. Those may be incorrect. They may not even be actual surrogates. And there's no error to tell you if a problem occured.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void UTF16Encode(UInt32 smpScalarValue, out Char highSurrogate, out Char lowSurrogate) {
			highSurrogate = (Char)unchecked((smpScalarValue + ((0xD800u - 0x40u) << 10)) >> 10);
			lowSurrogate = (Char)unchecked((smpScalarValue & 0x03FFu) + 0xDC00u);
		}
	}
}
