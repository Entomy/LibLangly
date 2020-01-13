using System;
using System.Collections.Generic;

namespace Stringier {
	/// <summary>
	/// Provides the bad-character table used in the Boyer-Moore-Horspool string-search algorithm.
	/// </summary>
	public class HorspoolTable : IEquatable<HorspoolTable>, IEquatable<String> {
		protected readonly String Pattern;
		protected readonly IDictionary<Char, Int32> Jumps;

		public Int32 this[Char @char] => Jumps.ContainsKey(@char) ? Jumps[@char] : Pattern.Length;

		public Int32 Length => Pattern.Length;

		/// <summary>
		/// Initialize a new instance of the Boyer-Moore-Horspool bad-character table.
		/// </summary>
		/// <param name="pattern">The pattern to create a table for.</param>
		public HorspoolTable(String pattern) {
			Jumps = new Dictionary<Char, Int32>();
			for (Int32 i = 0; i < pattern.Length; i++) {
				Jumps[pattern[i]] = pattern.Length - i - 1;
			}
			Pattern = pattern;
		}

		public static Boolean operator ==(HorspoolTable left, HorspoolTable right) => left.Equals(right);

		public static Boolean operator ==(HorspoolTable left, String right) => left.Equals(right);

		public static Boolean operator ==(String left, HorspoolTable right) => right.Equals(left);

		public static Boolean operator ==(HorspoolTable left, ReadOnlySpan<Char> right) => left.Equals(right);

		public static Boolean operator ==(ReadOnlySpan<Char> left, HorspoolTable right) => right.Equals(left);

		public static Boolean operator !=(HorspoolTable left, HorspoolTable right) => !left.Equals(right);

		public static Boolean operator !=(HorspoolTable left, String right) => !left.Equals(right);

		public static Boolean operator !=(String left, HorspoolTable right) => !left.Equals(right);

		public static Boolean operator !=(HorspoolTable left, ReadOnlySpan<Char> right) => !left.Equals(right);

		public static Boolean operator !=(ReadOnlySpan<Char> left, HorspoolTable right) => !right.Equals(left);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case HorspoolTable table:
				return Equals(table);
			case String @string:
				return Equals(@string);
			default:
				return false;
			}
		}

		public Boolean Equals(HorspoolTable other) => String.Equals(Pattern, other.Pattern, StringComparison.Ordinal);

		public Boolean Equals(String other) => String.Equals(Pattern, other, StringComparison.Ordinal);

		public Boolean Equals(ReadOnlySpan<Char> other) => Pattern.AsSpan().Equals(other, StringComparison.Ordinal);

		public override Int32 GetHashCode() => StringComparer.Ordinal.GetHashCode(Pattern);
	}
}
