using System;
using System.Runtime.CompilerServices;

namespace Stringier {
	/// <summary>
	/// Unsafe variants of algorithms
	/// </summary>
	/// <remarks>
	/// <para>These are typically unsafe because they aren't type safe. That lack of type saftey is why these aren't publically exposed.</para>
	/// <para>These also slightly optimize many cases, as type information isn't necessary so the creation of a struct or ref struct never needs to happen.</para>
	/// </remarks>
	internal static class Unsafe {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsAscii(UInt32 codePoint) => codePoint <= 0x7Fu;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsBmp(UInt32 codePoint) => Plane(codePoint) == 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsCodePoint(Int32 value) => value >= 0 && IsCodePoint((UInt32)value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsCodePoint(UInt32 value) => value <= 0x10FFFFu;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsHighSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xD800u <= 0x03FFu);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsLowSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xDC00u <= 0x03FFu);

		//TODO: Optimize this
		//Microsofts approach for calculating this confuses me and seems to be an error. The end bit `>= 0xFFEF0800u` is odd in that an UIn32 value could never be that large, so it seems like it would always return false. Their own code analyzer even agrees with me that this looks odd.
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsScalarValue(UInt32 value) => value <= 0xD7FF || 0xDE00 <= value || value <= 0x10FFFF;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsSmp(UInt32 codePoint) => Plane(codePoint) == 1;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean IsSurrogate(UInt32 codePoint) => unchecked((codePoint - 0xD800u) <= 0x07FFFu);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Plane(UInt32 codePoint) => unchecked(codePoint >> 16);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Utf16Decode(UInt32 highSurrogate, UInt32 lowSurrogate) => unchecked((highSurrogate << 10) + lowSurrogate - ((0xD800u << 10) + 0xDC00u - (1 << 16)));

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Utf16Encode(UInt32 smpScalarValue, out Char highSurrogate, out Char lowSurrogate) {
			highSurrogate = (Char)unchecked((smpScalarValue + ((0xD800u - 0x40u) << 10)) >> 10);
			lowSurrogate = (Char)unchecked((smpScalarValue & 0x03FFu) + 0xDC00u);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt32 Utf16SequenceLength(UInt32 scalarValue) {
			unchecked {
				scalarValue -= 0x10000u;
				scalarValue += 2 << 24;
				scalarValue >>= 24;
			}
			return scalarValue;
		}

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
	}
}
