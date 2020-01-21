//! This exists to backport Rune to older runtimes, since we're going to take advantage of it throughout the entire project, so it must exist. By conditionally including it, and multitargeting both runtimes without and with the Rune type, it can be provided without colliding.
//! This (public) API must match the official one exactly. As such, copyright belongs to the .NET Foundation. The internals can be implemented using existing API's in Core.

#if NETSTANDARD2_0
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using Stringier;

namespace System.Text {
	/// <summary>
	/// Represents a Unicode scalar value ([ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive).
	/// </summary>
	/// <remarks>
	/// This type's constructors and conversion operators validate the input, so consumers can call the APIs
	/// assuming that the underlying <see cref="Rune"/> instance is well-formed.
	/// </remarks>
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public readonly struct Rune : IComparable<Rune>, IEquatable<Rune> {
		/// <summary>
		/// The UNICODE Scalar Value.
		/// </summary>
		private readonly UInt32 value;

		/// <summary>
		/// Creates a <see cref="Rune"/> from the provided UTF-16 code unit.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// If <paramref name="ch"/> represents a UTF-16 surrogate code point
		/// U+D800..U+DFFF, inclusive.
		/// </exception>
		public Rune(Char ch) {
			if (Unsafe.IsSurrogate(ch)) {
				throw new ArgumentOutOfRangeException(nameof(ch), "The char is not a valid UNICODE Scalar Value.");
			}
			value = ch;
		}

		/// <summary>
		/// Creates a <see cref="Rune"/> from the provided UTF-16 surrogate pair.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// If <paramref name="highSurrogate"/> does not represent a UTF-16 high surrogate code point
		/// or <paramref name="lowSurrogate"/> does not represent a UTF-16 low surrogate code point.
		/// </exception>
		public Rune(Char highSurrogate, Char lowSurrogate) : this(new SurrogatePair(new CodePoint(highSurrogate), new CodePoint(lowSurrogate)).CodePoint.Value) { }

		/// <summary>
		/// Creates a <see cref="Rune"/> from the provided Unicode scalar value.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// If <paramref name="value"/> does not represent a value Unicode scalar value.
		/// </exception>
		public Rune(Int32 value) : this((UInt32)value) { }

		/// <summary>
		/// Creates a <see cref="Rune"/> from the provided Unicode scalar value.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// If <paramref name="value"/> does not represent a value Unicode scalar value.
		/// </exception>
		[CLSCompliant(false)]
		public Rune(UInt32 value) {
			if (!Unsafe.IsScalarValue(value)) {
				throw new ArgumentOutOfRangeException(nameof(value), "The value is not a valid UNICODE Scalar Value");
			}
			this.value = value;
		}

		public static Boolean operator ==(Rune left, Rune right) => left.value == right.value;

		public static Boolean operator !=(Rune left, Rune right) => left.value != right.value;

		public static Boolean operator <(Rune left, Rune right) => left.value < right.value;

		public static Boolean operator <=(Rune left, Rune right) => left.value <= right.value;

		public static Boolean operator >(Rune left, Rune right) => left.value > right.value;

		public static Boolean operator >=(Rune left, Rune right) => left.value >= right.value;

		public static explicit operator Rune(Char ch) => new Rune(ch);

		[CLSCompliant(false)]
		public static explicit operator Rune(UInt32 value) => new Rune(value);

		public static explicit operator Rune(Int32 value) => new Rune(value);

		// Displayed as "'<char>' (U+XXXX)"; e.g., "'e' (U+0065)"
		private String DebuggerDisplay => FormattableString.Invariant($"U+{value:X4} '{(IsValid(value) ? ToString() : "\uFFFD")}'");

		/// <summary>
		/// Returns true if and only if this scalar value is ASCII ([ U+0000..U+007F ])
		/// and therefore representable by a single UTF-8 code unit.
		/// </summary>
		public Boolean IsAscii => Unsafe.IsAscii(value);

		/// <summary>
		/// Returns true if and only if this scalar value is within the BMP ([ U+0000..U+FFFF ])
		/// and therefore representable by a single UTF-16 code unit.
		/// </summary>
		public Boolean IsBmp => Unsafe.IsBmp(value);

		/// <summary>
		/// Returns the Unicode plane (0 to 16, inclusive) which contains this scalar.
		/// </summary>
		public Int32 Plane => (Int32)Unsafe.Plane(value);

		/// <summary>
		/// A <see cref="Rune"/> instance that represents the Unicode replacement character U+FFFD.
		/// </summary>
		public static Rune ReplacementChar { get; } = new Rune(0xFFFD);

		/// <summary>
		/// Returns the length in code units (<see cref="char"/>) of the
		/// UTF-16 sequence required to represent this scalar value.
		/// </summary>
		/// <remarks>
		/// The return value will be 1 or 2.
		/// </remarks>
		public Int32 Utf16SequenceLength => (Int32)Unsafe.Utf16SequenceLength(value);

		/// <summary>
		/// Returns the length in code units of the
		/// UTF-8 sequence required to represent this scalar value.
		/// </summary>
		/// <remarks>
		/// The return value will be 1 through 4, inclusive.
		/// </remarks>
		public Int32 Utf8SequenceLength => (Int32)Unsafe.Utf8SequenceLength(value);


		/// <summary>
		/// Returns the Unicode scalar value as an integer.
		/// </summary>
		public Int32 Value => (Int32)value;

		public Int32 CompareTo(Rune other) => value.CompareTo(other.value);

		public override Boolean Equals(Object? obj) => (obj is Rune other) && Equals(other);

		public Boolean Equals(Rune other) => this == other;

		public override Int32 GetHashCode() => Value;

		/// <summary>
		/// Returns <see langword="true"/> iff <paramref name="value"/> is a valid Unicode scalar
		/// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
		/// </summary>
		public static Boolean IsValid(Int32 value) => IsValid((UInt32)value);

		/// <summary>
		/// Returns <see langword="true"/> iff <paramref name="value"/> is a valid Unicode scalar
		/// value, i.e., is in [ U+0000..U+D7FF ], inclusive; or [ U+E000..U+10FFFF ], inclusive.
		/// </summary>
		[CLSCompliant(false)]
		public static Boolean IsValid(UInt32 value) => Unsafe.IsScalarValue(value);

		/// <summary>
		/// Encodes this <see cref="Rune"/> to a UTF-16 destination buffer.
		/// </summary>
		/// <param name="destination">The buffer to which to write this value as UTF-16.</param>
		/// <returns>The number of <see cref="Char"/>s written to <paramref name="destination"/>.</returns>
		/// <exception cref="ArgumentException">
		/// If <paramref name="destination"/> is not large enough to hold the output.
		/// </exception>
		public Int32 EncodeToUtf16(Span<Char> destination) {
			if (!TryEncodeToUtf16(destination, out Int32 charsWritten)) {
				throw new ArgumentException("Destination too short", nameof(destination));
			}
			return charsWritten;
		}

		/// <summary>
		/// Encodes this <see cref="Rune"/> to a UTF-16 destination buffer.
		/// </summary>
		/// <param name="destination">The buffer to which to write this value as UTF-16.</param>
		/// <param name="charsWritten">
		/// The number of <see cref="Char"/>s written to <paramref name="destination"/>,
		/// or 0 if the destination buffer is not large enough to contain the output.</param>
		/// <returns>True if the value was written to the buffer; otherwise, false.</returns>
		/// <remarks>
		/// The <see cref="Utf16SequenceLength"/> property can be queried ahead of time to determine
		/// the required size of the <paramref name="destination"/> buffer.
		/// </remarks>
		public Boolean TryEncodeToUtf16(Span<Char> destination, out Int32 charsWritten) {
			if (destination.Length >= 1) {
				if (new CodePoint(value).IsBmp) {
					destination[0] = (Char)value;
					charsWritten = 1;
					return true;
				} else if (destination.Length >= 2) {
					SurrogatePair surrogates = new SurrogatePair(new CodePoint(value));
					destination[0] = (Char)surrogates.High.Value;
					destination[1] = (Char)surrogates.Low.Value;
					charsWritten = 2;
					return true;
				}
			}

			// Destination buffer not large enough

			charsWritten = default;
			return false;
		}
	}
}
#endif