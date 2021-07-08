namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instance is not <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> NotNull<T>(this Assert<T> assert) where T : class {
			if (assert.Actual is null) {
				throw new AssertException($"The instance was null.\nActual: {assert.Actual}");
			}
			return assert;
		}
	}
}
