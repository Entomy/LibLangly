using System;
using System.Runtime.CompilerServices;

namespace Stringier {
	/// <summary>
	/// Unsafe variants of algorithms.
	/// </summary>
	/// <remarks>
	/// <para>These are typically unsafe because they aren't type safe, don't have guarded parameters, etc. Whether generic or weakly typed, they are highly adaptable though. Intended use is to use this to implement a safe variant of the method, or as part of larger safe methods.</para>
	/// <para>These also slightly optimize many cases, as type information isn't necessary so the creation of a struct or ref struct never needs to happen.</para>
	/// </remarks>
	internal static class Unsafe {
		/// <summary>
		/// Is the <paramref name="codePoint"/> ASCII?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if ASCII; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsAscii(UInt32 codePoint) => codePoint <= 0x7Fu;

		/// <summary>
		/// Is the <paramref name="codePoint"/> in the Basic Multilingual Plane?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if in the Basic Multilingual Plane; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsBmp(UInt32 codePoint) => Plane(codePoint) == 0;

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

		/// <summary>
		/// Is the <paramref name="codePoint"/> a UNICODE Scalar Value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a UNICODE Scalar Value; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsScalarValue(UInt32 codePoint) => ((codePoint - 0x110000u) ^ 0xD800u) >= 0xFFEF0800u;

		/// <summary>
		/// Is the <paramref name="codePoint"/> in the Supplimentary Multilingual Plane?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if in the Supplimentary Multilingual Plane; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsSmp(UInt32 codePoint) => Plane(codePoint) == 1;

		/// <summary>
		/// Which UNICODE Plane does the <paramref name="codePoint"/> belong to?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns>A <see cref="UInt32"/> value corresponding to the UNICODE Plane.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Plane(UInt32 codePoint) => unchecked(codePoint >> 16);

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
		internal static UInt32 Utf16Decode(UInt32 highSurrogate, UInt32 lowSurrogate) => unchecked((highSurrogate << 10) + lowSurrogate - ((0xD800u << 10) + 0xDC00u - (1 << 16)));

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
		internal static void Utf16Encode(UInt32 smpScalarValue, out Char highSurrogate, out Char lowSurrogate) {
			highSurrogate = (Char)unchecked((smpScalarValue + ((0xD800u - 0x40u) << 10)) >> 10);
			lowSurrogate = (Char)unchecked((smpScalarValue & 0x03FFu) + 0xDC00u);
		}

		/// <summary>
		/// Gets the UTF-16 sequence length required to encode the UNICODE Scalar Value.
		/// </summary>
		/// <param name="scalarValue">The <see cref="UInt32"/> interpreted as a UNICODE Scalar Value.</param>
		/// <returns>A <see cref="UInt32"/> value for the amount of UTF-16 code units (<see cref="Char"/>) required.</returns>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a sequence length back. That length may be incorrect, especially if <paramref name="scalarValue"/> is not actually a UNICODE Scalar Value. And there's no error to tell you if a problem occured.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Utf16SequenceLength(UInt32 scalarValue) {
			unchecked {
				scalarValue -= 0x10000u;
				scalarValue += 2 << 24;
				scalarValue >>= 24;
			}
			return scalarValue;
		}

		/// <summary>
		/// Gets the UTF-8 sequence length required to encode the UNICODE Scalar Value.
		/// </summary>
		/// <param name="scalarValue">The <see cref="UInt32"/> interpreted as a UNICODE Scalar Value.</param>
		/// <returns>A <see cref="UInt32"/> value for the amount of UTF-8 code units (<see cref="Byte"/>) required.</returns>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a sequence length back. That length may be incorrect, especially if <paramref name="scalarValue"/> is not actually a UNICODE Scalar Value. And there's no error to tell you if a problem occured.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Utf8SequenceLength(UInt32 scalarValue) {
			unchecked {
				Int32 a = ((Int32)scalarValue - 0x0800) >> 31;
				scalarValue ^= 0xF800u;
				scalarValue -= 0xF880u;
				scalarValue += 4 << 24;
				scalarValue >>= 24;
				scalarValue += (UInt32)(a * 2);
			}
			return scalarValue;
		}

		/// <summary>
		/// Is the <paramref name="value"/> with the range (<paramref name="lower"/>..<paramref name="upper"/>).
		/// </summary>
		/// <param name="value">The <see cref="Byte"/> value to test.</param>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Within(this Byte value, Byte lower, Byte upper) => lower <= value && value <= upper;

		/// <summary>
		/// Is the <paramref name="value"/> with the range (<paramref name="lower"/>..<paramref name="upper"/>).
		/// </summary>
		/// <param name="value">The <see cref="UInt16"/> value to test.</param>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Within(this UInt16 value, UInt16 lower, UInt16 upper) => lower <= value && value <= upper;

		/// <summary>
		/// Is the <paramref name="value"/> with the range (<paramref name="lower"/>..<paramref name="upper"/>).
		/// </summary>
		/// <param name="value">The <see cref="UInt32"/> value to test.</param>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Within(this UInt32 value, UInt32 lower, UInt32 upper) => lower <= value && value <= upper;
	}
}
