using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static class GlyphExtensions {
		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this string.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="string"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs([DisallowNull] this String @string) => new StringGlyphEnumerator(@string);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this array.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="array"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs([DisallowNull] this Char[] array) => new StringGlyphEnumerator(array);

		/// <summary>
		/// Returns an enumerator of <see cref="Glyph"/> from this memory.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="memory"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs(this ReadOnlyMemory<Char> memory) => new StringGlyphEnumerator(memory);

		/// <summary>
		/// Returns an enumerator of <see cref="Glyph"/> from this memory.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="memory"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs(this Memory<Char> memory) => new StringGlyphEnumerator(memory);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this span.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="span"/>.</returns>
		public static SpanGlyphEnumerator EnumerateGlyphs(this ReadOnlySpan<Char> span) => new SpanGlyphEnumerator(span);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this span.
		/// </summary>
		/// <param name="span">The <see cref="Span{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="span"/>.</returns>
		public static SpanGlyphEnumerator EnumerateGlyphs(this Span<Char> span) => new SpanGlyphEnumerator(span);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="String"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this String input, Int32 index) => GetGlyphAt(input.AsMemory(), index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this Char[] input, Int32 index) => GetGlyphAt(input.AsMemory(), index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Memory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Memory<Char> input, Int32 index) => GetGlyphAt(input.Span, index);

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/>.</param>
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
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt([DisallowNull] this Char[] input, Int32 index, out Int32 newIndex) {
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Memory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Memory<Char> input, Int32 index, out Int32 newIndex) {
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this ReadOnlyMemory<Char> input, Int32 index, out Int32 newIndex) {
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="Span{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static Glyph GetGlyphAt(this Span<Char> input, Int32 index, out Int32 newIndex) {
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Gets the <see cref="Glyph"/> which begins at index <paramref name="index"/> in string <paramref name="input"/>.
		/// </summary>
		/// <param name="input">The input <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="index">The index within the <paramref name="input"/> to get the <see cref="Glyph"/>.</param>
		/// <param name="newIndex">The within the <paramref name="input"/> after retrieving the entire <see cref="Glyph"/>.</param>
		public static unsafe Glyph GetGlyphAt(this ReadOnlySpan<Char> input, Int32 index, out Int32 newIndex) {
			Int32 pos = index;
			Int32 code = Glyph.Parser.Parse(input, ref pos);
			newIndex = pos;
			return new Glyph(code);
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, [DisallowNull] String source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source[pos++], source[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, [DisallowNull] Char[] source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source[pos++], source[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, Memory<Char> source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source.Span[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source.Span[pos++], source.Span[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, ReadOnlyMemory<Char> source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source.Span[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source.Span[pos++], source.Span[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, Span<Char> source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source[pos++], source[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static Int32 Parse([DisallowNull] this Dictionary<Int32> parser, ReadOnlySpan<Char> source, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source[pos++], source[pos++]));
			} else {
				return ((IParse<Int32>)parser).Parse(source, ref pos);
			}
		}

		/// <summary>
		/// Parses a <see cref="Glyph"/> Code from the <paramref name="source"/>.
		/// </summary>
		/// <param name="parser">This parser.</param>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="pos">The position within the <paramref name="source"/>.</param>
		/// <returns>The <see cref="Glyph"/> Code that was parsed.</returns>
		/// <remarks>
		/// When this call occurs <paramref name="pos"/> is the index at which to begin parsing. As this method executes <paramref name="pos"/> is updated such that when this call returns <paramref name="pos"/> is after the parsed value. This allows for continually parsing elements from the <paramref name="source"/>.
		/// </remarks>
		internal static unsafe Int32 Parse([DisallowNull] this Dictionary<Int32> parser, [DisallowNull] Char* source, Int32 length, ref Int32 pos) {
			if (UTF16.IsHighSurrogate(source[pos])) {
				return unchecked((Int32)Unsafe.UTF16Decode(source[pos++], source[pos++]));
			} else {
				return ((IParseUnsafe<Int32>)parser).Parse(source, length, ref pos);
			}
		}
	}
}
