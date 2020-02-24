using System;
using Defender;

namespace Stringier {
	public static partial class StringierExtensions {
		/// <summary>
		/// Converts each member of <paramref name="array"/> to its string representation.
		/// </summary>
		/// <typeparam name="T">The type of the members of <paramref name="array"/>.</typeparam>
		/// <param name="array">An <see cref="Array"/> of elements to convert.</param>
		/// <returns>An <see cref="Array"/> of <see cref="String"/> with each member of <paramref name="array"/> converted to its string representation.</returns>
		public static String[] ToStrings<T>(this T[] array) where T : struct {
			Guard.NotNull(array, nameof(array));
			String[] result = new String[array.Length];
			for (Int32 i = 0; i < array.Length; i++) {
				result[i] = array[i].ToString();
			}
			return result;
		}

		/// <summary>
		/// Converts each member of <paramref name="array"/> to its string representation.
		/// </summary>
		/// <typeparam name="T">The type of the members of <paramref name="array"/>.</typeparam>
		/// <param name="array">An <see cref="Array"/> of elements to convert.</param>
		/// <param name="nullReplacement">The <see cref="String"/> to use instead, if a member is <see langword="null"/>.</param>
		/// <returns>An <see cref="Array"/> of <see cref="String"/> with each member of <paramref name="array"/> converted to its string representation.</returns>
		public static String[] ToStrings<T>(this T?[] array, String nullReplacement) where T : struct {
			Guard.NotNull(array, nameof(array));
			Guard.NotNull(nullReplacement, nameof(nullReplacement));
			String[] result = new String[array.Length];
			for (Int32 i = 0; i < array.Length; i++) {
				result[i] = array[i]?.ToString() ?? nullReplacement;
			}
			return result;
		}

		/// <summary>
		/// Converts each member of <paramref name="array"/> to its string representation.
		/// </summary>
		/// <typeparam name="T">The type of the members of <paramref name="array"/>.</typeparam>
		/// <param name="array">An <see cref="Array"/> of elements to convert.</param>
		/// <param name="nullReplacement">The <see cref="String"/> to use instead, if a member is <see langword="null"/>.</param>
		/// <returns>An <see cref="Array"/> of <see cref="String"/> with each member of <paramref name="array"/> converted to its string representation.</returns>
		public static String[] ToStrings<T>(this T?[] array, String nullReplacement) where T : class {
			Guard.NotNull(array, nameof(array));
			Guard.NotNull(nullReplacement, nameof(nullReplacement));
			String[] result = new String[array.Length];
			for (Int32 i = 0; i < array.Length; i++) {
				result[i] = array[i]?.ToString() ?? nullReplacement;
			}
			return result;
		}
	}
}
