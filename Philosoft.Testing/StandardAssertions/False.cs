namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the expression evaluated to <see langword="false"/>.
		/// </summary>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Boolean> False(this Assert<Boolean> assert) {
			if (assert.Actual) {
				throw new AssertException($"The expression was expected to be false, but was true.");
			}
			return assert;
		}
	}
}
