namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instances <see cref="ICount.Count"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected">The expected count.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> Count<T>(this Assert<T> assert, Int32 expected) where T : ICount {
			if (assert.Actual is null) {
				throw new AssertException($"The collection was null, and so its count can't be asserted.");
			}
			if (!Equals(assert.Actual.Count, expected)) {
				throw new AssertException($"The count of elements in the collection was not what was expected.\nActual: {assert.Actual.Count}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
