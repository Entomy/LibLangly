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
	}
}
