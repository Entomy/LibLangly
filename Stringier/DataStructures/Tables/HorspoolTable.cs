using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Tables {
	/// <summary>
	/// Provides the bad-character table used in the Boyer-Moore-Horspool string-search algorithm.
	/// </summary>
	[SuppressMessage("Design", "MA0077:A class that provides Equals(T) should implement IEquatable<T>", Justification = "This is a ref struct and can't implement interfaces. The method implementations are still provided, however, so it's as if the interface has been implemented.")]
	public readonly ref struct HorspoolTable {
		/// <summary>
		/// The search string represented by the table.
		/// </summary>
		internal readonly ReadOnlySpan<Char> Search;

		/// <summary>
		/// The actual bad-character table.
		/// </summary>
		/// <remarks>
		/// Use of a dictionary in this way causes it to act as a sparse array, along with some additional logic in <see cref="this[Char]"/>.
		/// </remarks>
		private readonly IDictionary<Char, Int32> Jumps;

		/// <summary>
		/// Initialize a new instance of the Boyer-Moore-Horspool bad-character table.
		/// </summary>
		/// <param name="search">The text to create a table for.</param>
		public HorspoolTable(String search) : this(search.AsSpan()) { }

		/// <summary>
		/// Initialize a new instance of the Boyer-Moore-Horspool bad-character table.
		/// </summary>
		/// <param name="search">The text to create a table for.</param>
		public HorspoolTable(Char[] search) : this(search.AsSpan()) { }

		/// <summary>
		/// Initialize a new instance of the Boyer-Moore-Horspool bad-character table.
		/// </summary>
		/// <param name="search">The text to create a table for.</param>
		public HorspoolTable(ReadOnlySpan<Char> search) {
			Jumps = new Dictionary<Char, Int32>();
			for (Int32 i = 0; i < search.Length; i++) {
				Jumps[search[i]] = search.Length - i - 1;
			}
			Search = search;
		}

		/// <summary>
		/// The length of the pattern represented by this table.
		/// </summary>
		internal Int32 Length => Search.Length;

		/// <summary>
		/// Gets the jump distance for this <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to get the jump distance for.</param>
		/// <returns>A 32-bit integer jump distance.</returns>
		internal Int32 this[Char @char] => Jumps.ContainsKey(@char) ? Jumps[@char] : Search.Length;

		public static Boolean operator !=(HorspoolTable left, HorspoolTable right) => !left.Equals(right);

		public static Boolean operator !=(HorspoolTable left, String right) => !(right is null) && !left.Equals(right);

		public static Boolean operator !=(String left, HorspoolTable right) => !(left is null) && !right.Equals(left);

		public static Boolean operator !=(HorspoolTable left, ReadOnlySpan<Char> right) => !left.Equals(right);

		public static Boolean operator !=(ReadOnlySpan<Char> left, HorspoolTable right) => !right.Equals(left);

		public static Boolean operator ==(HorspoolTable left, HorspoolTable right) => left.Equals(right);

		public static Boolean operator ==(HorspoolTable left, String right) => !(right is null) && left.Equals(right);

		public static Boolean operator ==(String left, HorspoolTable right) => !(left is null) && right.Equals(left);

		public static Boolean operator ==(HorspoolTable left, ReadOnlySpan<Char> right) => left.Equals(right);

		public static Boolean operator ==(ReadOnlySpan<Char> left, HorspoolTable right) => right.Equals(left);

		/// <inheritdoc/>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case String @string:
				return Equals(@string);
			case Char[] array:
				return Equals(array);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(HorspoolTable other) => MemoryExtensions.Equals(Search, other.Search, StringComparison.Ordinal);

		/// <inheritdoc/>
		public Boolean Equals(String other) => Equals(other.AsSpan());

		/// <inheritdoc/>
		public Boolean Equals(Char[] other) => Equals(other.AsSpan());

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => MemoryExtensions.Equals(Search, other, StringComparison.Ordinal);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <param name="length">The length of the <paramref name="other"/> text.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		public unsafe Boolean Equals(Char* other, Int32 length) => Equals(new ReadOnlySpan<Char>(other, length));

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => 0;
	}
}
