using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
		/// Returns a value indicating whether a specified char occurs within this string.
		/// </summary>
		/// <param name="String">The string to check.</param>
		/// <param name="Value">The char to seek.</param>
		/// <returns>true if the value parameter occurs within this string, or if value is the empty char (''); otherwise, false.</returns>
		public static Boolean Contains(this String String, Char Value) => String.Contains(Value.ToString());

		/// <summary>
		/// Ensures the <paramref name="String"/> beings with the <paramref name="Required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="String">The string to ensure.</param>
		/// <param name="Required">The required beginning.</param>
		/// <returns>A string with the ensured beginning.</returns>
		public static String EnsureBeginsWith(this String String, String Required) {
			if (String.IsMatch(RegexOptions.None, "^" + Required)) {
				return String;
			} else {
				return Required + String;
			}
		}
		
		/// <summary>
		/// Ensures the <paramref name="String"/> ends with the <paramref name="Required"/> string, adding it if necessary.
		/// </summary>
		/// <param name="String">The string to ensure.</param>
		/// <param name="Required">The required ending.</param>
		/// <returns>A string with the ensured ending.</returns>
		public static String EnsureEndsWith(this String String, String Required) {
			if (String.IsMatch(RegexOptions.None, Required + "$")) {
				return String;
			} else {
				return String + Required;
			}
		}

		/// <summary>
		/// Indicates whether the regular expression finds a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Regex">The Regex object to use.</param>
		/// <returns>true if the regular expression finds a match; otherwise, false.</returns>
		public static Boolean IsMatch(this String String, Regex Regex) => Regex.IsMatch(String);

		/// <summary>
		/// Indicates whether the regular expression finds a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>true if the regular expression finds a match; otherwise, false.</returns>
		/// <remarks>
		/// This has been made obsolete by what is basically the same method <see cref="IsMatch(String, RegexOptions, String)"/>, but with <paramref name="Pattern"/> and <paramref name="RegexOptions"/> reversed. This was done for orthogonality with <see cref="IsMatchAll(String, RegexOptions, String[])"/>.
		/// </remarks>
		[Obsolete("Please use the new form String.IsMatch(RegexOption, String)")]
		public static Boolean IsMatch(this String String, String Pattern, RegexOptions RegexOptions) => Regex.IsMatch(String, Pattern, RegexOptions);

		/// <summary>
		/// Indicates whether the regular expression finds a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <returns>true if the regular expression finds a match; otherwise, false.</returns>
		public static Boolean IsMatch(this String String, RegexOptions RegexOptions, String Pattern) => Regex.IsMatch(String, Pattern, RegexOptions);

		/// <summary>
		/// Indicates whether the regular expressions all find a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Regexes">An array of the Regex objects to use.</param>
		/// <returns>true if the regular expressions all find a match; otherwise, false.</returns>
		public static Boolean IsMatchAll(this String String, params Regex[] Regexes) {
			Boolean Result = true;
			foreach (Regex Regex in Regexes) {
				Result &= String.IsMatch(Regex);
			}
			return Result;
		}

		/// <summary>
		/// Indicates whether the regular expressions all find a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <param name="Patterns">An array of the regular expression pattern to match.</param>
		/// <returns>true if the regular expressions all find a match; otherwise, false.</returns>
		public static Boolean IsMatchAll(this String String, RegexOptions RegexOptions, params String[] Patterns) {
			Boolean Result = true;
			foreach (String Pattern in Patterns) {
				Result &= String.IsMatch(RegexOptions, Pattern);
			}
			return Result;
		}

		/// <summary>
		/// Indicates whether any of the regular expressions find a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Regexes">An array of the Regex objects to use.</param>
		/// <returns>true if any of the regular expressions find a match; otherwise false.</returns>
		public static Boolean IsMatchAny(this String String, params Regex[] Regexes) {
			Boolean Result = false;
			foreach (Regex Regex in Regexes) {
				Result |= String.IsMatch(Regex);
			}
			return Result;
		}

		/// <summary>
		/// Indicates whether any of the regular expressions find a match in the input string.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <param name="Patterns">An array of the regular expression pattern to match.</param>
		/// <returns>true if any of the regular expressions find a match; otherwise false.</returns>
		public static Boolean IsMatchAny(this String String, RegexOptions RegexOptions, params String[] Patterns) {
			Boolean Result = false;
			foreach (String Pattern in Patterns) {
				Result |= String.IsMatch(RegexOptions, Pattern);
			}
			return Result;
		}

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="Strings">An array that contains the strings to concatenate.</param>
		/// <param name="Separator">The char to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator char. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this String[] Strings, Char Separator) => String.Join(Separator.ToString(), Strings);

		/// <summary>
		/// Concatenates all the elements of a string enumerable, using the specified separator between each element.
		/// </summary>
		/// <param name="Strings">An enumerable that contains the strings to concatenate.</param>
		/// <param name="Separator">The char to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator char. If value is an empty enumerable, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> Strings, Char Separator) => String.Join(Separator.ToString(), Strings);

		/// <summary>
		/// Concatenates all the elements of a string array, using the specified separator between each element.
		/// </summary>
		/// <param name="Strings">An array that contains the strings to concatenate.</param>
		/// <param name="Separator">The string to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator string. If value is an empty array, the method returns Empty.</returns>
		public static String Join(this String[] Strings, String Separator) => String.Join(Separator, Strings);

		/// <summary>
		/// Concatenates all the elements of a string enumerable, using the specified separator between each element.
		/// </summary>
		/// <param name="Strings">An enumerable that contains the strings to concatenate.</param>
		/// <param name="Separator">The string to use as a separator. Separator is included in the returned string only if value has more than one element.</param>
		/// <returns>A string that consists of the elements in value delimited by the separator string. If value is an empty enumerable, the method returns Empty.</returns>
		public static String Join(this IEnumerable<String> Strings, String Separator) => String.Join(Separator, Strings);

		/// <summary>
		/// Searches an input string for a substring that matches a regular expression pattern and returns the first occurrence as a single Match object.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that provide options for matching.</param>
		/// <returns>An object that contains information about the match.</returns>
		public static Match Match(this String String, String Pattern, RegexOptions RegexOptions) => Regex.Match(String, Pattern, RegexOptions);

		/// <summary>
		/// Searches an input string for a substring that matches a regular expression pattern and returns the first occurrence as a single Match object.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Regex">The Regex object to use.</param>
		/// <returns>An object that contains information about the match.</returns>
		public static Match Match(this String String, Regex Regex) => Regex.Match(String);

		/// <summary>
		/// Searches an input string for all occurrences of a regular expression and returns all the matches.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Pattern">The regular expression pattern to match.</param>
		/// <param name="RegexOptions">A bitwise combination of the enumeration values that specify options for matching.</param>
		/// <returns>A collection of the Match objects found by the search. If no matches are found, the method returns an empty collection object.</returns>
		public static MatchCollection Matches(this String String, String Pattern, RegexOptions RegexOptions) => Regex.Matches(String, Pattern, RegexOptions);

		/// <summary>
		/// Searches an input string for all occurrences of a regular expression and returns all the matches.
		/// </summary>
		/// <param name="String">The string to search for a match.</param>
		/// <param name="Regex">The Regex object to use.</param>
		/// <returns>A collection of the Match objects found by the search. If no matches are found, the method returns an empty collection object.</returns>
		public static MatchCollection Matches(this String String, Regex Regex) => Regex.Matches(String);

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
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="String">The string to pad.</param>
		/// <param name="TotalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String String, Int32 TotalWidth) {
			Int32 LeftPadWidth = String.Length + ((TotalWidth - String.Length) / 2);
			return String.PadLeft(LeftPadWidth).PadRight(TotalWidth);
		}

		/// <summary>
		/// Returns a new string that center-aligns the characters in this instance by padding them with spaces on both sides, for a specified total length.
		/// </summary>
		/// <param name="String">The string to pad.</param>
		/// <param name="TotalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
		/// <param name="PaddingChar">A Unicode padding character.</param>
		/// <returns>A new string that is equivalent to this instance, but center-aligned and padded on both sides with as many spaces as needed to create a length of totalWidth. However, if totalWidth is less than the length of this instance, the method returns a reference to the existing instance. If totalWidth is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
		public static String Pad(this String String, Int32 TotalWidth, Char PaddingChar) {
			Int32 LeftPadWidth = String.Length + ((TotalWidth - String.Length) / 2);
			return String.PadLeft(LeftPadWidth).PadRight(TotalWidth);
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
		/// Splits a string into substrings based on the strings in an array.
		/// </summary>
		/// <param name="String">The string to split.</param>
		/// <param name="Separator">A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>A string array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</returns>
		public static String[] Split(this String String, params String[] Separator) => String.Split(Separator, StringSplitOptions.None);

		/// <summary>
		/// Converts the specified string to camel case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to camel case.</param>
		/// <returns>The specified string converted to camel case</returns>
		public static String ToCamelCase(this String String) => Char.ToLowerInvariant(String[0]) + String.ToPascalCase().Substring(1);

		/// <summary>
		/// Converts the specified string to camel case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to camel case.</param>
		/// <param name="Culture">A predefined CultureInfo identifier, LCID property of an existing CultureInfo object, or Windows-only culture identifier.</param>
		/// <returns>The specified string converted to camel case</returns>
		public static String ToCamelCase(this String String, Int32 Culture) => Char.ToLower(String[0], CultureInfo.GetCultureInfo(Culture)) + String.ToPascalCase(Culture).Substring(1);

		/// <summary>
		/// Converts the specified string to camel case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to camel case.</param>
		/// <param name="Culture">A predefined CultureInfo name, Name of an existing CultureInfo, or Windows-only culture name. name is not case-sensitive.</param>
		/// <returns>The specified string converted to camel case.</returns>
		public static String ToCamelCase(this String String, String Culture) => Char.ToLower(String[0], CultureInfo.GetCultureInfo(Culture)) + String.ToPascalCase(Culture).Substring(1);

		/// <summary>
		/// Converts the specified string to Pascal case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to Pascal case.</param>
		/// <returns>The specified string converted to Pascal case.</returns>
		public static String ToPascalCase(this String String) {
			String Result = "";
			foreach (String S in String.Words()) {
				Result += S.ToTitleCase();
			}
			return Result;
		}

		/// <summary>
		/// Converts the specified string to Pascal case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to Pascal case.</param>
		/// <param name="Culture">A predefined CultureInfo identifier, LCID property of an existing CultureInfo object, or Windows-only culture identifier.</param>
		/// <returns>The specified string converted to Pascal case.</returns>
		public static String ToPascalCase(this String String, Int32 Culture) {
			String Result = "";
			foreach (String S in String.Words()) {
				Result += S.ToTitleCase(Culture);
			}
			return Result;
		}

		/// <summary>
		/// Converts the specified string to Pascal case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to Pascal case.</param>
		/// <param name="Culture">A predefined CultureInfo name, Name of an existing CultureInfo, or Windows-only culture name. name is not case-sensitive.</param>
		/// <returns>The specified string converted to Pascal case.</returns>
		public static String ToPascalCase(this String String, String Culture) {
			String Result = "";
			foreach (String S in String.Words()) {
				Result += S.ToTitleCase(Culture);
			}
			return Result;
		}

		/// <summary>
		/// Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).
		/// </summary>
		/// <param name="String">The string to convert to title case.</param>
		/// <returns>The specified string converted to title case.</returns>
		public static String ToTitleCase(this String String) => new CultureInfo(CultureInfo.InvariantCulture.Name).TextInfo.ToTitleCase(String);

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

		/// <summary>
		/// Separate the <paramref name="String"/> into its words
		/// </summary>
		/// <param name="String">String to separate</param>
		/// <returns>Array of words within the <paramref name="String"/></returns>
		public static String[] Words(this String String) => String.Clean().Split(' ');

	}
}
