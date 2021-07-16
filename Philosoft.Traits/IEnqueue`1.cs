namespace System.Traits {
	/// <summary>
	/// Indicates the type can have elements enqueued into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IEnqueue<in TElement> {
		/// <summary>
		/// Enqueues the element into this object.
		/// </summary>
		/// <param name="element">The element to enqueue.</param>
		void Enqueue(TElement element);
	}
}
