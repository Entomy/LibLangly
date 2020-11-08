using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public static partial class Batch {
		/// <summary>
		/// Converts each of the elements of the array to a string.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="array">The array of elements to convert.</param>
		/// <returns>An array of strings corresponding to each of the elements of the array.</returns>
		[return: NotNullIfNotNull("array")]
		public static String[] ToString<T>([AllowNull] T[] array) {
			if (array is null) {
				return null;
			}
			String[] result = new String[array.Length];
			for (nint i = 0; i < array.Length; i++) {
				result[i] = array[i]?.ToString();
			}
			return result;
		}
	}
}
