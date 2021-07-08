namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the array is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAssert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAssert<T> Empty<T>(this ArrayAssert<T> assert) => assert.Length(0);
	}
}
