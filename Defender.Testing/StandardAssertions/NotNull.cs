namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instance is not <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> NotNull<T>(this Asserter<T> assert) where T : class {
			if (assert.Actual is null) {
				throw new AssertException($"The instance was null.\nActual: {assert.Actual}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that this instance is not <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T?> NotNull<T>(this Asserter<T?> assert) where T : struct {
			if (assert.Actual is null) {
				throw new AssertException($"The instance was null.\nActual: {assert.Actual}");
			}
			return assert;
		}
	}
}
