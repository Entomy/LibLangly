using System;
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

	}
}
