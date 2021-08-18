using System.Traits;

namespace Defender {
	public static partial class TraitAssertions {
		/// <summary>
		/// Asserts that this instance is empty.
		/// </summary>
		/// <typeparam name="T">The type of the elements in the array.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> Empty<T>(this Asserter<T> assert) where T : notnull, ICount => assert.Count(0);
	}
}
