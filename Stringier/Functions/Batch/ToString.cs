using System;

namespace Stringier.Functions {
	public static partial class Batch {
		/// <summary>
		/// Converts each of the elements of the array to a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The array of elements to convert.</param>
		/// <returns>An array of strings corresponding to each of the elements of the array.</returns>
		public static String?[]? ToString<T>(T[]? array) {
			if (array is null) {
				return null;
			}
			String?[] result = new String[array.Length];
			for (nint i = 0; i < array.Length; i++) {
				result[i] = array[i]?.ToString();
			}
			return result;
		}
	}
}
