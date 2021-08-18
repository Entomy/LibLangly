using System;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the instances hash code is the <paramref name="expected"/> value.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <param name="expected">The expected hash code.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> HashCode<T>(this Asserter<T> assert, Int32 expected) where T : notnull {
			if (!Equals(assert.Actual.GetHashCode(), expected)) {
				throw new AssertException($"The hash code did not equal what was expected.\nActual: {assert.Actual.GetHashCode()}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
