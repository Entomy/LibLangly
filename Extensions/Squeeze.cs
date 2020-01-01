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
			return @string.AsSpan().Squeeze();
		}

		/// <summary>
		/// Squeezes the <paramref name="span"/>, collapsing all adjacent identical characters to single characters.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to squeeze.</param>
		/// <returns>The squeezed <see cref="String"/>.</returns>
		public static String Squeeze(this ReadOnlySpan<Char> span) {
			Char[] chars = new Char[span.Length];
			Int32 c = 0;
			chars[c] = span[0];
			for (Int32 s = 1; s < span.Length; s++) {
				if (chars[c] != span[s]) {
					c++;
					chars[c] = span[s];
				}
			}
			return new String(chars, 0, c + 1);
		}
	}
}
