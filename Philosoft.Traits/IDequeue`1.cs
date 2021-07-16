namespace System.Traits {
	/// <summary>
	/// Indicates the type can have elements dequeued from it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IDequeue<out TElement> {
		/// <summary>
		/// Dequeues the next element.
		/// </summary>
		/// <returns>The next element.</returns>
		TElement Dequeue();
	}
}
