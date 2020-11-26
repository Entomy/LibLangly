using System;
using System.Diagnostics.CodeAnalysis;
using Langly;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="String"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this String input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetGlyphAt(input.AsSpan(), index);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this Char[] input, Int32 index) {
			Guard.NotNull(input, nameof(input));
			return GetGlyphAt(input.AsSpan(), index);
		}


		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Memory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Memory<Char> input, Int32 index) => GetGlyphAt(input.Span, index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Span{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this ReadOnlyMemory<Char> input, Int32 index) => GetGlyphAt(input.Span, index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Span{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Span<Char> input, Int32 index) => GetGlyphAt((ReadOnlySpan<Char>)input, index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this ReadOnlySpan<Char> input, Int32 index) => GetGlyphAt(input, index, out _);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="String"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this String input, Int32 index, out Int32 newIndex) {
			Guard.NotNull(input, nameof(input));
			return GetGlyphAt(input.AsSpan(), index, out newIndex);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this Char[] input, Int32 index, out Int32 newIndex) {
			Guard.NotNull(input, nameof(input));
			return GetGlyphAt(input.AsSpan(), index, out newIndex);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Memory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Memory<Char> input, Int32 index, out Int32 newIndex) => GetGlyphAt(input.Span, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this ReadOnlyMemory<Char> input, Int32 index, out Int32 newIndex) => GetGlyphAt(input.Span, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Span{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Span<Char> input, Int32 index, out Int32 newIndex) => GetGlyphAt((ReadOnlySpan<Char>)input, index, out newIndex);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static unsafe Glyph GetGlyphAt(this ReadOnlySpan<Char> input, Int32 index, out Int32 newIndex) {
			Guard.NotEmpty(input, nameof(input));
			Guard.Index(index, nameof(index), input);
			Int32 pos = index;
			UInt32 code = Glyph.Equivalencies.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}
	}
}
