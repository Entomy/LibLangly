using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Splits a span into substrings that are based on the characters in the separator array.
		/// </summary>
		/// <param name="span">The span to split.</param>
		/// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or <see langword="null"/>.</param>
		/// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in <paramref name="separator"/>.</returns>
		public static String[] Split(this ReadOnlySpan<Char> span, params Char[] separator) {
			Guard.NotNull(separator, nameof(separator));
			return span.ToString().Split(separator);
		}

		/// <summary>
		/// Splits a string into substrings based on the strings in an array.
		/// </summary>
		/// <param name="string">The string to split.</param>
		/// <param name="separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</returns>
		public static String[] Split(this String @string, params String[] separator) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(separator, nameof(separator));
			return @string.Split(separator, StringSplitOptions.None);
		}

		/// <summary>
		/// Splits a string into substrings based on the strings in an array.
		/// </summary>
		/// <param name="span">The span to split.</param>
		/// <param name="separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</returns>
		public static String[] Split(this ReadOnlySpan<Char> span, params String[] separator) {
			Guard.NotNull(separator, nameof(separator));
			return span.ToString().Split(separator);
		}
	}
}
