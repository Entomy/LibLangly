namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the length of the array is whats expected.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <param name="expected">The expected length.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAssert<T> Length<T>(this ArrayAssert<T> assert, Int32 expected) {
			if (Equals(assert.Actual.Length, expected)) {
				throw new AssertException($"The length was not what was expected.\nActual: {assert.Actual.Length}\nExpected: {expected}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that the length of the array is whats expected.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <param name="expected">The expected length.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAssert<T> Length<T>(this ArrayAssert<T> assert, Int32 expected, String additionalMessage) {
			if (Equals(assert.Actual.Length, expected)) {
				throw new AssertException($"The length was not what was expected.\nActual: {assert.Actual.Length}\nExpected: {expected}\n{additionalMessage}");
			}
			return assert;
		}
	}
}
