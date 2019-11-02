using System.Collections.Generic;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Returns a value indicating whether a specified char occurs within this string.
		/// </summary>
		/// <param name="String">The string to check.</param>
		/// <param name="Value">The char to seek.</param>
		/// <returns>true if the value parameter occurs within this string, or if value is the empty char (''); otherwise, false.</returns>
		public static Boolean Contains(this String String, Char Value) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return String.Contains(Value.ToString());
		}

		/// <summary>
		/// Returns a value indicating whether a specified char occurs within any of the strings.
		/// </summary>
		/// <param name="Strings">The enumeration of strings to check.</param>
		/// <param name="Value">The char to seek.</param>
		/// <returns>true if the value parameter occurs within any of the strings, or if the value is the empty char (''); otherwise, false.</returns>
		public static Boolean Contains(this IEnumerable<String> Strings, Char Value) {
			if (Strings is null) {
				throw new ArgumentNullException(nameof(Strings));
			}
			foreach (String String in Strings) {
				if (String.Contains(Value)) { return true; }
			}
			return false;
		}

		/// <summary>
		/// Returns a value indicating whether a specified string occurs within any of the strings.
		/// </summary>
		/// <param name="Strings">The enumeration of strings to check.</param>
		/// <param name="Value">The string to seek.</param>
		/// <returns>true if the value parameter occurs within any of the strings, or if the value is the empty string (""); otherwise, false.</returns>
		public static Boolean Contains(this IEnumerable<String> Strings, String Value) {
			if (Strings is null || Value is null) {
				throw new ArgumentNullException(Strings is null ? nameof(Strings) : nameof(Value));
			}
			foreach (String String in Strings) {
				if (String.Contains(Value)) { return true; }
			}
			return false;
		}
	}
}
