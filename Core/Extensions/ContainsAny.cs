using System;
using System.Collections.Generic;
using System.Text;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a value indicating whether any specified char occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="values">The chars to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this String @string, params Char[] values) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(values, nameof(values));
			foreach (Char @char in @string) {
				foreach (Char value in values) {
					if (@char == value) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether any specified rune occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="values">The runes to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this String @string, params Rune[] values) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(values, nameof(values));
			foreach (Rune rune in @string) {
				foreach (Rune value in values) {
					if (rune == value) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether any specified string occurs within this string.
		/// </summary>
		/// <param name="string">The string to check.</param>
		/// <param name="values">The runes to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within this string; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this String @string, params String[] values) {
			Guard.NotNull(@string, nameof(@string));
			Guard.NotNull(values, nameof(values));
			foreach (String value in values) {
				if (@string.Contains(value)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether any specified char occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The string to check.</param>
		/// <param name="values">The chars to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this IEnumerable<String> strings, params Char[] values) {
			Guard.NotNull(strings, nameof(strings));
			Guard.NotNull(values, nameof(values));
			foreach (String @string in strings) {
				foreach (Char @char in @string) {
					foreach (Char value in values) {
						if (@char == value) {
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether any specified rune occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The string to check.</param>
		/// <param name="values">The runes to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this IEnumerable<String> strings, params Rune[] values) {
			Guard.NotNull(strings, nameof(strings));
			Guard.NotNull(values, nameof(values));
			foreach (String @string in strings) {
				foreach (Rune rune in @string.EnumerateRunes()) {
					foreach (Rune value in values) {
						if (rune == value) {
							return true;
						}
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether any specified string occurs within any of the strings.
		/// </summary>
		/// <param name="strings">The enumeration of strings to check.</param>
		/// <param name="values">The strings to seek.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="values"/> parameter occurs within any of the strings; otherwise, <see langword="false"/>.</returns>
		public static Boolean ContainsAny(this IEnumerable<String> strings, params String[] values) {
			Guard.NotNull(strings, nameof(strings));
			Guard.NotNull(values, nameof(values));
			foreach (String @string in strings) {
				foreach (String value in values) {
					if (@string.Contains(value)) {
						return true;
					}
				}
			}
			return false;
		}
	}
}
