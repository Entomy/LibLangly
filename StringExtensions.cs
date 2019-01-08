using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Stringier {
	public static class StringExtensions {

		/// <summary>
		/// Indicates whether the regular expression finds a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>true if the regular expression finds a match; otherwise, false.</returns>
		public static Boolean IsMatch(this String String, String Pattern, RegexOptions RegexOptions = RegexOptions.None) => Regex.IsMatch(String, Pattern, RegexOptions);

		/// <summary>
		/// Searches an input string for a substring that matches a regular expression pattern and returns the first occurrence as a single Match object.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>An object that contains information about the match.</returns>
		public static Match Match(this String String, String Pattern, RegexOptions RegexOptions = RegexOptions.None) => Regex.Match(String, Pattern, RegexOptions);

		/// <summary>
		/// Searches an input string for all occurrences of a regular expression and returns all the matches.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that specify options for matching.</param>
		/// <returns>A collection of the Match objects found by the search. If no matches are found, the method returns an empty collection object.</returns>
		public static MatchCollection Matches(this String String, String Pattern, RegexOptions RegexOptions = RegexOptions.None) => Regex.Matches(String, Pattern, RegexOptions);

		/// <summary>
		/// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
		/// </summary>
		/// <param name="String"></param>
		/// <param name="StartIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <returns>A string that is equivalent to the substring that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance.</returns>
		public static ReadOnlySpan<Char> SubstringSpan(this String String, Int32 StartIndex) => String.Substring(StartIndex).AsSpan();

		/// <summary>
		/// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
		/// </summary>
		/// <param name="String"></param>
		/// <param name="StartIndex">The zero-based starting character position of a substring in this instance.</param>
		/// <param name="Length">The number of characters in the substring.</param>
		/// <returns>A string that is equivalent to the substring of length length that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance and length is zero.</returns>
		public static ReadOnlySpan<Char> SubstringSpan(this String String, Int32 StartIndex, Int32 Length) => String.Substring(StartIndex, Length).AsSpan();

		/// <summary>
		/// Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to title case.</param>
		/// <param name="Culture">A predefined CultureInfo identifier, LCID property of an existing CultureInfo object, or Windows-only culture identifier.</param>
		/// <returns>The specified string converted to title case.</returns>
		public static String ToTitleCase(this String String, Int32 Culture) => new CultureInfo(Culture).TextInfo.ToTitleCase(String);

		/// <summary>
		/// Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to title case.</param>
		/// <param name="Culture">A predefined CultureInfo name, Name of an existing CultureInfo, or Windows-only culture name. name is not case-sensitive.</param>
		/// <returns>The specified string converted to title case.</returns>
		public static String ToTitleCase(this String String, String Culture) => new CultureInfo(Culture).TextInfo.ToTitleCase(String);

	}
}
