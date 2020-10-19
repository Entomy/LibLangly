namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements dequeued.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IDequeueable<out TElement> {
		/// <summary>
		/// Removes and returns the element from the beginning of the collection.
		/// </summary>
		/// <returns>The element that is removed from the beginning of the collection.</returns>
		TElement Dequeue();

		/// <summary>
		/// Removes and returns the elements from the beginning of the collection.
		/// </summary>
		/// <param name="amount">The amount of elements to dequeue.</param>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		System.Collections.Generic.IEnumerable<TElement> Dequeue(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Dequeue();
			}
		}
	}
}
