using Defender;
using Stringier.Encodings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in
		/// string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or
		/// if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in
		/// string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or
		/// if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in
		/// string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or
		/// if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlySpan<Char> input, Int32 index) {
			Guard.LesserThan(index, nameof(index), input.Length);
			// Optimistically assume input is within BMP.
			Char returnValue = input[index];
			if (Utf16.IsSurrogate(returnValue)) {
				if (!Utf16.IsHighSurrogate(returnValue)) {
					throw new ArgumentException("Cannot extract a Unicode scalar value from the specified index in the input.", nameof(index));
				}
				// Treat 'returnValue' as the high surrogate.
				//
				// If this becomes a hot code path, we can skip the below bounds check by reading
				// off the end of the string using unsafe code. Since strings are null-terminated,
				// we're guaranteed not to read a valid low surrogate, so we'll fail correctly if
				// the string terminates unexpectedly.
				index++;
				if ((UInt32)index >= (UInt32)input.Length) {
					throw new ArgumentException("Cannot extract a Unicode scalar value from the specified index in the input. The input seems misformatted.", nameof(input)); // not an argument exception - just a "bad data" failure
				}
				Char potentialLowSurrogate = input[index];
				if (!Utf16.IsLowSurrogate(potentialLowSurrogate)) {
					throw new ArgumentException("Cannot extract a Unicode scalar value from the specified index in the input.", nameof(index));
				}
				return Utf16.Decode(returnValue, potentialLowSurrogate);
			}
			return new Rune(returnValue);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in
		/// string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or
		/// if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Rune GetRuneAt(Char* input, Int32 length, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(new ReadOnlySpan<Char>(input, length), index);
		}
	}
}
