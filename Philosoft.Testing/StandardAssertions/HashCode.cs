namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the instances hash code is the <paramref name="expected"/> value.
		/// </summary>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected">The expected hash code.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> HashCode<T>(this Assert<T> assert, Int32 expected) {
			if (assert.Actual is null) {
				throw new AssertException($"The collection was null, and so its hash code can't be asserted.");
			}
			Int32 actual = assert.Actual.GetHashCode();
			if (!Equals(actual, expected)) {
				throw new AssertException($"The hash code did not equal what was expected.\nActual: {actual}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
