using System;
using System.Globalization;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Determines whether this <see cref="Char"/> and a specified <see cref="Char"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="char">The <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the chars will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char @char, Char other, StringComparison comparisonType) {
			switch (comparisonType) {
			case StringComparison.OrdinalIgnoreCase:
			case StringComparison.InvariantCultureIgnoreCase:
				return @char.ToUpperInvariant().Equals(other.ToUpperInvariant());
			case StringComparison.CurrentCultureIgnoreCase:
				return @char.ToUpper(CultureInfo.CurrentCulture).Equals(other.ToUpper(CultureInfo.CurrentCulture));
			default:
				return @char.Equals(other);
			}
		}

		/// <summary>
		/// Determines whether this <see cref="Char"/> and a specified <see cref="Rune"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="char">The <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="Rune"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char @char, Rune other) => new Rune(@char).Equals(other, StringComparison.CurrentCulture);

		/// <summary>
		/// Determines whether this <see cref="Char"/> and a specified <see cref="Rune"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="char">The <see cref="Char"/> instance.</param>
		/// <param name="other">The <see cref="Rune"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the chars will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Char @char, Rune other, StringComparison comparisonType) => new Rune(@char).Equals(other, comparisonType);

		/// <summary>
		/// Determines whether this <see cref="Rune"/> and a specified <see cref="Rune"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="rune">The <see cref="Rune"/> instance.</param>
		/// <param name="other">The <see cref="Rune"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the chars will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune rune, Rune other, StringComparison comparisonType) {
			switch (comparisonType) {
			case StringComparison.OrdinalIgnoreCase:
			case StringComparison.InvariantCultureIgnoreCase:
				return rune.ToUpperInvariant().Equals(other.ToUpperInvariant());
			case StringComparison.CurrentCultureIgnoreCase:
				return rune.ToUpper(CultureInfo.CurrentCulture).Equals(other.ToUpper(CultureInfo.CurrentCulture));
			default:
				return rune.Equals(other);
			}
		}

		/// <summary>
		/// Determines whether this <see cref="Rune"/> and a specified <see cref="Char"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="rune">The <see cref="Rune"/> instance.</param>
		/// <param name="other">The <see cref="Char"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune rune, Char other) => rune.Equals(new Rune(other), StringComparison.CurrentCulture);

		/// <summary>
		/// Determines whether this <see cref="Rune"/> and a specified <see cref="Char"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <remarks>
		/// Note that because this compares individual characters, a lot of cultural rules do not apply due to multi-char equivalences. This should only be considered to check the cultural casing rules, nothing more.
		/// </remarks>
		/// <param name="rune">The <see cref="Rune"/> instance.</param>
		/// <param name="other">The <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the chars will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as this char; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this Rune rune, Char other, StringComparison comparisonType) => rune.Equals(new Rune(other), comparisonType);

		/// <summary>
		/// Determines whether this instance and the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> object have the same value.
		/// </summary>
		/// <param name="string">The <see cref="String"/> instance.</param>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="span"/> parameter is the same as this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this String @string, ReadOnlySpan<Char> span) => @string?.Equals(span, StringComparison.CurrentCulture) ?? false;

		/// <summary>
		/// Determines whether this string and a specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <param name="string">The <see cref="String"/> instance.</param>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="span"/> parameter is the same as this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this String @string, ReadOnlySpan<Char> span, StringComparison comparisonType) => @string?.AsSpan().Equals(span, comparisonType) ?? false;

		/// <summary>
		/// Determines whether this instance and another specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> object have the same value.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> instance.</param>
		/// <param name="string">The <see cref="String"/> to compare to this instance.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="span"/> parameter is the same as this span; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> span, String @string) => !(@string is null) && span.Equals(@string, StringComparison.CurrentCulture);

		/// <summary>
		/// Determines whether this span and a specified <see cref="String"/> object have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> instance.</param>
		/// <param name="string">The <see cref="String"/> to compare to this instance.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared.</param>
		/// <returns><see langword="true"/> if the value of the <paramref name="span"/> parameter is the same as this span; otherwise, <see langword="false"/>.</returns>
		public static Boolean Equals(this ReadOnlySpan<Char> span, String @string, StringComparison comparisonType) => !(@string is null) && span.Equals(@string.AsSpan(), comparisonType);
	}
}
