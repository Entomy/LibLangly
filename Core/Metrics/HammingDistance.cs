using System;
using Defender;

namespace Stringier {
	public static partial class Metrics {
		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, String other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return ReferenceEquals(source, other) ? 0 : Unsafe.HammingDistance(source.AsSpan(), other.AsSpan());
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, Char[] other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return Unsafe.HammingDistance(source.AsSpan(), other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="Array"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(Char[] source, String other) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return Unsafe.HammingDistance(source, other.AsSpan());
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="String"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(String source, ReadOnlySpan<Char> other) {
			Guard.NotNull(source, nameof(source));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return Unsafe.HammingDistance(source.AsSpan(), other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="String"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, String other) {
			Guard.NotNull(other, nameof(other));
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return Unsafe.HammingDistance(source, other.AsSpan());
		}

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
			return ReferenceEquals(source, other) ? 0 : Unsafe.HammingDistance<Char>(source, other);
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
			return Unsafe.HammingDistance(source, other);
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
			return Unsafe.HammingDistance(source, other);
		}

		/// <summary>
		/// Calculates the Hamming edit-distance, character-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		public static Int32 HammingDistance(ReadOnlySpan<Char> source, ReadOnlySpan<Char> other) {
			Guard.Equal(source.Length, nameof(source), other.Length, nameof(other));
			return Unsafe.HammingDistance(source, other);
		}
	}
}
