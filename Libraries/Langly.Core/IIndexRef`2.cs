namespace Langly {
	/// <summary>
	/// Indicates the type is indexable by reference, read and write.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IIndexRef<in TIndex, TElement> : IIndexRefReadOnly<TIndex, TElement> {
		/// <summary>
		/// Gets a reference to the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get a reference for.</param>
		/// <returns>A reference to the element at the specified index.</returns>
		new ref TElement this[TIndex index] { get; }
	}
}
