namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements enqueued into it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IEnqueueSpan<TElement> : IEnqueueMemory<TElement> {
		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue(Span<TElement?> elements);

		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue(ReadOnlySpan<TElement?> elements);
	}
}
