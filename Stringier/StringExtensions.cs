using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace System {
	public static class StringExtensions {

		/// <summary>
		/// Chop the <paramref name="String"/> into chunks of <paramref name="Size"/>
		/// </summary>
		/// <param name="String">String to chop</param>
		/// <param name="Size">Size of chunks to chop into</param>
		/// <returns>Array of chunks</returns>
		public static String[] Chop(this String String, Int32 Size) {
			Int32 i = 0;
			Int32 j = 0;
			Int32 k = String.Length / Size + 1;
			String[] Result = new String[k];
			while (i < k) {
				if ((j + Size) > String.Length) {
					Result[i] = String.Substring(j, String.Length - j);
				} else {
					Result[i] = String.Substring(j, Size);
				}
				i++;
				j += Size;
			}
			return Result;
		}

		/// <summary>
		/// Trim and replace multiple spaces with a single space
		/// </summary>
		/// <param name="String">String to clean</param>
		/// <returns>Cleaned up string</returns>
		public static String Clean(this String String) {
			String Result = String;
			while (Regex.IsMatch(Result, @"  ")) {
				Result = Result.Replace(@"  ", " ");
			}
			return Result.Trim();
		}


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
		/// Count all occurences of <paramref name="CharToCount"/> in <paramref name="String"/>
		/// </summary>
		/// <param name="String">String to count occurences within</param>
		/// <param name="CharToCount">Char to count occurences of</param>
		/// <returns>The ammount of occurences found</returns>
		public static Int32 Occurences(this String String, Char CharToCount) {
			Int32 c = 0;
			foreach (Char C in String) {
				if (C == CharToCount) c++;
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="CharsToCount"/> in <paramref name="String"/>
		/// </summary>
		/// <param name="String">String to count occurences within</param>
		/// <param name="CharsToCount">Chars to count occurences of</param>
		/// <returns>The ammount of occurences found</returns>
		public static Int32 Occurences(this String String, params Char[] CharsToCount) {
			Int32 c = 0;
			foreach (Char Char in CharsToCount) {
				foreach (Char C in String) {
					if (C == Char) c++;
				}
			}
			return c;
		}

		/// <summary>
		/// In a specified input string, replaces all strings that match a specified regular expression with a specified replacement string. Specified options modify the matching operation.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="Replacement">The replacement string.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.</returns>
		public static String Replace(this String String, String Pattern, String Replacement, RegexOptions RegexOptions = RegexOptions.None) => Regex.Replace(String, Pattern, Replacement, RegexOptions);

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
