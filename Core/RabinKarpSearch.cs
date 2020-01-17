using System;

namespace Stringier {
	public static partial class Search {
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 RabinKarp(String source, String pattern) {
			if (source is null || pattern is null) {
				throw new ArgumentNullException(source is null ? nameof(source) : nameof(pattern));
			}
			return RabinKarp(source.AsSpan(), pattern.AsSpan());
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 RabinKarp(String source, ReadOnlySpan<Char> pattern) {
			if (source is null) {
				throw new ArgumentNullException(nameof(source));
			}
			return RabinKarp(source.AsSpan(), pattern);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return RabinKarp(source, pattern.AsSpan());
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, ReadOnlySpan<Char> pattern) {
			Int32 siga = 0;
			Int32 sigb = 0;
			const Int32 Q = 100007;
			const Int32 D = 256;
			for (Int32 i = 0; i < pattern.Length; i++) {
				siga = ((siga * D) + source[i]) % Q;
				sigb = ((sigb * D) + pattern[i]) % Q;
			}
			if (siga == sigb) {
				return 0;
			}
			Int32 pow = 1;
			for (Int32 k = 1; k <= pattern.Length - 1; k++) {
				pow = pow * D % Q;
			}
			for (Int32 j = 1; j <= source.Length - pattern.Length; j++) {
				siga = (siga + Q - (pow * source[j - 1] % Q)) % Q;
				siga = ((siga * D) + source[j + pattern.Length - 1]) % Q;
				if (siga == sigb && source.Slice(j, pattern.Length).Equals(pattern, StringComparison.Ordinal)) {
					return j;
				}
			}
			return -1;
		}
	}
}
