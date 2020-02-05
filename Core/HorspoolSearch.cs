using System;
using Defender;

namespace Stringier {
	public static partial class Search {
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(String source, String pattern) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(pattern, nameof(pattern));
			return Horspool(source, pattern, out HorspoolTable _);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(String source, ReadOnlySpan<Char> pattern) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source, pattern, out HorspoolTable _);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(ReadOnlySpan<Char> source, String pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return Horspool(source, pattern, out HorspoolTable _);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(ReadOnlySpan<Char> source, ReadOnlySpan<Char> pattern) => Horspool(source, pattern, out HorspoolTable _);

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		public static Int32 Horspool(String source, HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(table, nameof(table));
			return Horspool(source.AsSpan(), table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		public static Int32 Horspool(ReadOnlySpan<Char> source, HorspoolTable table) {
			Guard.NotNull(table, nameof(table));
			ReadOnlySpan<Char> candidate;
			Int32 skip = 0;
			while (source.Length - skip >= table.Length) {
				candidate = source.Slice(skip, table.Length);
				if (candidate == table) {
					return skip;
				}
				skip += table[source[skip + table.Length - 1]];
			}
			return -1;
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="pattern"/>.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(String source, String pattern, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(pattern, nameof(pattern));
			return Horspool(source.AsSpan(), pattern.AsSpan(), out table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="String"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="pattern"/>.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(String source, ReadOnlySpan<Char> pattern, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source.AsSpan(), pattern, out table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="String"/> to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="pattern"/>.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(ReadOnlySpan<Char> source, String pattern, out HorspoolTable table) {
			Guard.NotNull(pattern, nameof(pattern));
			return Horspool(source, pattern.AsSpan(), out table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search in.</param>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="pattern"/>.</param>
		/// <returns>The index at which <paramref name="pattern"/> was found to start; -1 if not found.</returns>
		public static Int32 Horspool(ReadOnlySpan<Char> source, ReadOnlySpan<Char> pattern, out HorspoolTable table) {
			table = new HorspoolTable(pattern);
			return Horspool(source, table);
		}
	}
}
