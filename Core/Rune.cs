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
		public Rune(Char ch) : this((UInt32)ch) { }

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

		/// <summary>
		/// A <see cref="Rune"/> instance that represents the Unicode replacement character U+FFFD.
		/// </summary>
		public static Rune ReplacementChar { get; } = new Rune(0xFFFD);

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

		// Displayed as "'<char>' (U+XXXX)"; e.g., "'e' (U+0065)"
		private String DebuggerDisplay => FormattableString.Invariant($"U+{value:X4} '{(IsValid(value) ? ToString() : "\uFFFD")}'");

		/// <summary>
		/// Decodes the <see cref="Rune"/> at the beginning of the provided UTF-16 source buffer.
		/// </summary>
		/// <returns>
		/// <para>
		/// If the source buffer begins with a valid UTF-16 encoded scalar value, returns <see cref="OperationStatus.Done"/>,
		/// and outs via <paramref name="result"/> the decoded <see cref="Rune"/> and via <paramref name="charsConsumed"/> the
		/// number of <see langword="char"/>s used in the input buffer to encode the <see cref="Rune"/>.
		/// </para>
		/// <para>
		/// If the source buffer is empty or contains only a standalone UTF-16 high surrogate character, returns <see cref="OperationStatus.NeedMoreData"/>,
		/// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="charsConsumed"/> the length of the input buffer.
		/// </para>
		/// <para>
		/// If the source buffer begins with an ill-formed UTF-16 encoded scalar value, returns <see cref="OperationStatus.InvalidData"/>,
		/// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="charsConsumed"/> the number of
		/// <see langword="char"/>s used in the input buffer to encode the ill-formed sequence.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The general calling convention is to call this method in a loop, slicing the <paramref name="source"/> buffer by
		/// <paramref name="charsConsumed"/> elements on each iteration of the loop. On each iteration of the loop <paramref name="result"/>
		/// will contain the real scalar value if successfully decoded, or it will contain <see cref="ReplacementChar"/> if
		/// the data could not be successfully decoded. This pattern provides convenient automatic U+FFFD substitution of
		/// invalid sequences while iterating through the loop.
		/// </remarks>
		public static OperationStatus DecodeFromUtf16(ReadOnlySpan<Char> source, out Rune result, out Int32 charsConsumed) {
			if (!source.IsEmpty) {
				// First, check for the common case of a BMP scalar value.
				// If this is correct, return immediately.

				Char firstChar = source[0];
				if (TryCreate(firstChar, out result)) {
					charsConsumed = 1;
					return OperationStatus.Done;
				}

				// First thing we saw was a UTF-16 surrogate code point.
				// Let's optimistically assume for now it's a high surrogate and hope
				// that combining it with the next char yields useful results.

				if (1 < source.Length) {
					Char secondChar = source[1];
					if (TryCreate(firstChar, secondChar, out result)) {
						// Success! Formed a supplementary scalar value.
						charsConsumed = 2;
						return OperationStatus.Done;
					} else {
						// Either the first character was a low surrogate, or the second
						// character was not a low surrogate. This is an error.
						goto InvalidData;
					}
				} else if (!Char.IsHighSurrogate(firstChar)) {
					// Quick check to make sure we're not going to report NeedMoreData for
					// a single-element buffer where the data is a standalone low surrogate
					// character. Since no additional data will ever make this valid, we'll
					// report an error immediately.
					goto InvalidData;
				}
			}

			// If we got to this point, the input buffer was empty, or the buffer
			// was a single element in length and that element was a high surrogate char.

			charsConsumed = source.Length;
			result = ReplacementChar;
			return OperationStatus.NeedMoreData;

		InvalidData:

			charsConsumed = 1; // maximal invalid subsequence for UTF-16 is always a single code unit in length
			result = ReplacementChar;
			return OperationStatus.InvalidData;
		}

		/// <summary>
		/// Decodes the <see cref="Rune"/> at the end of the provided UTF-16 source buffer.
		/// </summary>
		/// <remarks>
		/// This method is very similar to <see cref="DecodeFromUtf16(ReadOnlySpan{Char}, out Rune, out Int32)"/>, but it allows
		/// the caller to loop backward instead of forward. The typical calling convention is that on each iteration
		/// of the loop, the caller should slice off the final <paramref name="charsConsumed"/> elements of
		/// the <paramref name="source"/> buffer.
		/// </remarks>
		public static OperationStatus DecodeLastFromUtf16(ReadOnlySpan<Char> source, out Rune result, out Int32 charsConsumed) {
			Int32 index = source.Length - 1;
			if ((UInt32)index < (UInt32)source.Length) {
				// First, check for the common case of a BMP scalar value.
				// If this is correct, return immediately.

				Char finalChar = source[index];
				if (TryCreate(finalChar, out result)) {
					charsConsumed = 1;
					return OperationStatus.Done;
				}

				if (Char.IsLowSurrogate(finalChar)) {
					// The final character was a UTF-16 low surrogate code point.
					// This must be preceded by a UTF-16 high surrogate code point, otherwise
					// we have a standalone low surrogate, which is always invalid.

					index--;
					if ((UInt32)index < (UInt32)source.Length) {
						Char penultimateChar = source[index];
						if (TryCreate(penultimateChar, finalChar, out result)) {
							// Success! Formed a supplementary scalar value.
							charsConsumed = 2;
							return OperationStatus.Done;
						}
					}

					// If we got to this point, we saw a standalone low surrogate
					// and must report an error.

					charsConsumed = 1; // standalone surrogate
					result = ReplacementChar;
					return OperationStatus.InvalidData;
				}
			}

			// If we got this far, the source buffer was empty, or the source buffer ended
			// with a UTF-16 high surrogate code point. These aren't errors since they could
			// be valid given more input data.

			charsConsumed = (Int32)((UInt32)(-source.Length) >> 31); // 0 -> 0, all other lengths -> 1
			result = ReplacementChar;
			return OperationStatus.NeedMoreData;
		}

		public static explicit operator Rune(Char ch) => new Rune(ch);

		[CLSCompliant(false)]
		public static explicit operator Rune(UInt32 value) => new Rune(value);

		public static explicit operator Rune(Int32 value) => new Rune(value);

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

		public static Boolean operator !=(Rune left, Rune right) => left.value != right.value;

		public static Boolean operator <(Rune left, Rune right) => left.value < right.value;

		public static Boolean operator <=(Rune left, Rune right) => left.value <= right.value;

		public static Boolean operator ==(Rune left, Rune right) => left.value == right.value;
		public static Boolean operator >(Rune left, Rune right) => left.value > right.value;

		public static Boolean operator >=(Rune left, Rune right) => left.value >= right.value;

		/// <summary>
		/// Attempts to create a <see cref="Rune"/> from the provided input value.
		/// </summary>
		public static Boolean TryCreate(Char ch, out Rune result) {
			UInt32 extendedValue = ch;
			if (!Unsafe.IsSurrogate(extendedValue)) {
				result = new Rune(extendedValue);
				return true;
			} else {
				result = default;
				return false;
			}
		}

		/// <summary>
		/// Attempts to create a <see cref="Rune"/> from the provided UTF-16 surrogate pair.
		/// Returns <see langword="false"/> if the input values don't represent a well-formed UTF-16surrogate pair.
		/// </summary>
		public static Boolean TryCreate(Char highSurrogate, Char lowSurrogate, out Rune result) {
			// First, extend both to 32 bits, then calculate the offset of
			// each candidate surrogate char from the start of its range.

			UInt32 highSurrogateOffset = highSurrogate - 0xD800u;
			UInt32 lowSurrogateOffset = lowSurrogate - 0xDC00u;

			// This is a single comparison which allows us to check both for validity at once since
			// both the high surrogate range and the low surrogate range are the same length.
			// If the comparison fails, we call to a helper method to throw the correct exception message.

			if ((highSurrogateOffset | lowSurrogateOffset) <= 0x3FFu) {
				// The 0x40u << 10 below is to account for uuuuu = wwww + 1 in the surrogate encoding.
				result = new Rune((highSurrogateOffset << 10) + (lowSurrogate - 0xDC00u) + (0x40u << 10));
				return true;
			} else {
				// Didn't have a high surrogate followed by a low surrogate.
				result = default;
				return false;
			}
		}

		/// <summary>
		/// Attempts to create a <see cref="Rune"/> from the provided input value.
		/// </summary>
		public static Boolean TryCreate(Int32 value, out Rune result) => TryCreate((UInt32)value, out result);

		/// <summary>
		/// Attempts to create a <see cref="Rune"/> from the provided input value.
		/// </summary>
		[CLSCompliant(false)]
		public static Boolean TryCreate(UInt32 value, out Rune result) {
			if (Unsafe.IsScalarValue(value)) {
				result = new Rune(value);
				return true;
			} else {
				result = default;
				return false;
			}
		}

		public Int32 CompareTo(Rune other) => value.CompareTo(other.value);

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
		/// Decodes the <see cref="Rune"/> at the beginning of the provided UTF-8 source buffer.
		/// </summary>
		/// <returns>
		/// <para>
		/// If the source buffer begins with a valid UTF-8 encoded scalar value, returns <see cref="OperationStatus.Done"/>,
		/// and outs via <paramref name="result"/> the decoded <see cref="Rune"/> and via <paramref name="bytesConsumed"/> the
		/// number of <see langword="byte"/>s used in the input buffer to encode the <see cref="Rune"/>.
		/// </para>
		/// <para>
		/// If the source buffer is empty or contains only a standalone UTF-8 high surrogate character, returns <see cref="OperationStatus.NeedMoreData"/>,
		/// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="bytesConsumed"/> the length of the input buffer.
		/// </para>
		/// <para>
		/// If the source buffer begins with an ill-formed UTF-8 encoded scalar value, returns <see cref="OperationStatus.InvalidData"/>,
		/// and outs via <paramref name="result"/> <see cref="ReplacementChar"/> and via <paramref name="bytesConsumed"/> the number of
		/// <see langword="char"/>s used in the input buffer to encode the ill-formed sequence.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The general calling convention is to call this method in a loop, slicing the <paramref name="source"/> buffer by
		/// <paramref name="bytesConsumed"/> elements on each iteration of the loop. On each iteration of the loop <paramref name="result"/>
		/// will contain the real scalar value if successfully decoded, or it will contain <see cref="ReplacementChar"/> if
		/// the data could not be successfully decoded. This pattern provides convenient automatic U+FFFD substitution of
		/// invalid sequences while iterating through the loop.
		/// </remarks>
		public static OperationStatus DecodeFromUtf8(ReadOnlySpan<Byte> source, out Rune result, out Int32 bytesConsumed) {
			// This method follows the Unicode Standard's recommendation for detecting
			// the maximal subpart of an ill-formed subsequence. See The Unicode Standard,
			// Ch. 3.9 for more details. In summary, when reporting an invalid subsequence,
			// it tries to consume as many code units as possible as long as those code
			// units constitute the beginning of a longer well-formed subsequence per Table 3-7.

			Int32 index = 0;

			// Try reading input[0].

			if ((UInt32)index >= (UInt32)source.Length) {
				goto NeedsMoreData;
			}

			UInt32 tempValue = source[index];
			if (!Unsafe.IsAscii(tempValue)) {
				goto NotAscii;
			}

		Finish:

			bytesConsumed = index + 1;
			Debug.Assert(1 <= bytesConsumed && bytesConsumed <= 4); // Valid subsequences are always length [1..4]
			result = new Rune(tempValue);
			return OperationStatus.Done;

		NotAscii:

			// Per Table 3-7, the beginning of a multibyte sequence must be a code unit in
			// the range [C2..F4]. If it's outside of that range, it's either a standalone
			// continuation byte, or it's an overlong two-byte sequence, or it's an out-of-range
			// four-byte sequence.

			if (!tempValue.Within(0xC2, 0xF4)) {
				goto FirstByteInvalid;
			}

			tempValue = (tempValue - 0xC2) << 6;

			// Try reading input[1].

			index++;
			if ((UInt32)index >= (UInt32)source.Length) {
				goto NeedsMoreData;
			}

			// Continuation bytes are of the form [10xxxxxx], which means that their two's
			// complement representation is in the range [-65..-128]. This allows us to
			// perform a single comparison to see if a byte is a continuation byte.

			Int32 thisByteSignExtended = (SByte)source[index];
			if (thisByteSignExtended >= -64) {
				goto Invalid;
			}

			tempValue += (UInt32)thisByteSignExtended;
			tempValue += 0x80; // remove the continuation byte marker
			tempValue += (0xC2 - 0xC0) << 6; // remove the leading byte marker

			if (tempValue < 0x0800) {
				Debug.Assert(tempValue.Within(0x0080, 0x07FF));
				goto Finish; // this is a valid 2-byte sequence
			}

			// This appears to be a 3- or 4-byte sequence. Since per Table 3-7 we now have
			// enough information (from just two code units) to detect overlong or surrogate
			// sequences, we need to perform these checks now.

			if (!tempValue.Within(((0xE0 - 0xC0) << 6) + (0xA0 - 0x80), ((0xF4 - 0xC0) << 6) + (0x8F - 0x80))) {
				// The first two bytes were not in the range [[E0 A0]..[F4 8F]].
				// This is an overlong 3-byte sequence or an out-of-range 4-byte sequence.
				goto Invalid;
			}

			if (tempValue.Within(((0xED - 0xC0) << 6) + (0xA0 - 0x80), ((0xED - 0xC0) << 6) + (0xBF - 0x80))) {
				// This is a UTF-16 surrogate code point, which is invalid in UTF-8.
				goto Invalid;
			}

			if (tempValue.Within(((0xF0 - 0xC0) << 6) + (0x80 - 0x80), ((0xF0 - 0xC0) << 6) + (0x8F - 0x80))) {
				// This is an overlong 4-byte sequence.
				goto Invalid;
			}

			// The first two bytes were just fine. We don't need to perform any other checks
			// on the remaining bytes other than to see that they're valid continuation bytes.

			// Try reading input[2].

			index++;
			if ((UInt32)index >= (UInt32)source.Length) {
				goto NeedsMoreData;
			}

			thisByteSignExtended = (SByte)source[index];
			if (thisByteSignExtended >= -64) {
				goto Invalid; // this byte is not a UTF-8 continuation byte
			}

			tempValue <<= 6;
			tempValue += (UInt32)thisByteSignExtended;
			tempValue += 0x80; // remove the continuation byte marker
			tempValue -= (0xE0 - 0xC0) << 12; // remove the leading byte marker

			if (tempValue <= 0xFFFF) {
				Debug.Assert(tempValue.Within(0x0800, 0xFFFF));
				goto Finish; // this is a valid 3-byte sequence
			}

			// Try reading input[3].

			index++;
			if ((UInt32)index >= (UInt32)source.Length) {
				goto NeedsMoreData;
			}

			thisByteSignExtended = (SByte)source[index];
			if (thisByteSignExtended >= -64) {
				goto Invalid; // this byte is not a UTF-8 continuation byte
			}

			tempValue <<= 6;
			tempValue += (UInt32)thisByteSignExtended;
			tempValue += 0x80; // remove the continuation byte marker
			tempValue -= (0xF0 - 0xE0) << 18; // remove the leading byte marker

			Debug.Assert(Unsafe.IsSmp(tempValue));
			goto Finish; // this is a valid 4-byte sequence

		FirstByteInvalid:

			index = 1; // Invalid subsequences are always at least length 1.

		Invalid:

			Debug.Assert(1 <= index && index <= 3); // Invalid subsequences are always length 1..3
			bytesConsumed = index;
			result = ReplacementChar;
			return OperationStatus.InvalidData;

		NeedsMoreData:

			Debug.Assert(0 <= index && index <= 3); // Incomplete subsequences are always length 0..3
			bytesConsumed = index;
			result = ReplacementChar;
			return OperationStatus.NeedMoreData;
		}

		public override Boolean Equals(Object? obj) => (obj is Rune other) && Equals(other);

		public Boolean Equals(Rune other) => this == other;

		public override Int32 GetHashCode() => Value;

		/// <summary>
		/// Returns a <see cref="String"/> representation of this <see cref="Rune"/> instance.
		/// </summary>
		public override String ToString() {
			if (IsBmp) {
				return $"{(Char)value}";
			} else {
				Unsafe.Utf16Encode(value, out Char high, out Char low);
				return $"{high}{low}";
			}
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