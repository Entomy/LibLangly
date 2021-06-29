namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this instance is <see langword="null"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
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
		/// <typeparam name="T"></typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Nullable<T>> Null<T>(this Assert<Nullable<T>> assert) where T : struct {
			if (assert.Actual is not null) {
				throw new AssertException($"The instance was not null.\nActual: {assert.Actual}");
			}
			return assert;
		}
	}
}
