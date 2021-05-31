//NOTE: The contents of this file are not technically part of the backport, but are either required for its functioning, or so useful they are provided anyways. License should still be considered MIT, .NET Foundation. I'm not going to make a claim on any of this because it's all trivial code.

using System;
using System.Collections.Generic;

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
	}
}
