using System;
using Defender;
using Stringier.Linguistics;

namespace Stringier {
	public static partial class Text {
		#region IsIsogram(Text, Orthography)
		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times.</para>
		/// </remarks>
		public static Boolean IsIsogram(this String text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			return IsIsogram(text.AsSpan(), orthography, out _);
		}

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times.</para>
		/// </remarks>
		public static Boolean IsIsogram(this Char[] text, Orthography orthography) {
			Guard.NotNull(text, nameof(text));
			return IsIsogram(text.AsSpan(), orthography, out _);
		}

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times.</para>
		/// </remarks>
		public static Boolean IsIsogram(this Span<Char> text, Orthography orthography) => IsIsogram(text, orthography, out _);

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times.</para>
		/// </remarks>
		public static Boolean IsIsogram(this ReadOnlySpan<Char> text, Orthography orthography) => IsIsogram(text, orthography, out _);

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean IsIsogram(Char* text, Int32 length, Orthography orthography) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return IsIsogram(new ReadOnlySpan<Char>(text, length), orthography, out _);
		}
		#endregion

		#region IsIsogram(Text, Orthography, out Order)
		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="order">The order of the isogram.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times. This amount is known as the <paramref name="order"/>.</para>
		/// </remarks>
		public static Boolean IsIsogram(this String text, Orthography orthography, out Int32 order) {
			Guard.NotNull(text, nameof(text));
			return IsIsogram(text.AsSpan(), orthography, out order);
		}

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="order">The order of the isogram.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times. This amount is known as the <paramref name="order"/>.</para>
		/// </remarks>
		public static Boolean IsIsogram(this Char[] text, Orthography orthography, out Int32 order) {
			Guard.NotNull(text, nameof(text));
			return IsIsogram(text.AsSpan(), orthography, out order);
		}

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="order">The order of the isogram.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times. This amount is known as the <paramref name="order"/>.</para>
		/// </remarks>
		public static Boolean IsIsogram(this Span<Char> text, Orthography orthography, out Int32 order) => IsIsogram((ReadOnlySpan<Char>)text, orthography, out order);

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="order">The order of the isogram.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times. This amount is known as the <paramref name="order"/>.</para>
		/// </remarks>
		public static Boolean IsIsogram(this ReadOnlySpan<Char> text, Orthography orthography, out Int32 order) {
			Guard.NotNull(orthography, nameof(orthography));
			OrthographyCounter counter = orthography.Counter;
			counter.Add(text);
			order = 0;
			foreach (Int32 count in counter.Values) {
				if (order == 0 && count != 0) {
					order = count;
				}
				if (count != order && count != 0) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Is the <paramref name="text"/> an isogram?
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="orthography">The orthography to use.</param>
		/// <param name="order">The order of the isogram.</param>
		/// <returns><see langword="true"/> if isogram; otherwise, <see langword="false"/>.</returns>
		/// <remarks>
		/// <para>Isograms are text in which each glyph that is present, is present the same number of times. This amount is known as the <paramref name="order"/>.</para>
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Boolean IsIsogram(Char* text, Int32 length, Orthography orthography, out Int32 order) {
			Guard.Pointer(text, nameof(text), length, nameof(length));
			return IsIsogram(new ReadOnlySpan<Char>(text, length), orthography, out order);
		}
		#endregion
	}
}
