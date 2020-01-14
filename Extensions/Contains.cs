using System;
using System.Collections.Generic;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a value indicating whether a specified char occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="value">The char to seek.</param>
		/// <returns><see langword="true"/> if the value parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String @string, Char value) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			foreach (Char @char in @string) {
				if (@char == value) {
					return true;
				}
			}
			return false;
		}

#if NETCOREAPP3_0 || NETCOREAPP3_1
		/// <summary>
		/// Returns a value indicating whether a specified rune occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="value">The rune to seek.</param>
		/// <returns><see langword="true"/> if the value parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this String @string, Rune value) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			foreach (Rune rune in @string.EnumerateRunes()) {
				if (rune == value) {
					return true;
				}
			}
			return false;
		}
#endif

		/// <summary>
		/// Returns a value indicating whether a specified char occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="value">The char to seek.</param>
		/// <returns><see langword="true"/> if the value parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> strings, Char value) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			foreach (String @string in strings) {
				if (@string.Contains(value)) {
					return true;
				}
			}
			return false;
		}

#if NETCOREAPP3_0 || NETCOREAPP3_1
		/// <summary>
		/// Returns a value indicating whether a specified char occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="value">The rune to seek.</param>
		/// <returns><see langword="true"/> if the value parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> strings, Rune value) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			foreach (String @string in strings) {
				if (@string.Contains(value)) {
					return true;
				}
			}
			return false;
		}
#endif

		/// <summary>
		/// Returns a value indicating whether a specified string occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns><see langword="true"/> if the value parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains(this IEnumerable<String> strings, String value) {
			if (strings is null || value is null) {
				throw new ArgumentNullException(strings is null ? nameof(strings) : nameof(value));
			}
			foreach (String @string in strings) {
				if (@string.Contains(value)) {
					return true;
				}
			}
			return false;
		}
	}
}
