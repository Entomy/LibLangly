using System;
using System.Traits;

namespace Defender {
	public static partial class TraitAssertions {
		/// <summary>
		/// Asserts that this instances <see cref="ICount.Count"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <param name="expected">The expected count.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> Count<T>(this Asserter<T> assert, Int32 expected) where T : notnull, ICount {
			if (!Equals(assert.Actual.Count, expected)) {
				throw new AssertException($"The count of elements in the collection was not what was expected.\nActual: {assert.Actual.Count}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
