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
	public static class Unsafe {
		/// <summary>
		/// Calculates the Hamming edit-distance, <typeparamref name="T"/>-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <typeparam name="T">The type of elements being analyzed.</typeparam>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 HammingDistance<T>(ReadOnlySpan<T> source, ReadOnlySpan<T> other) where T : IEquatable<T> {
			Int32 d = 0;
			for (Int32 i = 0; i < source.Length; i++) {
				if (!source[i].Equals(other[i])) {
					d++;
				}
			}
			return d;
		}

		/// <summary>
		/// Is the <paramref name="codePoint"/> ASCII?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if ASCII; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsAscii(UInt32 codePoint) => codePoint <= 0x7Fu;

		/// <summary>
		/// Is the <paramref name="codePoint"/> in the Basic Multilingual Plane?
		/// </summary>
		/// <param name="codePoint"></param>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if in the Basic Multilingual Plane; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsBmp(UInt32 codePoint) => Plane(codePoint) == 0;

		/// <summary>
		/// Is the <paramref name="value"/> a codepoint?
		/// </summary>
		/// <param name="value">The <see cref="Int32"/> value.</param>
		/// <returns><see langword="true"/> if codepoint; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsCodePoint(Int32 value) => value >= 0 && IsCodePoint((UInt32)value);

		/// <summary>
		/// Is the <paramref name="value"/> a codepoint?
		/// </summary>
		/// <param name="value">The <see cref="UInt32"/> value.</param>
		/// <returns><see langword="true"/> if codepoint; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsCodePoint(UInt32 value) => value <= 0x10FFFFu;

		/// <summary>
		/// Is the <paramref name="codePoint"/> a high surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if high surrogate; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsHighSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xD800u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a low surrogate?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if low surrogate; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsLowSurrogate(UInt32 codePoint) => unchecked(codePoint - 0xDC00u <= 0x03FFu);

		/// <summary>
		/// Is the <paramref name="codePoint"/> a UNICODE Scalar Value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a UNICODE Scalar Value; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsScalarValue(UInt32 codePoint) => ((codePoint - 0x110000u) ^ 0xD800u) >= 0xFFEF0800u;

		/// <summary>
		/// Is the <paramref name="codePoint"/> in the Supplimentary Multilingual Plane?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if in the Supplimentary Multilingual Plane; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsSmp(UInt32 codePoint) => Plane(codePoint) == 1;

		/// <summary>
		/// Is the <paramref name="codePoint"/> a surrogate value?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns><see langword="true"/> if a surrogate value; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean IsSurrogate(UInt32 codePoint) => codePoint.Within(0xD800u, 0xDFFFu);

		/// <summary>
		/// Calculates the Levenshtein edit-distance, <typeparamref name="T"/>-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <typeparam name="T">The type of elements being analyzed.</typeparam>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 LevenshteinDistance<T>(ReadOnlySpan<T> source, ReadOnlySpan<T> other) where T : IEquatable<T> {
			Int32 n = source.Length;
			Int32 m = other.Length;

			if (n == 0) {
				return m;
			} else if (m == 0) {
				return n;
			} else {
				Int32[,] d = new Int32[n + 1, m + 1];
				for (Int32 i = 0; i <= n; d[i, 0] = i++) { /* Prework */ }
				for (Int32 j = 0; j <= m; d[0, j] = j++) { /* Prework */ }

				Int32 c;
				for (Int32 i = 1; i <= n; i++) {
					for (Int32 j = 1; j <= m; j++) {
						c = other[j - 1].Equals(source[i - 1]) ? 0 : 1;
						d[i, j] = Math.Min(
							Math.Min(
								d[i - 1, j] + 1,
								d[i, j - 1] + 1),
							d[i - 1, j - 1] + c);
					}
				}
				return d[n, m];
			}
		}

		/// <summary>
		/// Which UNICODE Plane does the <paramref name="codePoint"/> belong to?
		/// </summary>
		/// <param name="codePoint">The <see cref="UInt32"/> interpreted as a codepoint.</param>
		/// <returns>A <see cref="UInt32"/> value corresponding to the UNICODE Plane.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt32 Plane(UInt32 codePoint) => unchecked(codePoint >> 16);

		/// <summary>
		/// Decodes the UTF-16 Surrogate Pairs into a UNICODE Scalar Value.
		/// </summary>
		/// <param name="highSurrogate">The <see cref="UInt32"/> interpreted as the high surrogate.</param>
		/// <param name="lowSurrogate">The <see cref="UInt32"/> interpreted as the low surrogate.</param>
		/// <returns>A <see cref="UInt32"/> representing the UNICODE Scalar Value.</returns>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a value back. That value may be incorrect, and there's no error to tell you if it is.
		/// </remarks>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt32 Utf16Decode(UInt32 highSurrogate, UInt32 lowSurrogate) => unchecked((highSurrogate << 10) + lowSurrogate - ((0xD800u << 10) + 0xDC00u - (1 << 16)));

		/// <summary>
		/// Encodes the UNICODE Scalar Value into UTF-16 high and low surrogates, assuming <paramref name="smpScalarValue"/> is in the Supplimentary Multilingual Plane.
		/// </summary>
		/// <param name="smpScalarValue">The <see cref="UInt32"/> interpreted as the UNICODE Scalar Value in the Supplimentary Multilingual Plane.</param>
		/// <param name="highSurrogate">A <see cref="UInt32"/> representing the high surrogate.</param>
		/// <param name="lowSurrogate">A <see cref="UInt32"/> representing the low surrogate.</param>
		/// <remarks>
		/// This method does not do any validity checking what-so-ever. You get a surrogate pair back. Those may be incorrect. They may not even be actual surrogates. And there's no error to tell you if a problem occured.
		/// </remarks>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Utf16Encode(UInt32 smpScalarValue, out Char highSurrogate, out Char lowSurrogate) {
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
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt32 Utf16SequenceLength(UInt32 scalarValue) {
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
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt32 Utf8SequenceLength(UInt32 scalarValue) {
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
		/// <param name="value">The <see cref="UInt32"/> value to test.</param>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		/// <returns><see langword="true"/> if <paramref name="value"/> is within the range; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Boolean Within(this UInt32 value, UInt32 lower, UInt32 upper) => (value - lower) <= (upper - lower);
	}
}
