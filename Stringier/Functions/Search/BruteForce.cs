using System;

namespace Langly {
	public static partial class Search {
		#region BruteForce(Text, String)
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(String source, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(Char[] source, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(ReadOnlySpan<Char> source, String search) {
			Guard.NotNull(search, nameof(search));
			return BruteForce(source, search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(Char* source, Int32 length, String search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(new ReadOnlySpan<Char>(source, length), search.AsSpan());
		}
		#endregion

		#region BruteForce(Text, Char[])
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(String source, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(Char[] source, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(ReadOnlySpan<Char> source, Char[] search) {
			Guard.NotNull(search, nameof(search));
			return BruteForce(source, search.AsSpan());
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(Char* source, Int32 length, Char[] search) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(new ReadOnlySpan<Char>(source, length), search.AsSpan());
		}
		#endregion

		#region BruteForce(Text, ReadOnlySpan<Char>)
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(String source, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return BruteForce(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(Char[] source, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return BruteForce(source.AsSpan(), search);
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static Int32 BruteForce(ReadOnlySpan<Char> source, ReadOnlySpan<Char> search) {
			for (Int32 i = 0; i < source.Length - search.Length; i++) {
				if (source.Slice(i, search.Length).Equals(search, StringComparison.Ordinal)) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(Char* source, Int32 length, ReadOnlySpan<Char> search) {
			Guard.NotNull(source, nameof(source));
			return BruteForce(new ReadOnlySpan<Char>(source, length), search);
		}
		#endregion

		#region BruteForce(Text, Char*)
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(String source, Char* search, Int32 length) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(Char[] source, Char* search, Int32 length) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(source.AsSpan(), new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(ReadOnlySpan<Char> source, Char* search, Int32 length) {
			Guard.NotNull(search, nameof(search));
			return BruteForce(source, new ReadOnlySpan<Char>(search, length));
		}

		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="searchLength">The length of the <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		[CLSCompliant(false)]
		[Obsolete("Literally any other search algorithm is better than this.", error: false)]
		public static unsafe Int32 BruteForce(Char* source, Int32 length, Char* search, Int32 searchLength) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			return BruteForce(new ReadOnlySpan<Char>(source, length), new ReadOnlySpan<Char>(search, searchLength));
		}
		#endregion
	}
}
