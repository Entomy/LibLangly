using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class Batch {
		/// <summary>
		/// Converts each of the elements of the array to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="graphemes">The array of graphemes to convert.</param>
		/// <returns>An array of glyphs corresponding to each of the elements of the array.</returns>
		[return: MaybeNull, NotNullIfNotNull("graphemes")]
		public static Glyph[] ToGlyph([AllowNull] Char[] graphemes) {
			if (graphemes is null) {
				return null;
			}
			Glyph[] result = new Glyph[graphemes.Length];
			for (nint i = 0; i < graphemes.Length; i++) {
				result[i] = new Glyph(graphemes[i]);
			}
			return result;
		}

		/// <summary>
		/// Converts each of the elements of the array to a <see cref="Glyph"/>.
		/// </summary>
		/// <param name="graphemes">The array of graphemes to convert.</param>
		/// <returns>An array of glyphs corresponding to each of the elements of the array.</returns>
		[return: MaybeNull, NotNullIfNotNull("graphemes")]
		public static Glyph[] ToGlyph([AllowNull] Rune[] graphemes) {
			if (graphemes is null) {
				return null;
			}
			Glyph[] result = new Glyph[graphemes.Length];
			for (nint i = 0; i < graphemes.Length; i++) {
				result[i] = new Glyph(graphemes[i]);
			}
			return result;
		}
	}
}
