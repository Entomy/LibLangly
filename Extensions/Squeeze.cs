using System;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Squeezes the <paramref name="string"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to squeeze.</param>
		/// <returns>The squeezed <see cref="String"/>.</returns>
		public static String Squeeze(this String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			Char[] chars = new Char[@string.Length];
			Int32 c = 0;
			chars[c] = @string[0];
			for (Int32 s = 1; s < @string.Length; s++) {
				if (chars[c] != @string[s]) {
					c++;
					chars[c] = @string[s];
				}
			}
			return new String(chars, 0, c + 1);
		}
	}
}
