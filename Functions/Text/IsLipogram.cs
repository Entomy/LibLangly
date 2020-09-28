using System;
using Defender;
using Stringier.Linguistics;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Is the <paramref name="text"/> a lipogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="exclude">The glyphs to exclude.</param>
		/// <returns><see langword="true"/> if a lipogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Lipograms are text in which the specified glyphs are not present, but all other glyphs of the orthography are present.
		/// </remarks>
		public static Boolean IsLipogram(this String text, Orthography orthography, params Glyph[] exclude) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(orthography, nameof(orthography));
			return IsLipogram(text.AsSpan(), orthography, exclude);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a lipogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="exclude">The glyphs to exclude.</param>
		/// <returns><see langword="true"/> if a lipogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Lipograms are text in which the specified glyphs are not present, but all other glyphs of the orthography are present.
		/// </remarks>
		public static Boolean IsLipogram(this Char[] text, Orthography orthography, params Glyph[] exclude) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(orthography, nameof(orthography));
			return IsLipogram(text.AsSpan(), orthography, exclude);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a lipogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="exclude">The glyphs to exclude.</param>
		/// <returns><see langword="true"/> if a lipogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Lipograms are text in which the specified glyphs are not present, but all other glyphs of the orthography are present.
		/// </remarks>
		public static Boolean IsLipogram(this Span<Char> text, Orthography orthography, params Glyph[] exclude) => IsLipogram((ReadOnlySpan<Char>)text, orthography, exclude);

		/// <summary>
		/// Is the <paramref name="text"/> a lipogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="exclude">The glyphs to exclude.</param>
		/// <returns><see langword="true"/> if a lipogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Lipograms are text in which the specified glyphs are not present, but all other glyphs of the orthography are present.
		/// </remarks>
		public static Boolean IsLipogram(this ReadOnlySpan<Char> text, Orthography orthography, params Glyph[] exclude) {
			Guard.NotNull(orthography, nameof(orthography));
			if (exclude is null || exclude.Length == 0) {
				// A lipogram with no exclusions is a pangram, we can calculate this condition more efficiently by using that logic.
				return text.IsPangram(orthography);
			}
			OrthographyCounter counter = orthography.Counter;
			counter.Add(text);
			// Loop through the orthography
			foreach (Glyph glyph in counter.Keys) {
				// Check the excluded glyphs
				foreach (Glyph exc in exclude) {
					// If the current glyph should be excluded
					if (glyph.Equals(exc, orthography, Case.Insensitive)) {
						// Check if it has been found
						if (counter[glyph] > 0) {
							// The glyph was found when it should have been exlucded, so we don't have a lipogram for the specified set.
							return false;
						} else {
							// The glyph wasn't found, so we're good.
							goto Next;
						}
					}
				}
				// Since the glyph wasn't excluded, it must be present.
				if (counter[glyph] == 0) {
					// But it wasn't.
					return false;
				}
			Next:
				;
			}
			return true;
		}

		/// <summary>
		/// Is the <paramref name="text"/> a lipogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="exclude">The glyphs to exclude.</param>
		/// <returns><see langword="true"/> if a lipogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// Lipograms are text in which the specified glyphs are not present, but all other glyphs of the orthography are present.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean IsLipogram(Char* text, Int32 length, Orthography orthography, params Glyph[] exclude) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(orthography, nameof(orthography));
			return IsLipogram(new ReadOnlySpan<Char>(text, length), orthography, exclude);
		}
	}
}
