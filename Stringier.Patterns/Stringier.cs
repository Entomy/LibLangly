using System;
using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Contains configuration of the pattern engine
	/// </summary>
	/// <remarks>
	/// This also includes internal utilities for use in implementing the pattern engine
	/// While some of these could theoretically be useful outside this assembly, the simple fact is the actual behavior diverges from their standard analogues in a way that while useful for Stringier, could introduce unexpected behavior for others. It is for the best that they stay internal.
	/// Furthermore, many of these may simply call their String counterpart. This is so that implementations may be swapped out quickly for testing.
	/// </remarks>
	public static class Stringier {
		/// <summary>
		/// The <see cref="StringComparison"/> to use by default
		/// </summary>
		public static StringComparison DefaultComparisonType = StringComparison.CurrentCultureIgnoreCase;

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

		internal static Boolean Equals(String a, String b) => String.Equals(a, b);

		internal static Boolean Equals(String a, String b, StringComparison ComparisonType) => String.Equals(a, b, ComparisonType);
	}
}
