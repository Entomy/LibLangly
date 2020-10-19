namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements pushed onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPushable<TElement> {
		/// <summary>
		/// Inserts an element at the top of the collection.
		/// </summary>
		/// <param name="element">The element to push onto the collection.</param>
		void Push(TElement element);

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="elements">The elements to push onto the collection.</param>
		void Push(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Push(element);
			}
		}

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		void Push<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Push(element);
			}
		}
	}
}
