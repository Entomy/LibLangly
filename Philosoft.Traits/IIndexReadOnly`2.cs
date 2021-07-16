namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable, read only.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IIndexReadOnly<in TIndex, out TElement> where TIndex : notnull {
		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		TElement this[TIndex index] { get; }
	}
}
