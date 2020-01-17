using System;
using System.Linq;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Checks if the <paramref name="string"/> is a palindrome.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to check.</param>
		/// <returns><see langword="true"/> if <paramref name="string"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this String @string) => !(@string is null) && @string.AsSpan().IsPalindrome();

		/// <summary>
		/// Checks if the <paramref name="span"/> is a palindrome.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check.</param>
		/// <returns><see langword="true"/> if <paramref name="span"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this ReadOnlySpan<Char> span) {
			// First we need to build the string without any punctuation or whitespace or any other unrelated-to-reading characters
			Char[] builder = new Char[span.Length];
			Int32 b = 0;
			foreach (Char s in span) {
				if (!(s.IsControl() || s.IsPunctuation() || s.IsSeparator() || s.IsSymbol() || s.IsWhiteSpace())) {
					builder[b++] = s;
				}
			}
			String prepped = new String(builder, 0, b);
			String reversed = prepped.Reverse().Join();
			// Now actually check it's a palindrome
			return String.Equals(prepped, reversed, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}
