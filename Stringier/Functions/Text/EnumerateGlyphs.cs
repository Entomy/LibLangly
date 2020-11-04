using System;
using System.Collections.Generic;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this string.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="string"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs(this String @string) => new StringGlyphEnumerator(@string);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this array.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="array"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs(this Char[] array) => new StringGlyphEnumerator(array);

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
		/// Returns an enumerator of <see cref="Glyph"/> from this sequence.
		/// </summary>
		/// <param name="seq">The <see cref="IEnumerable{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="seq"/>.</returns>
		public static SeqGlyphEnumerator EnumerateGlyphs(this IEnumerable<Char> seq) => seq is not null ? new SeqGlyphEnumerator(seq) : new SeqGlyphEnumerator();
	}
}
