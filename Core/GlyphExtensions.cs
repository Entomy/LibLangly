using System;
using System.Text;

namespace Stringier {
	/// <summary>
	/// Implements various <see cref="Glyph"/> related methods for other types.
	/// </summary>
	public static class GlyphExtensions {
		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this string.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="string"/>.</returns>
		public static StringGlyphEnumerator EnumerateGlyphs(this String @string) => new StringGlyphEnumerator(@string);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this string.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="span"/>.</returns>
		public static SpanGlyphEnumerator EnumerateGlyphs(this ReadOnlySpan<Char> span) => new SpanGlyphEnumerator(span);

		/// <summary>
		/// Returns an enumeration of <see cref="Glyph"/> from this string.
		/// </summary>
		/// <param name="span">The <see cref="Span{T}"/> of <see cref="Char"/> to enumerate.</param>
		/// <returns>An enumerator for the <see cref="Glyph"/> of the <paramref name="span"/>.</returns>
		public static SpanGlyphEnumerator EnumerateGlyphs(this Span<Char> span) => new SpanGlyphEnumerator(span);

		/// <summary>
		/// Reverses the graphemes in this <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to reverse.</param>
		/// <returns>The source <paramref name="string"/> with its graphemes reversed.</returns>
		public static String Reverse(this String @string) {
			Glyph[] glyphs = Glyph.Split(@string);
			Glyph[] reversed = new Glyph[glyphs.Length];
			Int32 i = 0;
			Int32 j = glyphs.Length;
			while (i < glyphs.Length) {
				reversed[--j] = glyphs[i++];
			}
			return Glyph.ToString(reversed);
		}
	}
}
