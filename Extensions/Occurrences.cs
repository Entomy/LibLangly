using System.Collections.Generic;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Count all occurences of <paramref name="CharToCount"/> in <paramref name="String"/>.
		/// </summary>
		/// <param name="String">String to count occurences within.</param>
		/// <param name="CharToCount">Char to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this String String, Char CharToCount) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			Int32 c = 0;
			foreach (Char C in String) {
				if (C == CharToCount) { c++; }
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="CharsToCount"/> in <paramref name="String"/>.
		/// </summary>
		/// <param name="String">String to count occurences within.</param>
		/// <param name="CharsToCount">Chars to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this String String, params Char[] CharsToCount) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			Int32 c = 0;
			foreach (Char Char in CharsToCount) {
				foreach (Char C in String) {
					if (C == Char) { c++; }
				}
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="CharToCount"/> in the <paramref name="Strings"/>.
		/// </summary>
		/// <param name="Strings">Enumeration of String to count occurences within./</param>
		/// <param name="CharToCount">Char to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this IEnumerable<String> Strings, Char CharToCount) {
			if (Strings is null) {
				throw new ArgumentNullException(nameof(Strings));
			}
			Int32 c = 0;
			foreach (String String in Strings) {
				c += String.Occurrences(CharToCount);
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="CharsToCount"/> in the <paramref name="Strings"/>.
		/// </summary>
		/// <param name="Strings">Enumeration of String to count occurences within.</param>
		/// <param name="CharsToCount">Chars to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this IEnumerable<String> Strings, params Char[] CharsToCount) {
			if (Strings is null || CharsToCount is null) {
				throw new ArgumentNullException(Strings is null ? nameof(Strings) : nameof(CharsToCount));
			}
			Int32 c = 0;
			foreach (String String in Strings) {
				c += String.Occurrences(CharsToCount);
			}
			return c;
		}
	}
}