using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Defender;

namespace Stringier {
	/// <summary>
	/// Represents text as a sequence of UTF-16 code units.
	/// </summary>
	/// <remarks>
	/// This is intended to be an as-close-to-possible API compatible analogue to <see cref="String"/> which is being used as a performance optimization throughout <see cref="Stringier"/>. It is similar to <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> in that it is high performance, but different in that it holds its own data. It is similar to <see cref="String"/> in that it can be used anywhere, but different in that it is more lightweight when doesn't need to be boxed or put on the heap, and also does not make use of interning (both a good and bad thing, if you need what interning does, you should be using <see cref="String"/> anyways).
	/// </remarks>
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
		/// Initializes a new instance of the <see cref="ValueString"/> class to the Unicode characters indicated in the specified character array.
		/// </summary>
		/// <param name="chars">An array of Unicode characters.</param>
		public ValueString(ReadOnlySpan<Char> chars) : this(chars.ToArray()) { }

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
		public readonly Char this[Int32 index] => Chars.AsSpan()[index];

		public static implicit operator ReadOnlySpan<Char>(ValueString @string) => @string.Chars.AsSpan();

		/// <summary>
		/// Retrieves the system's reference to the specified <see cref="String"/>.
		/// </summary>
		/// <param name="str">A string to search for in the intern pool.</param>
		/// <returns>The system's reference to <paramref name="str"/>, if it is interned; otherwise, a new reference to a string with the value of <paramref name="str"/>.</returns>
		/// <remarks>
		/// <see cref="ValueString"/> objects are never interned. What this does, however, is provide a convenient wrapper around <see cref="String.Intern(String)"/> so that a <see cref="ValueString"/>'s representation can be interned and returned as a <see cref="String"/>.
		/// </remarks>
		public static String Intern(ValueString str) => String.Intern(str.ToString());

		/// <summary>
		/// Retrieves a reference to a specified <see cref="String"/>.
		/// </summary>
		/// <param name="str">The string to search for in the intern pool.</param>
		/// <returns>A reference to str if it is in the common language runtime intern pool; otherwise, null.</returns>
		/// <remarks>
		/// <see cref="ValueString"/> objects are never interned. What this does, however, is provide a convenient wrapper around <see cref="String.IsInterned(String)"/> so that a <see cref="ValueString"/>'s representation can be interned and returned as a <see cref="String"/>.
		/// </remarks>
		public static String IsInterned(ValueString str) => String.IsInterned(str.ToString());

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

		/// <summary>
		/// Creates a new <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> over the portion of the target string.
		/// </summary>
		/// <returns>The read-only character memory representation of the string.</returns>
		public ReadOnlyMemory<Char> AsMemory() => Chars.AsMemory();

		/// <summary>
		/// Creates a new <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> over the portion of the target string.
		/// </summary>
		/// <returns>The read-only span representation of the string.</returns>
		public ReadOnlySpan<Char> AsSpan() => Chars.AsSpan();

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
				if (!Chars.AsSpan()[i].Equals(other.Chars.AsSpan()[i])) {
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
				if (!Chars.AsSpan()[i].Equals(other[i])) {
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

		/// <summary>
		/// Returns a copy of this string converted to lowercase.
		/// </summary>
		/// <returns>The lowercase equivalent of the current string.</returns>
		public ValueString ToLower() => ToLower(CultureInfo.CurrentCulture);

		/// <summary>
		/// Returns a copy of this string converted to lowercase, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The lowercase equivalent of the current string.</returns>
		public ValueString ToLower(CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			Char[] result = new Char[Chars.Length];
			Span<Char> res = result.AsSpan();
			MemoryExtensions.ToLower(Chars.AsSpan(), res, culture);
			return new ValueString(result);
		}

		/// <summary>
		/// Returns a copy of this <see cref="ValueString"/> object converted to lowercase using the casing rules of the invariant culture.
		/// </summary>
		/// <returns>The lowercase equivalent of the current string.</returns>
		public ValueString ToLowerInvariant() => ToLower(CultureInfo.InvariantCulture);

		/// <inheritdoc/>
		public override String ToString() => new String(Chars);

		/// <summary>
		/// Returns a copy of this string converted to uppercase.
		/// </summary>
		/// <returns>The uppercase equivalent of the current string.</returns>
		public ValueString ToUpper() => ToUpper(CultureInfo.CurrentCulture);

		/// <summary>
		/// Returns a copy of this string converted to uppercase, using the casing rules of the specified culture.
		/// </summary>
		/// <param name="culture">An object that supplies culture-specific casing rules.</param>
		/// <returns>The uppercase equivalent of the current string.</returns>
		public ValueString ToUpper(CultureInfo culture) {
			Guard.NotNull(culture, nameof(culture));
			Char[] result = new Char[Chars.Length];
			Span<Char> res = result.AsSpan();
			MemoryExtensions.ToUpper(Chars.AsSpan(), res, culture);
			return new ValueString(result);
		}

		/// <summary>
		/// Returns a copy of this <see cref="ValueString"/> object converted to uppercase using the casing rules of the invariant culture.
		/// </summary>
		/// <returns>The uppercase equivalent of the current string.</returns>
		public ValueString ToUpperInvariant() => ToUpper(CultureInfo.InvariantCulture);
	}
}
