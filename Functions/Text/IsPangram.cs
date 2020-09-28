using System;
using Stringier.Linguistics;
using Defender;

namespace Stringier {
	public static partial class Text {
		/// <summary>
		/// Is the <paramref name="text"/> a pangram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if a pangram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Pangrams are text in which each glyph in the orthography is present.</para>
		/// </remarks>
		public static Boolean IsPangram(this String text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(orthography, nameof(orthography));
			return IsPangram(text.AsSpan(), orthography);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a pangram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if a pangram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Pangrams are text in which each glyph in the orthography is present.</para>
		/// </remarks>
		public static Boolean IsPangram(this Char[] text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			Guard.NotNull(orthography, nameof(orthography));
			return IsPangram(text.AsSpan(), orthography);
		}

		/// <summary>
		/// Is the <paramref name="text"/> a pangram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if a pangram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Pangrams are text in which each glyph in the orthography is present.</para>
		/// </remarks>
		public static Boolean IsPangram(this Span<Char> text, Orthography orthography) => IsPangram((ReadOnlySpan<Char>)text, orthography);

		/// <summary>
		/// Is the <paramref name="text"/> a pangram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if a pangram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Pangrams are text in which each glyph in the orthography is present.</para>
		/// </remarks>
		public static Boolean IsPangram(this ReadOnlySpan<Char> text, Orthography orthography) {
			Guard.NotNull(orthography, nameof(orthography));
			OrthographyCounter counter = orthography.Counter;
			counter.Add(text);
			foreach (Int32 count in counter.Values) {
				if (count == 0) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Is the <paramref name="text"/> a pangram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if a pangram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Pangrams are text in which each glyph in the orthography is present.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean IsPangram(Char* text, Int32 length, Orthography orthography) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			Guard.NotNull(orthography, nameof(orthography));
			return IsPangram(new ReadOnlySpan<Char>(text, length), orthography);
		}
	}
}
