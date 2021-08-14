namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instance is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> Null<T>(this Assert<T> assert) where T : class {
			if (assert.Actual is not null) {
				throw new AssertException($"The instance was not null.\nActual: {assert.Actual}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that this instance is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T> Null<T>(this Assert<T> assert, String additionalMessage) where T : class {
			if (assert.Actual is not null) {
				throw new AssertException($"The instance was not null.\nActual: {assert.Actual}\n{additionalMessage}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that this instance is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T?> Null<T>(this Assert<T?> assert) where T : struct {
			if (assert.Actual is not null) {
				throw new AssertException($"The instance was not null.\nActual: {assert.Actual}");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that this instance is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<T?> Null<T>(this Assert<T?> assert, String additionalMessage) where T : struct {
			if (assert.Actual is not null) {
				throw new AssertException($"The instance was not null.\nActual: {assert.Actual}\n{additionalMessage}");
			}
			return assert;
		}
	}
}
