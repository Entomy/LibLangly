using System;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the instance is of the <typeparamref name="T"/> type.
		/// </summary>
		/// <typeparam name="T">The expected type.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> Type<T>(this Asserter<Object> assert) where T : notnull {
			switch (assert.Actual) {
			case T act:
				return new(act);
			default:
				throw new AssertException($"The instance was not of the expected type.\nActual: {assert.Actual.GetType()}\nExpected: {typeof(T)}");
			}
		}
	}
}
