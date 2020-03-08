using System;
using System.Runtime.CompilerServices;
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
			return ReferenceEquals(source, other) ? 0 : LevenshteinDistance<Char>(source.AsSpan(), other.AsSpan());
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
			return LevenshteinDistance<Char>(source.AsSpan(), other);
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
			return LevenshteinDistance<Char>(source, other.AsSpan());
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(String source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			return LevenshteinDistance<Char>(source.AsSpan(), other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, String other) {
			Guard.NotNull(other, nameof(other));
			return LevenshteinDistance<Char>(source, other.AsSpan());
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
			return LevenshteinDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(Char[] source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			return LevenshteinDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, Char[] other) {
			Guard.NotNull(other, nameof(other));
			return LevenshteinDistance<Char>(source, other);
		}

		/// <summary>
		/// Calculates the Levenshtein edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 LevenshteinDistance(ReadOnlySpan<Char> source, ReadOnlySpan<Char> other) => LevenshteinDistance<Char>(source, other);

		/// <summary>
		/// Calculates the Levenshtein edit-distance, <typeparamref name="T"/>-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <typeparam name="T">The type of elements being analyzed.</typeparam>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// This isn't safe, and is always inlined. It's meant to be used to build up type specific algorithms.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 LevenshteinDistance<T>(ReadOnlySpan<T> source, ReadOnlySpan<T> other) where T : IEquatable<T> {
			Int32 n = source.Length;
			Int32 m = other.Length;

			if (n == 0) {
				return m;
			} else if (m == 0) {
				return n;
			} else {
				Int32[,] d = new Int32[n + 1, m + 1];
				for (Int32 i = 0; i <= n; d[i, 0] = i++) { /* Prework */ }
				for (Int32 j = 0; j <= m; d[0, j] = j++) { /* Prework */ }

				Int32 c;
				for (Int32 i = 1; i <= n; i++) {
					for (Int32 j = 1; j <= m; j++) {
						c = other[j - 1].Equals(source[i - 1]) ? 0 : 1;
						d[i, j] = Math.Min(
							Math.Min(
								d[i - 1, j] + 1,
								d[i, j - 1] + 1),
							d[i - 1, j - 1] + c);
					}
				}
				return d[n, m];
			}
		}
	}
}
