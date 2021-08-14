namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Assert that when the object is converted to a <see cref="String"/> it is whats expected.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <param name="expected">The expected <see cref="String"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> ToString<T>(this Assert<T> assert, String expected) {
			String actual = assert.Actual?.ToString() ?? "null";
			if (Equals(actual, expected)) {
				throw new AssertException($"The resulting string was not what was expected.\nActual: {actual}\nExpected: {expected}");
			}
			return assert;
		}

		/// <summary>
		/// Assert that when the object is converted to a <see cref="String"/> it is whats expected.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <param name="expected">The expected <see cref="String"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> ToString<T>(this Assert<T> assert, String expected, String additionalMessage) {
			String actual = assert.Actual?.ToString() ?? "null";
			if (Equals(actual, expected)) {
				throw new AssertException($"The resulting string was not what was expected.\nActual: {actual}\nExpected: {expected}\n{additionalMessage}");
			}
			return assert;
		}
	}
}
