using System;

namespace Stringier {
	public static partial class Metrics {
		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="source"/> <see cref="String"/> and <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, String other) => ReferenceEquals(source, other) ? 0 : HammingDistance(source.AsSpan(), other.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="source"/> <see cref="String"/> and <paramref name="other"/> <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, ReadOnlySpan<Char> other) => HammingDistance(source.AsSpan(), other);

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="source"/> <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> and <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, String other) => HammingDistance(source, other.AsSpan());

		/// <summary>
		/// Calculates the Hamming edit-distance between the <paramref name="source"/> <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> and <paramref name="other"/> <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		/// <exception cref="InvalidOperationException">Parameters must be equal length.</exception>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, ReadOnlySpan<Char> other) {
			if (source.Length != other.Length) {
				throw new InvalidOperationException("Must be equal length");
			} else {
				Int32 d = 0;
				for (Int32 i = 0; i < source.Length; i++) {
					if (source[i] != other[i]) {
						d++;
					}
				}
				return d;
			}
		}
	}
}
