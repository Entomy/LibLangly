using System;
using System.Runtime.InteropServices;

namespace Stringier {
	/// <summary>
	/// Represents a UTF-16 Surrogate Pair.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public readonly ref struct SurrogatePair {
		/// <summary>
		/// The high surrogate
		/// </summary>
		internal readonly CodePoint High;

		/// <summary>
		/// The low surrogate
		/// </summary>
		internal readonly CodePoint Low;

		/// <summary>
		/// Initializes a new <see cref="SurrogatePair"/> from the <paramref name="high"/> and <paramref name="low"/> <see cref="CodePoint"/>s.
		/// </summary>
		/// <param name="high">The high surrogate.</param>
		/// <param name="low">The low surrogate.</param>
		public SurrogatePair(CodePoint high, CodePoint low) {
			if (high.IsHighSurrogate) {
				High = high;
			} else {
				throw new ArgumentOutOfRangeException(nameof(high), "Code Point was not a high surrogate.");
			}
			if (low.IsLowSurrogate) {
				Low = low;
			} else {
				throw new ArgumentOutOfRangeException(nameof(low), "Code Point was not a low surrogate.");
			}
		}

		/// <summary>
		/// Initializes a new <see cref="SurrogatePair"/> from the <paramref name="codePoint"/> in the Supplimentary Multilingual Plane.
		/// </summary>
		/// <param name="codePoint">A <see cref="CodePoint"/> which must be in the Supplimentary Multilingual Plane.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="codePoint"/> was not in the Supplimentary Multilingual Plane.</exception>
		public SurrogatePair(CodePoint codePoint) {
			if (codePoint.Plane == 1) {
				Unsafe.Utf16Encode(codePoint.Value, out Char high, out Char low);
				High = new CodePoint(high);
				Low = new CodePoint(low);
			} else {
				throw new ArgumentOutOfRangeException(nameof(codePoint), "Code Point was not in the Supplimentary Multilingual Plane.");
			}
		}

		/// <summary>
		/// Gets the <see cref="CodePoint"/> this <see cref="SurrogatePair"/> represents.
		/// </summary>
		public CodePoint CodePoint => new CodePoint(Unsafe.Utf16Decode(High.Value, Low.Value));
	}
}
