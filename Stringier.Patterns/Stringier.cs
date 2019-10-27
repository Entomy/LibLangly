using System;
using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Contains internal utilities for use in implementing the pattern engine
	/// </summary>
	/// <remarks>
	/// While some of these could theoretically be useful outside this assembly, the simple fact is the actual behavior diverges from their standard analogues in a way that while useful for Stringier, could introduce unexpected behavior for others. It is for the best that they stay internal.
	/// Furthermore, many of these may simply call their String counterpart. This is so that implementations may be swapped out quickly for testing.
	/// </remarks>
	internal static class Stringier {
		internal static Boolean Equals(Char a, Char b) => a.Equals(b);

		internal static Boolean Equals(Char a, Char b, Boolean CaseSensitive) => CaseSensitive ? a.Equals(b) : a.ToUpper().Equals(b.ToUpper());

		internal static Boolean Equals(String a, String b) => String.Equals(a, b);

		internal static Boolean Equals(String a, ReadOnlySpan<Char> b) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i])) { return false; }
			}
			return true;
		}

		internal static Boolean Equals(ReadOnlySpan<Char> a, String b) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i])) { return false; }
			}
			return true;
		}

		internal static Boolean Equals(ReadOnlySpan<Char> a, ReadOnlySpan<Char> b) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i])) { return false; }
			}
			return true;
		}

		internal static Boolean Equals(String a, String b, Boolean CaseSensitive) => CaseSensitive ? String.Equals(a, b, StringComparison.OrdinalIgnoreCase) : String.Equals(a, b, StringComparison.Ordinal);

		internal static Boolean Equals(String a, ReadOnlySpan<Char> b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

		internal static Boolean Equals(ReadOnlySpan<Char> a, String b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

		internal static Boolean Equals(ReadOnlySpan<Char> a, ReadOnlySpan<Char> b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

	}
}
