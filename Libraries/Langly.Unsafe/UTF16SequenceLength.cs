using System;
using System.Runtime.CompilerServices;

namespace Langly {
	internal static partial class Unsafe {
		/// <summary>
		/// Gets the UTF-16 sequence length required to encode the UNICODE Scalar Value.
		/// </summary>
		/// <param name="scalarValue">The <see cref="UInt32"/> interpreted as a UNICODE Scalar Value.</param>
		/// <returns>A <see cref="UInt32"/> value for the amount of UTF-16 code units (<see cref="Char"/>) required.</returns>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a sequence length back. That length may be incorrect, especially if <paramref name="scalarValue"/> is not actually a UNICODE Scalar Value. And there's no error to tell you if a problem occured.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 UTF16SequenceLength(UInt32 scalarValue) {
			unchecked {
				scalarValue -= 0x10000u;
				scalarValue += 2 << 24;
				scalarValue >>= 24;
			}
			return scalarValue;
		}
	}
}
