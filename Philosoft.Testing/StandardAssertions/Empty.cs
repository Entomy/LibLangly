namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the array is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAssert<T> Empty<T>(this ArrayAssert<T> assert) => assert.Length(0);

		/// <summary>
		/// Asserts that the array is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAssert<T> Empty<T>(this ArrayAssert<T> assert, String additionalMessage) => assert.Length(0, additionalMessage);
	}
}
