using System;
using Defender;

namespace Stringier {
	public static partial class Metrics {
		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(String source, String other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			return ReferenceEquals(source, other) ? 0 : Unsafe.LevenshteinDistance(source.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(String source, Char[] other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			return Unsafe.LevenshteinDistance(source.AsSpan(), other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(Char[] source, String other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			return Unsafe.LevenshteinDistance(source, other.AsSpan());
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(String source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			return Unsafe.LevenshteinDistance(source.AsSpan(), other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, String other) {
			Guard.NotNull(other, nameof(other));
			return Unsafe.LevenshteinDistance(source, other.AsSpan());
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(Char[] source, Char[] other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			return Unsafe.LevenshteinDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(Char[] source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			return Unsafe.LevenshteinDistance(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return Unsafe.LevenshteinDistance(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, ReadOnlySpan<Char> other) => Unsafe.LevenshteinDistance(source, other);
	}
}
