using System.Collections;

namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this <see cref="IEnumerable"/> produces an <see cref="IEnumerator"/> that iterates <paramref name="expected"/> times.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected">The expected count of iterations.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T?> EnumerationCount<T>(this Assert<T?> assert, Int32 expected) where T : IEnumerable {
			Int32 a = 0;
			if (assert.Actual is not null) {
				IEnumerator act = assert.Actual.GetEnumerator();
				while (act.MoveNext()) { a++; }
			}
			if (a != expected) {
				throw new AssertException($"The count of elements enumerated was not what was expected.\nActual: {a}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
