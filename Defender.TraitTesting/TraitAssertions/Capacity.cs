using System;
using System.Traits;

namespace Defender {
	public static partial class TraitAssertions {
		/// <summary>
		/// Asserts that this instances <see cref="ICapacity.Capacity"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T">The type of the collection.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <param name="expected">The expected capacity.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> Capacity<T>(this Asserter<T> assert, Int32 expected) where T : notnull, ICapacity {
			if (!Equals(assert.Actual.Capacity, expected)) {
				throw new AssertException($"The capacity of the collection was not what was expected.\nActual: {assert.Actual.Capacity}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
