using System;
using System.Text;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Repeat the <paramref name="char"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat the <paramref name="char"/>.</param>
		/// <returns>A <see cref="String"/> containing the repeated <paramref name="char"/>.</returns>
		public static String Repeat(this Char @char, Int32 count) {
			if (count <= 0) {
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer");
			}
			return new String(@char, count);
		}

		/// <summary>
		/// Repeat the <paramref name="string"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat the <paramref name="string"/>.</param>
		/// <returns>A <see cref="String"/> containing the repeated <paramref name="string"/>.</returns>
		public static String Repeat(this String @string, Int32 count) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			if (count <= 0) {
				throw new ArgumentOutOfRangeException(nameof(count), "Count must be a positive integer");
			}
			StringBuilder Result = new StringBuilder(@string.Length * count);
			for (Int32 i = 0; i < count; i++) {
				_ = Result.Append(@string);
			}
			return Result.ToString();
		}
	}
}
