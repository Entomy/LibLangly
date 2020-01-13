using System;

namespace Stringier {
	public static partial class Search {
		/// <summary>
		/// Performs the Boyer-Moore-Horspool string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="source"/>.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static Int32 Horspool(String source, String pattern) => Horspool(source, pattern, out HorspoolTable _);

		public static Int32 Horspool(String source, HorspoolTable table) {
			ReadOnlySpan<Char> candidate;
			Int32 skip = 0;
			while (source.Length - skip >= table.Length) {
				candidate = source.AsSpan().Slice(skip, table.Length);
				if (candidate == table) {
					return skip;
				}
				skip += table[source[skip + table.Length - 1]];
			}
			return -1;
		}

		public static Int32 Horspool(String source, String pattern, out HorspoolTable table) {
			table = new HorspoolTable(pattern);
			return Horspool(source, table);
		}
	}
}
