using System;
using Defender;

namespace Stringier {
	public static partial class Search {
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 BruteForce(String source, String pattern) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(pattern, nameof(pattern));
			return BruteForce(source.AsSpan(), pattern.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 BruteForce(String source, ReadOnlySpan<Char> pattern) {
			Guard.NotNull(source, nameof(source));
			return BruteForce(source.AsSpan(), pattern);
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 BruteForce(ReadOnlySpan<Char> source, String pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return BruteForce(source, pattern.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 BruteForce(ReadOnlySpan<Char> source, ReadOnlySpan<Char> pattern) {
			for (Int32 i = 0; i < source.Length - pattern.Length; i++) {
				if (source.Slice(i, pattern.Length).Equals(pattern, StringComparison.Ordinal)) {
					return i;
				}
			}
			return -1;
		}
	}
}
