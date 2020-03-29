using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stringier {
	/// <summary>
	/// Represents text as a sequence of UTF-16 code units.
	/// </summary>
	public readonly struct ValueString : IComparable, IComparable<ValueString>, IComparable<String>, IEquatable<ValueString>, IEquatable<String>, IEnumerable<Char> {
		/// <summary>
		/// Represents the empty string. This field is read-only.
		/// </summary>
		public static readonly ValueString Empty;

		/// <summary>
		/// Backing <see cref="Array"/> of <see cref="Char"/> for this <see cref="ValueString"/>.
		/// </summary>
		private readonly Char[] Chars;

		/// <summary>
		/// Initializes a new instance of the <see cref="ValueString"/> class to the Unicode characters indicated in the specified character array.
		/// </summary>
		/// <param name="chars">An array of Unicode characters.</param>
		public ValueString(Char[] chars) => Chars = chars;

		/// <summary>
		/// Gets the number of characters in the current <see cref="ValueString"/> object.
		/// </summary>
		/// <value>The number of characters in the current string.</value>
		public Int32 Length => Chars.Length;

		/// <summary>
		/// Gets the <see cref="Char"/> object at a specified position in the current <see cref="ValueString"/> object.
		/// </summary>
		/// <param name="index">A position in the current string.</param>
		/// <returns>The object at position <paramref name="index"/>.</returns>
		/// <exception cref="IndexOutOfRangeException"><paramref name="index"/> is greater than or equal to the length of this object or less than zero.</exception>
		public readonly Char this[Int32 index] => Chars[index];

		/// <summary>
		/// Determines whether two specified strings have different values.
		/// </summary>
		/// <param name="left">The first string to compare.</param>
		/// <param name="right">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="left"/> is different from the value of <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(ValueString left, ValueString right) => !left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="ValueString"/> value is less than another specified <see cref="ValueString"/> value.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/>if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <(ValueString left, ValueString right) => left.CompareTo(right) < 0;

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="ValueString"/> value is less than or equal to another specified <see cref="ValueString"/> value.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/>if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator <=(ValueString left, ValueString right) => left.CompareTo(right) <= 0;

		/// <summary>
		/// Determines whether two specified strings have the same value.
		/// </summary>
		/// <param name="left">The first string to compare.</param>
		/// <param name="right">The second string to compare.</param>
		/// <returns><see langword="true"/> if the value of <paramref name="left"/> is the same as the value of <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(ValueString left, ValueString right) => left.Equals(right);

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="ValueString"/> value is greater than another specified <see cref="ValueString"/> value.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/>if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >(ValueString left, ValueString right) => left.CompareTo(right) > 0;

		/// <summary>
		/// Returns a value that indicates whether a specified <see cref="ValueString"/> value is greater than or equal to another specified <see cref="ValueString"/> value.
		/// </summary>
		/// <param name="left">The first value to compare.</param>
		/// <param name="right">The second value to compare.</param>
		/// <returns><see langword="true"/>if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator >=(ValueString left, ValueString right) => left.CompareTo(right) >= 0;

		/// <inheritdoc/>
		public Int32 CompareTo(Object obj) {
			switch (obj) {
			case ValueString other:
				return CompareTo(other);
			case String other:
				return CompareTo(other);
			default:
				throw new ArgumentException("Value is not a string");
			}
		}

		/// <inheritdoc/>
		public Int32 CompareTo(ValueString other) => MemoryExtensions.CompareTo(Chars, other.Chars, StringComparison.CurrentCulture);

		/// <inheritdoc/>
		public Int32 CompareTo(String other) => MemoryExtensions.CompareTo(Chars, other.AsSpan(), StringComparison.CurrentCulture);

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ValueString other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(ValueString other) {
			if (Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Chars[i].Equals(other.Chars[i])) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public Boolean Equals(String other) {
			if (Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Chars[i].Equals(other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public IEnumerator<Char> GetEnumerator() => ((IEnumerable<Char>)Chars).GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Char>)Chars).GetEnumerator();

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Chars.GetHashCode();

		/// <inheritdoc/>
		public override String ToString() => new String(Chars);
	}
}
