using System;
using Defender;

namespace Stringier {
	public static partial class Search {
		#region RabinKarp(Text, String)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(String source, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Char[] source, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, String search) {
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source, search.AsSpan());
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Char* source, Int32 length, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(new ReadOnlySpan<Char>(source, length), search);
		}
		#endregion

		#region RabinKarp(Text, Char[])
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(String source, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Char[] source, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, Char[] search) {
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source, search.AsSpan());
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Char* source, Int32 length, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(new ReadOnlySpan<Char>(source, length), search);
		}
		#endregion

		#region RabinKarp(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(String source, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(Char[] source, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return RabinKarp(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		public static Int32 RabinKarp(ReadOnlySpan<Char> source, ReadOnlySpan<Char> search) {
			Int32 siga = 0;
			Int32 sigb = 0;
			const Int32 Q = 100007;
			const Int32 D = 256;
			for (Int32 i = 0; i < search.Length; i++) {
				siga = ((siga * D) + source[i]) % Q;
				sigb = ((sigb * D) + search[i]) % Q;
			}
			if (siga == sigb) {
				return 0;
			}
			Int32 pow = 1;
			for (Int32 k = 1; k <= search.Length - 1; k++) {
				pow = pow * D % Q;
			}
			for (Int32 j = 1; j <= source.Length - search.Length; j++) {
				siga = (siga + Q - (pow * source[j - 1] % Q)) % Q;
				siga = ((siga * D) + source[j + search.Length - 1]) % Q;
				if (siga == sigb && source.Slice(j, search.Length).Equals(search, StringComparison.Ordinal)) {
					return j;
				}
			}
			return -1;
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Char* source, Int32 length, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return RabinKarp(new ReadOnlySpan<Char>(source, length), search);
		}
		#endregion

		#region RabinKarp(Text, Char*)
		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(String source, Char* search, Int32 length) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Char[] source, Char* search, Int32 length) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source.AsSpan(), new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(ReadOnlySpan<Char> source, Char* search, Int32 length) {
			Guard.NotNull(search, nameof(search));
			return RabinKarp(source, new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a Rabin-Karp string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="searchLength">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through a rolling-hash, which keeps the search effective while not requiring precomputing tables.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 RabinKarp(Char* source, Int32 length, Char* search, Int32 searchLength) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return RabinKarp(new ReadOnlySpan<Char>(source, length), new ReadOnlySpan<Char>(search, searchLength));
		}
		#endregion
	}
}
