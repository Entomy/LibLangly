using System.Collections.Generic;

namespace System {
	public static partial class StringierExtensions {
		/// <summary>
		/// Count all occurences of <paramref name="charToCount"/> in <paramref name="string"/>.
		/// </summary>
		/// <param name="string">String to count occurences within.</param>
		/// <param name="charToCount">Char to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this String @string, Char charToCount) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			Int32 c = 0;
			foreach (Char C in @string) {
				if (C == charToCount) {
					c++;
				}
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="charsToCount"/> in <paramref name="string"/>.
		/// </summary>
		/// <param name="string">String to count occurences within.</param>
		/// <param name="charsToCount">Chars to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this String @string, params Char[] charsToCount) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			Int32 c = 0;
			foreach (Char Char in charsToCount) {
				foreach (Char C in @string) {
					if (C == Char) {
						c++;
					}
				}
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="charToCount"/> in the <paramref name="strings"/>.
		/// </summary>
		/// <param name="strings">Enumeration of String to count occurences within./</param>
		/// <param name="charToCount">Char to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this IEnumerable<String> strings, Char charToCount) {
			if (strings is null) {
				throw new ArgumentNullException(nameof(strings));
			}
			Int32 c = 0;
			foreach (String String in strings) {
				c += String.Occurrences(charToCount);
			}
			return c;
		}

		/// <summary>
		/// Count all occurences of <paramref name="charsToCount"/> in the <paramref name="strings"/>.
		/// </summary>
		/// <param name="strings">Enumeration of String to count occurences within.</param>
		/// <param name="charsToCount">Chars to count occurences of.</param>
		/// <returns>The ammount of occurences found.</returns>
		public static Int32 Occurrences(this IEnumerable<String> strings, params Char[] charsToCount) {
			if (strings is null || charsToCount is null) {
				throw new ArgumentNullException(strings is null ? nameof(strings) : nameof(charsToCount));
			}
			Int32 c = 0;
			foreach (String String in strings) {
				c += String.Occurrences(charsToCount);
			}
			return c;
		}
	}
}