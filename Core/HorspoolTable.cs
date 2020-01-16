using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	/// <summary>
	/// Provides the bad-character table used in the Boyer-Moore-Horspool string-search algorithm.
	/// </summary>
	[SuppressMessage("Major Code Smell", "S4035:Classes implementing \"IEquatable<T>\" should be sealed", Justification = "One, Sonar doesn't understand there's an IEquatable inheritance pattern for dealing with this. Two, that isn't happening, there's an unrelated IEquatable<String> being inherited and children aren't allowed to override that implementation.")]
	public class HorspoolTable : IEquatable<String> {
		/// <summary>
		/// The pattern represented by the table.
		/// </summary>
		protected readonly String Pattern;

		/// <summary>
		/// The actual bad-character table.
		/// </summary>
		/// <remarks>
		/// Use of a dictionary in this way causes it to act as a sparse array, along with some additional logic in <see cref="this[Char]"/>.
		/// </remarks>
		protected readonly IDictionary<Char, Int32> Jumps;

		/// <summary>
		/// Gets the jump distance for this <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to get the jump distance for.</param>
		/// <returns>A 32-bit integer jump distance.</returns>
		internal Int32 this[Char @char] => Jumps.ContainsKey(@char) ? Jumps[@char] : Pattern.Length;

		/// <summary>
		/// The length of the pattern represented by this table.
		/// </summary>
		internal Int32 Length => Pattern.Length;

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

		/// <summary>
		/// Initialize a new instance of the Boyer-Moore-Horspool bad-character table.
		/// </summary>
		/// <param name="pattern">The pattern to create a table for.</param>
		public HorspoolTable(ReadOnlySpan<Char> pattern) : this(pattern.ToString()) { }

		public static Boolean operator ==(HorspoolTable left, String right) => left.Equals(right);

		public static Boolean operator ==(String left, HorspoolTable right) => right.Equals(left);

		public static Boolean operator ==(HorspoolTable left, ReadOnlySpan<Char> right) => left.Equals(right);

		public static Boolean operator ==(ReadOnlySpan<Char> left, HorspoolTable right) => right.Equals(left);

		public static Boolean operator !=(HorspoolTable left, String right) => !left.Equals(right);

		public static Boolean operator !=(String left, HorspoolTable right) => !left.Equals(right);

		public static Boolean operator !=(HorspoolTable left, ReadOnlySpan<Char> right) => !left.Equals(right);

		public static Boolean operator !=(ReadOnlySpan<Char> left, HorspoolTable right) => !right.Equals(left);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public sealed override Boolean Equals(Object obj) {
			switch (obj) {
			case String @string:
				return Equals(@string);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(String other) => String.Equals(Pattern, other, StringComparison.Ordinal);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => Pattern.AsSpan().Equals(other, StringComparison.Ordinal);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => StringComparer.Ordinal.GetHashCode(Pattern);
	}
}
