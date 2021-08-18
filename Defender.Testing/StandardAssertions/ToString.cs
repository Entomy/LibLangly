using System;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Assert that when the object is converted to a <see cref="String"/> it is whats expected.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <param name="expected">The expected <see cref="String"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> ToString<T>(this Asserter<T> assert, String expected) where T : notnull {
			String actual = assert.Actual.ToString()!;
			if (Equals(actual, expected)) {
				throw new AssertException($"The resulting string was not what was expected.\nActual: {actual}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
