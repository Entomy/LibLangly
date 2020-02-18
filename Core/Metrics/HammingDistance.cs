using System;
using Defender;

namespace Stringier {
	public static partial class Metrics {
		#region Grapheme-Wise

		/// <summary>
		/// Calculates the Hamming edit-distance, grapheme-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, String other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			if (ReferenceEquals(source, other)) {
				return 0;
			}
			Glyph[] src = Glyph.Split(source);
			Glyph[] oth = Glyph.Split(other);
			Guard.Equal(src.Length, nameof(source), oth.Length, nameof(other));
			return HammingDistance<Glyph>(src, oth);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, grapheme-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			Glyph[] src = Glyph.Split(source);
			Glyph[] oth = Glyph.Split(other);
			Guard.Equal(src.Length, nameof(source), oth.Length, nameof(other));
			return HammingDistance<Glyph>(src, oth);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, grapheme-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, String other) {
			Guard.NotNull(other, nameof(other));
			Glyph[] src = Glyph.Split(source);
			Glyph[] oth = Glyph.Split(other);
			Guard.Equal(src.Length, nameof(source), oth.Length, nameof(other));
			return HammingDistance<Glyph>(src, oth);
		}

		#endregion

		#region Character-Wise

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(Char[] source, Char[] other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return ReferenceEquals(source, other) ? 0 : HammingDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(Char[] source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return HammingDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, Char[] other) {
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return HammingDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, ReadOnlySpan<Char> other) {
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return HammingDistance<Char>(source, other);
		}

		#endregion

		private static Int32 HammingDistance<T>(ReadOnlySpan<T> source, ReadOnlySpan<T> other) where T : IEquatable<T> {
			Int32 d = 0;
			for (Int32 i = 0; i < source.Length; i++) {
				if (!source[i].Equals(other[i])) {
					d++;
				}
			}
			return d;
		}
	}
}
