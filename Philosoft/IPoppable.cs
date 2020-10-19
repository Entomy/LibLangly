namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements popped off.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPoppable<out TElement> {
		/// <summary>
		/// Removes and returns the element at from top of the collection.
		/// </summary>
		/// <returns>The element removed from the top of the collection.</returns>
		TElement Pop();

		/// <summary>
		/// Removes and returns the elements at the top of the collection.
		/// </summary>
		/// <param name="amount">The amount of elements to pop.</param>
		/// <returns>An <see cref="IEnumerable{TElement, TEnumerator}"/> of the elements.</returns>
		System.Collections.Generic.IEnumerable<TElement> Pop(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Pop();
			}
		}
	}
}
