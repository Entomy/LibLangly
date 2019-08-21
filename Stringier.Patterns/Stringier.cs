using System;
using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Contains internal methods useful throughout this assembly
	/// </summary>
	/// <remarks>
	/// While some of these could theoretically be useful outside this assembly, the simple fact is the actual behavior diverges from their standard analogues in a way that while useful for Stringier, could introduce unexpected behavior for others. It is for the best that they stay internal.
	/// </remarks>
	internal static class Stringier {
		internal static Boolean Equals(Char a, Char b) => a.Equals(b);

		internal static Boolean Equals(Char a, Char b, StringComparison ComparisonType) {
			switch (ComparisonType) {
			case StringComparison.CurrentCultureIgnoreCase:
				return a.ToUpper(CultureInfo.CurrentCulture).Equals(b.ToUpper(CultureInfo.CurrentCulture));
			case StringComparison.InvariantCultureIgnoreCase:
				return a.ToUpperInvariant().Equals(b.ToUpperInvariant());
			case StringComparison.OrdinalIgnoreCase:
				return a.ToUpper().Equals(b.ToUpper());
			default:
				return a.Equals(b);
			}
		}

		internal static Boolean Equals(String a, String b) => a[0].Equals(b[0]) && String.Equals(a, b);

		internal static Boolean Equals(String a, String b, StringComparison ComparisonType) {
			if (a.Length == 0 && b.Length == 0) { return true; }
			if (a.Length == 0 || b.Length == 0) { return false; }
			return Equals(a[0], b[0], ComparisonType) && String.Equals(a, b, ComparisonType);
		}
	}
}
