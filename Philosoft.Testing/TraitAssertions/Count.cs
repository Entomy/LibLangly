namespace System.Traits.Testing {
	public static partial class TraitAssertions {
		/// <summary>
		/// Asserts that this instances <see cref="ICount.Count"/> is what was <paramref name="expected"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="expected"></param>
		/// <returns></returns>
		public static Assert<T> Count<T>(this Assert<T> assert, Int32 expected) where T : ICount {
			if (!Equals(assert.Actual.Count, expected)) {
				throw new AssertException($"The count of elements in the collection was not what was expected.\nActual: {assert.Actual.Count}\nExpected: {expected}");
			}
			return assert;
		}
	}
}
