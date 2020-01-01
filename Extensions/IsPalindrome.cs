using System;
using System.Linq;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Checks if the <paramref name="string"/> is a palindrome.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to check.</param>
		/// <returns><see langword="true"/> if <paramref name="string"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this String @string) => String.Equals(@string, @string.Reverse().ToString(), StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Checks if the <paramref name="span"/> is a palindrome.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check.</param>
		/// <returns><see langword="true"/> if <paramref name="span"/> is a palindrome; otherwise, <see langword="false"/>.</returns>
		public static Boolean IsPalindrome(this ReadOnlySpan<Char> span) {
			for (Int32 i = 0; i < span.Length / 2; i++) {
				if (span[i].ToUpperInvariant() != span[span.Length - 1 - i].ToUpperInvariant()) {
					return false;
				}
			}
			return true;
		}
	}
}