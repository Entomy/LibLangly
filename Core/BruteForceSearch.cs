using System;

namespace Stringier {
	public static partial class Search {
		/// <summary>
		/// Performs a naive brute force string-search, finding the starting index of the <paramref name="pattern"/> if found in <paramref name="text"/>.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static Int32 BruteForce(String source, String pattern) {
			ReadOnlySpan<Char> s = source.AsSpan();
			ReadOnlySpan<Char> p = pattern.AsSpan();
			for (Int32 i = 0; i < s.Length - p.Length; i++) {
				if (s.Slice(i, p.Length).Equals(p, StringComparison.CurrentCulture)) {
					return i;
				}
			}
			return -1;
		}
	}
}
