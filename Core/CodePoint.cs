using System;
using System.Runtime.InteropServices;

namespace Stringier {
	/// <summary>
	/// Represents a UNICODE Code Point.
	/// </summary>
	[StructLayout(LayoutKind.Auto)]
	public readonly struct CodePoint {
		/// <summary>
		/// The actual value of this code point.
		/// </summary>
		internal readonly UInt32 value;

		/// <summary>
		/// Initialize a new <see cref="CodePoint"/> from the given <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="UInt32"/> of the UNICODE Code Point.</param>
		/// <exception cref="ArgumentOutOfRangeException">The <paramref name="value"/> was not a valid UNICODE Code Point.</exception>
		public CodePoint(Int32 value) {
			if (!Unsafe.IsCodePoint(value)) {
				throw new ArgumentOutOfRangeException(nameof(value), "The value was not a valid UNICODE Code Point.");
			}
			this.value = (UInt32)value;
		}

		/// <summary>
		/// Initialize a new <see cref="CodePoint"/> from the given <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="UInt32"/> of the UNICODE Code Point.</param>
		/// <exception cref="ArgumentOutOfRangeException">The <paramref name="value"/> was not a valid UNICODE Code Point.</exception>
		[CLSCompliant(false)]
		public CodePoint(UInt32 value) {
			if (!Unsafe.IsCodePoint(value)) {
				throw new ArgumentOutOfRangeException(nameof(value), "The value was not a valid UNICODE Code Point.");
			}
			this.value = value;
		}

		/// <summary>
		/// Initialize a new <see cref="CodePoint"/> from the given <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The <see cref="Char"/> of the UNICODE Code Point.</param>
		/// <exception cref="ArgumentOutOfRangeException">The <paramref name="value"/> was not a valid UNICODE Code Point.</exception>
		public CodePoint(Char value) => this.value = value;

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is an ASCII character.
		/// </summary>
		public Boolean IsAscii => Unsafe.IsAscii(value);

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is in the Basic Multilingual Plane.
		/// </summary>
		public Boolean IsBmp => Unsafe.IsBmp(value);

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is a UTF-16 high surrogate code point.
		/// </summary>
		public Boolean IsHighSurrogate => Unsafe.IsHighSurrogate(value);

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is a UTF-16 low surrogate code point.
		/// </summary>
		public Boolean IsLowSurrogate => Unsafe.IsLowSurrogate(value);

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is a valid UNICODE Scalar Value.
		/// </summary>
		public Boolean IsScalarValue => Unsafe.IsScalarValue(value);

		/// <summary>
		/// Gets whether this <see cref="CodePoint"/> is a UTF-16 surrogate code point.
		/// </summary>
		public Boolean IsSurrogate => Unsafe.IsSurrogate(value);

		/// <summary>
		/// Gets the UNICODE plane (0~16) which contains this code point.
		/// </summary>
		public Int32 Plane => (Int32)Unsafe.Plane(value);

		/// <summary>
		/// Gets the number of UTF-16 code units necessary to represent this value.
		/// </summary>
		public Int32 Utf16SequenceLength => (Int32)Unsafe.Utf16SequenceLength(value);

		/// <summary>
		/// Gets the number of UTF-8 code units necessary to represent this value.
		/// </summary>
		public Int32 Utf8SequenceLength => (Int32)Unsafe.Utf8SequenceLength(value);

		/// <summary>
		/// Gets this Code Point as an integer value.
		/// </summary>
		public Int32 Value => (Int32)value;

		public static Boolean operator !=(CodePoint left, CodePoint right) => !left.Equals(right);

		public static Boolean operator !=(CodePoint left, Int32 right) => !left.Equals(right);

		public static Boolean operator !=(Int32 left, CodePoint right) => !right.Equals(left);

		[CLSCompliant(false)]
		public static Boolean operator !=(CodePoint left, UInt32 right) => !left.Equals(right);

		[CLSCompliant(false)]
		public static Boolean operator !=(UInt32 left, CodePoint right) => !right.Equals(left);

		public static Boolean operator !=(CodePoint left, Char right) => !left.Equals(right);

		public static Boolean operator !=(Char left, CodePoint right) => !right.Equals(left);

		public static Boolean operator ==(CodePoint left, CodePoint right) => left.Equals(right);

		public static Boolean operator ==(CodePoint left, Int32 right) => left.Equals(right);

		public static Boolean operator ==(Int32 left, CodePoint right) => right.Equals(left);

		[CLSCompliant(false)]
		public static Boolean operator ==(CodePoint left, UInt32 right) => left.Equals(right);

		[CLSCompliant(false)]
		public static Boolean operator ==(UInt32 left, CodePoint right) => right.Equals(left);

		public static Boolean operator ==(CodePoint left, Char right) => left.Equals(right);

		public static Boolean operator ==(Char left, CodePoint right) => right.Equals(left);

		[CLSCompliant(false)]
		public static UInt32 operator +(CodePoint left, UInt32 right) => left.value + right;

		[CLSCompliant(false)]
		public static UInt32 operator +(UInt32 left, CodePoint right) => left + right.value;

		[CLSCompliant(false)]
		public static UInt32 operator -(CodePoint left, UInt32 right) => left.value - right;

		[CLSCompliant(false)]
		public static UInt32 operator -(UInt32 left, CodePoint right) => left - right.value;

		[CLSCompliant(false)]
		public static UInt32 operator *(CodePoint left, UInt32 right) => left.value * right;

		[CLSCompliant(false)]
		public static UInt32 operator *(UInt32 left, CodePoint right) => left * right.value;

		[CLSCompliant(false)]
		public static UInt32 operator /(CodePoint left, UInt32 right) => left.value / right;

		[CLSCompliant(false)]
		public static UInt32 operator /(UInt32 left, CodePoint right) => left / right.value;

		[CLSCompliant(false)]
		public static UInt32 operator %(CodePoint left, UInt32 right) => left.value % right;

		[CLSCompliant(false)]
		public static UInt32 operator %(UInt32 left, CodePoint right) => left % right.value;

		[CLSCompliant(false)]
		public static UInt32 operator &(CodePoint left, UInt32 right) => left.value & right;

		[CLSCompliant(false)]
		public static UInt32 operator &(UInt32 left, CodePoint right) => left & right.value;

		[CLSCompliant(false)]
		public static UInt32 operator |(CodePoint left, UInt32 right) => left.value | right;

		[CLSCompliant(false)]
		public static UInt32 operator |(UInt32 left, CodePoint right) => left | right.value;

		[CLSCompliant(false)]
		public static UInt32 operator ^(CodePoint left, UInt32 right) => left.value ^ right;

		[CLSCompliant(false)]
		public static UInt32 operator ^(UInt32 left, CodePoint right) => left ^ right.value;

		[CLSCompliant(false)]
		public static UInt32 operator <<(CodePoint left, Int32 right) => left.value << right;

		[CLSCompliant(false)]
		public static UInt32 operator >>(CodePoint left, Int32 right) => left.value >> right;

		/// <summary>
		/// Returns a value that indicates whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns><see langword="true"/> if equal to the value of this instance; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Int32 value:
				return Equals(value);
			case UInt32 value:
				return Equals(value);
			case Char value:
				return Equals(value);
			default:
				return false;
			}
		}

		/// <summary>
		/// Returns a value that indicates whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="other">The object to compare to.</param>
		/// <returns><see langword="true"/> if equal to the value of this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(CodePoint other) => value == other.value;

		/// <summary>
		/// Returns a value that indicates whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="other">The object to compare to.</param>
		/// <returns><see langword="true"/> if equal to the value of this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Int32 other) => value == other;

		/// <summary>
		/// Returns a value that indicates whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="other">The object to compare to.</param>
		/// <returns><see langword="true"/> if equal to the value of this instance; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public Boolean Equals(UInt32 other) => value == other;

		/// <summary>
		/// Returns a value that indicates whether this instance is equal to a specified object.
		/// </summary>
		/// <param name="other">The object to compare to.</param>
		/// <returns><see langword="true"/> if equal to the value of this instance; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Char other) => value == other;

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		/// <remarks>
		/// The hash code of a <see cref="CodePoint"/> is always the integer value of the code point.
		/// </remarks>
		public override Int32 GetHashCode() => Value;

		/// <summary>
		/// Converts the value of this instance to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of the value of this instance.</returns>
		/// <remarks>
		/// This string is always prefixed with <c>U+</c>, and depending on the value, may be an additional 2, 4, or 6 characters long.
		/// </remarks>
		public override String ToString() {
			if (value > 0xFFFF) {
				return $"U+{value:X6}";
			} else if (value > 0xFF) {
				return $"U+{value:X4}";
			} else {
				return $"U+{value:X2}";
			}
		}
	}
}
