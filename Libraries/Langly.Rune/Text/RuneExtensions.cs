using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Langly;

namespace System.Text {
	/// <summary>
	/// Provides extensions related to <see cref="Text.Rune"/>.
	/// </summary>
	public static class RuneExtensions {
		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from this string.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static StringRuneEnumerator EnumerateRunes(this String @string) => @string.EnumerateRunes();

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from this array.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Char[] array) => MemoryExtensions.EnumerateRunes(array);

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from the provided memory.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Memory<Char> memory) => MemoryExtensions.EnumerateRunes(memory.Span);

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from the provided memory.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlyMemory<Char> memory) => MemoryExtensions.EnumerateRunes(memory.Span);

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this Span<Char> span) => MemoryExtensions.EnumerateRunes(span);

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from the provided span.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SpanRuneEnumerator EnumerateRunes(this ReadOnlySpan<Char> span) => MemoryExtensions.EnumerateRunes(span);

		/// <summary>
		/// Returns an enumeration of <see cref="Text.Rune"/> from the provided sequence.
		/// </summary>
		/// <remarks>
		/// Invalid sequences will be represented in the enumeration by <see cref="Rune.ReplacementChar"/>.
		/// </remarks>
		public static SeqRuneEnumerator EnumerateRunes(this IEnumerable<Char> enumerable) => new SeqRuneEnumerator(enumerable);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index) => GetRuneAt(input.AsSpan(), index);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index) => GetRuneAt(input.AsSpan(), index);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Memory<Char> input, Int32 index) => GetRuneAt(input.Span, index);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlyMemory<Char> input, Int32 index) => GetRuneAt(input.Span, index);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Span<Char> input, Int32 index) => GetRuneAt((ReadOnlySpan<Char>)input, index);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlySpan<Char> input, Int32 index) => GetRuneAt(input, index, out _);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index, out Int32 newIndex) => GetRuneAt(input.AsSpan(), index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index, out Int32 newIndex) => GetRuneAt(input.AsSpan(), index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Memory<Char> input, Int32 index, out Int32 newIndex) => GetRuneAt(input.Span, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this ReadOnlyMemory<Char> input, Int32 index, out Int32 newIndex) => GetRuneAt(input.Span, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Span<Char> input, Int32 index, out Int32 newIndex) => GetRuneAt((ReadOnlySpan<Char>)input, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Text.Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
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
					return Text.Rune.ReplacementChar;
				}
			}
			return new Rune(high);
		}

		/// <summary>
		/// Generates a <see cref="Text.Rune"/> value.
		/// </summary>
		/// <param name="generator">This generator.</param>
		/// <returns>A random <see cref="Text.Rune"/> value.</returns>
		public static Rune Rune([DisallowNull] this Generator generator) {
			Int32 codepoint = generator.Int32(0, 0x10FFFF);
			if (0xD800 <= codepoint && codepoint <= 0xDFFF) {
				return new Rune(codepoint - 0xD800);
			} else {
				return new Rune(codepoint);
			}
		}

		/// <summary>
		/// Generates a <see cref="Text.Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="generator">This generator.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Text.Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public static Rune Rune([DisallowNull] this Generator generator, Rune min, Rune max) {
		TryAgain:
			Rune rune = generator.Rune();
			if (min <= rune && rune <= max) {
				return rune;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Text.Rune"/> values.
		/// </summary>
		/// <param name="generator">This generator.</param>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Text.Rune"/> values.</returns>
		public static IEnumerable<Rune> Rune([DisallowNull] this Generator generator, nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return generator.Rune();
			}
		}
	}
}

