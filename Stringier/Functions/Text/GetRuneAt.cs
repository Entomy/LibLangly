using System;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this String input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index);
		}

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
		public static Rune GetRuneAt(this String input, Int32 index, out Int32 newIndex) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index, out newIndex);
		}

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <remarks>
		/// Throws if <paramref name="input"/> is null, if <paramref name="index"/> is out of range, or if <paramref name="index"/> does not reference the start of a valid scalar value within <paramref name="input"/>.
		/// </remarks>
		public static Rune GetRuneAt(this Char[] input, Int32 index, out Int32 newIndex) {
			Guard.NotNull(input, nameof(input));
			return GetRuneAt(input.AsSpan(), index, out newIndex);
		}

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
			Guard.Index(index, nameof(index), input);
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
