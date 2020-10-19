namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements enqueued.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IEnqueueable<TElement> {
		/// <summary>
		/// Adds an element to the end of the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		void Enqueue(TElement element);

		/// <summary>
		/// Adds the elements to the end of the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		void Enqueue(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Enqueue(element);
			}
		}

		/// <summary>
		/// Adds the elements to the end of the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		void Enqueue<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Enqueue(element);
			}
		}
	}
}
