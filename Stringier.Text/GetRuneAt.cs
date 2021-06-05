#if NETCOREAPP3_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt([AllowNull] this String input, ref Int32 index) => GetRuneAt(input.AsSpan(), ref index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt([AllowNull] this Char[] input, ref Int32 index) => GetRuneAt(input.AsSpan(), ref index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt(this Memory<Char> input, ref Int32 index) => GetRuneAt(input.Span, ref index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt(this ReadOnlyMemory<Char> input, ref Int32 index) => GetRuneAt(input.Span, ref index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt(this Span<Char> input, ref Int32 index) => GetRuneAt((ReadOnlySpan<Char>)input, ref index);

		/// <summary>
		/// Gets the <see cref="Rune"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The source text to get the <see cref="Rune"/> from.</param>
		/// <param name="index">The index of the <see cref="Rune"/> to get; updated to the position after the <see cref="Rune"/> was found.</param>
		/// <remarks>
		/// If the <see cref="Char"/> at the <paramref name="index"/> does not decode to a valid <see cref="Rune"/>, <see cref="Rune.ReplacementChar"/> is returned.
		/// </remarks>
		/// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is out of range.</exception>
		public static Rune GetRuneAt(this ReadOnlySpan<Char> input, ref Int32 index) {
			Char high = input[index++];
			if (Char.IsHighSurrogate(high)) {
				Char low = input[index++];
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
#endif
