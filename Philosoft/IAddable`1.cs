namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <seealso cref="IAddable{TIndex, TElement}"/>
	public interface IAddable<TElement> {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(TElement element);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}
	}
}
