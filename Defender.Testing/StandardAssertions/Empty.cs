namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the array is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="ArrayAsserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static ArrayAsserter<T> Empty<T>(this ArrayAsserter<T> assert) => assert.Length(0);
	}
}
