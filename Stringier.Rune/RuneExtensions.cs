//NOTE: The contents of this file are not technically part of the backport, but are either required for its functioning, or so useful they are provided anyways. License should still be considered MIT, .NET Foundation. I'm not going to make a claim on any of this because it's all trivial code.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System.Text {
	/// <summary>
	/// Provides extensions related to <see cref="Rune"/>.
	/// </summary>
	public static class RuneExtensions {
		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from this string.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static StringRuneEnumerator EnumerateRunes(this String @string) =>
#if NETSTANDARD1_3
			new StringRuneEnumerator(@string);
#else
			@string.EnumerateRunes();
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from this array.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Char[] array) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(array.AsSpan());
#else
			MemoryExtensions.EnumerateRunes(array.AsSpan());
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<Char> span) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(span);
#endif


		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Span<Char> span) =>
#if NETSTANDARD1_3
			new SpanRuneEnumerator(span);
#else
			MemoryExtensions.EnumerateRunes(span);
#endif

		/// <summary>
		/// Returns an enumeration of <see cref="Rune"/> from the provided sequence.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static EnumerableRuneEnumerator EnumerateRunes(this IEnumerable<Char> enumerable) => new EnumerableRuneEnumerator(enumerable);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index) => GetRuneAt(input.AsSpan(), index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index) => GetRuneAt(input.AsSpan(), index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Span<Char> input, Int32 index) => GetRuneAt((ReadOnlySpan<Char>)input, index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlySpan<Char> input, Int32 index) => GetRuneAt(input, index, out _);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index, out Int32 newIndex) => GetRuneAt(input.AsSpan(), index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index, out Int32 newIndex) => GetRuneAt(input.AsSpan(), index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Span<Char> input, Int32 index, out Int32 newIndex) => GetRuneAt((ReadOnlySpan<Char>)input, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlySpan<Char> input, Int32 index, out Int32 newIndex) {
			newIndex = index;
			Char high = input[newIndex++];
			if (Char.IsHighSurrogate(high)) {
				Char low = input[newIndex++];
				if (Char.IsLowSurrogate(low)) {
					return new Rune(high, low);
				} else {
					return Rune.ReplacementChar;
				}
			}
			return new Rune(high);
		}

		/// <summary>
		/// Generates a <see cref="Rune"/> value.
		/// </summary>
		/// <param name="random">The random number generator being used.</param>
		/// <returns>A random <see cref="Rune"/> value.</returns>
		public static unsafe Rune NextRune(this Random random) {
#if !NETSTANDARD1_3
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
#else
			Byte[] buffer = new Byte[sizeof(Int32)];
#endif
		TryAgain:
			random.NextBytes(buffer);
#if !NETSTANDARD1_3
			Int32 scalar = Math.Abs(BitConverter.ToInt32(buffer));
#else
			Int32 scalar = Math.Abs(BitConverter.ToInt32(buffer, 0));
#endif
			while (scalar > 0x10FFFF) {
				scalar = scalar >> 2;
			}
			if (0xD800 <= scalar && scalar < 0xE000) {
				scalar -= 0xD800;
			}
			return new Rune(scalar);
		}

		/// <summary>
		/// Generates a <see cref="Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="random">The random number generator being used.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public static Rune NextRune(this Random random, Rune min, Rune max) {
		TryAgain:
			Rune rune = random.NextRune();
			if (min <= rune && rune <= max) {
				return rune;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Rune"/> values.
		/// </summary>
		/// <param name="random">The random number generator being used.</param>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Rune"/> values.</returns>
		public static IEnumerable<Rune> NextRunes(this Random random, nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return random.NextRune();
			}
		}
	}
}
