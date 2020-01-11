using System;

namespace Stringier {
	public static partial class Search {
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
