using System;
using System.Runtime.CompilerServices;
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
			return ReferenceEquals(source, other) ? 0 : HammingDistance<Char>(source.AsSpan(), other.AsSpan());
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
			return HammingDistance<Char>(source.AsSpan(), other);
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
			return HammingDistance<Char>(source, other.AsSpan());
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
			return HammingDistance<Char>(source.AsSpan(), other);
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
			return HammingDistance<Char>(source, other.AsSpan());
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

		/// <summary>
		/// Calculates the Hamming edit-distance, <typeparamref name="T"/>-wise, between the <paramref name="source"/> and <paramref name="other"/>.
		/// </summary>
		/// <typeparam name="T">The type of elements being analyzed.</typeparam>
		/// <param name="source">The source <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <param name="other">The other <see cref="ReadOnlySpan{T}"/> of <typeparamref name="T"/>.</param>
		/// <returns>The number of edits to get from <paramref name="source"/> to <paramref name="other"/>.</returns>
		/// <remarks>
		/// This isn't safe, and is always inlined. It's meant to be used to build up type specific algorithms.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int32 HammingDistance<T>(ReadOnlySpan<T> source, ReadOnlySpan<T> other) where T : IEquatable<T> {
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
