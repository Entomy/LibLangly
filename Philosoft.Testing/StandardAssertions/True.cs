namespace System.Traits.Testing {
	public static partial class TraitAssertions {
		/// <summary>
		/// Asserts that the expression evaluated to <see langword="true"/>.
		/// </summary>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Boolean> True(this Assert<Boolean> assert) {
			if (!assert.Actual) {
				throw new AssertException($"The expression was expected to be true, but was false.");
			}
			return assert;
		}
	}
}
