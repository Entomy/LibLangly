using System;
using Defender;
using Stringier.Linguistics;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Is the <paramref name="text"/> a heterogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if heterogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Heterograms are text in which no glyph in the orthography appears more than once.</para>
		/// </remarks>
		public static Boolean IsHeterogram(this String text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			return IsHeterogram(text.AsSpan(), orthography);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a heterogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if heterogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Heterograms are text in which no glyph in the orthography appears more than once.</para>
		/// </remarks>
		public static Boolean IsHeterogram(this Char[] text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			return IsHeterogram(text.AsSpan(), orthography);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a heterogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if heterogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Heterograms are text in which no glyph in the orthography appears more than once.</para>
		/// </remarks>
		public static Boolean IsHeterogram(this Span<Char> text, Orthography orthography) => IsHeterogram((ReadOnlySpan<Char>)text, orthography);

		/// <summary>
		/// Is the <paramref name="text"/> a heterogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if heterogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Heterograms are text in which no glyph in the orthography appears more than once.</para>
		/// </remarks>
		public static Boolean IsHeterogram(this ReadOnlySpan<Char> text, Orthography orthography) {
			Guard.NotNull(orthography, nameof(orthography));
			OrthographyCounter counter = orthography.Counter;
			counter.Add(text);
			foreach (Int32 count in counter.Values) {
				if (count > 1) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Is the <paramref name="text"/> a heterogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if heterogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Heterograms are text in which no glyph in the orthography appears more than once.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean IsHeterogram(Char* text, Int32 length, Orthography orthography) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return IsHeterogram(new ReadOnlySpan<Char>(text, length), orthography);
		}
	}
}
