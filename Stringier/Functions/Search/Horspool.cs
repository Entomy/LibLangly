using System;
using Defender;
using Collectathon.Tables;

namespace Stringier {
	public static partial class Search {
		#region Horspool(Text, Table)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(String source, HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source.AsSpan(), table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(Char[] source, HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source.AsSpan(), table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(ReadOnlySpan<Char> source, HorspoolTable table) => Horspool(source, table, 0);

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			return Horspool(new ReadOnlySpan<Char>(source, length), table);
		}
		#endregion

		#region Horspool(Text, Table, Int32)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <param name="startAtIndex">Index to start searching at.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(String source, HorspoolTable table, Int32 startAtIndex) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source.AsSpan(), table, startAtIndex);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <param name="startAtIndex">Index to start searching at.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(Char[] source, HorspoolTable table, Int32 startAtIndex) {
			Guard.NotNull(source, nameof(source));
			return Horspool(source.AsSpan(), table, startAtIndex);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <param name="startAtIndex">Index to start searching at.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		public static Int32 Horspool(ReadOnlySpan<Char> source, HorspoolTable table, Int32 startAtIndex) {
			ReadOnlySpan<Char> candidate;
			while (source.Length - startAtIndex >= table.Length) {
				candidate = source.Slice(startAtIndex, table.Length);
				if (candidate == table) {
					return startAtIndex;
				}
				startAtIndex += table[source[startAtIndex + table.Length - 1]];
			}
			return -1;
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="table"/> pattern if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> of the pattern to search for.</param>
		/// <param name="startAtIndex">Index to start searching at.</param>
		/// <returns>The index at which the pattern was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for the <paramref name="table"/> that was precomputed for a previous search pattern. This method primarily serves to continue the search.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, HorspoolTable table, Int32 startAtIndex) {
			Guard.NotNull(source, nameof(source));
			return Horspool(new ReadOnlySpan<Char>(source, length), table, startAtIndex);
		}
		#endregion

		#region Horspool(Text, String, out Table)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(String source, String search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(Char[] source, String search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(ReadOnlySpan<Char> source, String search, out HorspoolTable table) {
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, String search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(new ReadOnlySpan<Char>(source, length), table);
		}
		#endregion

		#region Horspool(Text, Char[], out Table)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(String source, Char[] search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(Char[] source, Char[] search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(ReadOnlySpan<Char> source, Char[] search, out HorspoolTable table) {
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, Char[] search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(search);
			return Horspool(new ReadOnlySpan<Char>(source, length), table);
		}
		#endregion

		#region Horspool(Text, ReadOnlySpan<Char>, out Table)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(String source, ReadOnlySpan<Char> search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(Char[] source, ReadOnlySpan<Char> search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		public static Int32 Horspool(ReadOnlySpan<Char> source, ReadOnlySpan<Char> search, out HorspoolTable table) {
			table = new HorspoolTable(search);
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, ReadOnlySpan<Char> search, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			table = new HorspoolTable(search);
			return Horspool(new ReadOnlySpan<Char>(source, length), table);
		}
		#endregion

		#region Horspool(Text, Char*, out Table)
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(String source, Char* search, Int32 length, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(new ReadOnlySpan<Char>(search, length));
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char[] source, Char* search, Int32 length, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(new ReadOnlySpan<Char>(search, length));
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="length">The length of the <paramref name="search"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(ReadOnlySpan<Char> source, Char* search, Int32 length, out HorspoolTable table) {
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(new ReadOnlySpan<Char>(search, length));
			return Horspool(source, table);
		}

		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="search"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The text to search in.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="search">The text to search for.</param>
		/// <param name="searchLength">The length of the <paramref name="search"/>.</param>
		/// <param name="table">The <see cref="HorspoolTable"/> for <paramref name="search"/>.</param>
		/// <returns>The index at which <paramref name="search"/> was found to start; -1 if not found.</returns>
		/// <remarks>
		/// This searches for <paramref name="search"/> through the computation of a shift-<paramref name="table"/>. It is most suitable for short search patterns in very large source texts, especially where the search will take place multiple times.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe Int32 Horspool(Char* source, Int32 length, Char* search, Int32 searchLength, out HorspoolTable table) {
			Guard.NotNull(source, nameof(source));
			Guard.NotNull(search, nameof(search));
			table = new HorspoolTable(new ReadOnlySpan<Char>(search, searchLength));
			return Horspool(new ReadOnlySpan<Char>(source, length), table);
		}
		#endregion
	}
}
