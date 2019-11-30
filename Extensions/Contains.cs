using System;
using System.Collections.Generic;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a value indicating whether a specified char occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="value">The char to seek.</param>
		/// <returns>true if the value parameter occurs within this string, or if value is the empty char (''); otherwise, false.</returns>
		public static Boolean Contains(this String @string, Char value) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return @string.Contains(value.ToString());
		}

		/// <summary>
		/// Returns a value indicating whether a specified char occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="value">The char to seek.</param>
		/// <returns>true if the value parameter occurs within any of the strings, or if the value is the empty char (''); otherwise, false.</returns>
		public static Boolean Contains(this IEnumerable<String> strings, Char value) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			foreach (String String in strings) {
				if (String.Contains(value)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified string occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns>true if the value parameter occurs within any of the strings, or if the value is the empty string (""); otherwise, false.</returns>
		public static Boolean Contains(this IEnumerable<String> strings, String value) {
			if (strings is null || value is null) {
				throw new ArgumentNullException(strings is null ? nameof(strings) : nameof(value));
			}
			foreach (String String in strings) {
				if (String.Contains(value)) {
					return true;
				}
			}
			return false;
		}
	}
}
