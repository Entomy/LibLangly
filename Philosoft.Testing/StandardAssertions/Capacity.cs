namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instances <see cref="ICapacity.Capacity"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected">The expected capacity.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> Capacity<T>(this Assert<T> assert, Int32 expected) where T : ICapacity {
			if (!Equals(assert.Actual.Capacity, expected)) {
				throw new AssertException($"The capacity of the collection was not what was expected.\nActual: {assert.Actual.Capacity}\nExpected: {expected}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that this instances <see cref="ICapacity.Capacity"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected">The expected capacity.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> Capacity<T>(this Assert<T> assert, Int32 expected, String additionalMessage) where T : ICapacity {
			if (!Equals(assert.Actual.Capacity, expected)) {
				throw new AssertException($"The capacity of the collection was not what was expected.\nActual: {assert.Actual.Capacity}\nExpected: {expected}\n{additionalMessage}");
			}
			return assert;
		}
	}
}
