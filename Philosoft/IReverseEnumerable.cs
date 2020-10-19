namespace Philosoft {
	/// <summary>
	/// Indicates the type is a reverse enumerator, which supports a simple reverse iteration over a collection of a specified type.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	/// <remarks>
	/// This is an improvement that degeneralizes the enumerator, so that heap allocations can potentially be avoided by using a struct.
	/// </remarks>
	public interface IReverseEnumerable<out TElement, TEnumerator> where TEnumerator : IReverseEnumerator<TElement> {
		/// <summary>
		/// Returns an enumerator that iterations through a collection in reverse.
		/// </summary>
		/// <returns>A enumerator that can be used to iterate through a collection in reverse.</returns>
		TEnumerator GetReverseEnumerator();
	}
}
