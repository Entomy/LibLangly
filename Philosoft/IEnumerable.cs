namespace Philosoft {
	/// <summary>
	/// Indicates the type is an enumerator, which supports a simple iteration over a collection of a specified type.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements to enumerate.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator.</typeparam>
	/// <remarks>
	/// This is an improvement that degeneralizes the enumerator, so that heap allocations can potentially be avoided by using a struct.
	/// </remarks>
	public interface IEnumerable<out TElement, TEnumerator> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		TEnumerator GetEnumerator();
	}
}
