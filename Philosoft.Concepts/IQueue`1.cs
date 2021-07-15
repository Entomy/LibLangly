namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type can be used as a queue.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the queue.</typeparam>
	public interface IQueue<TElement> : IDequeue<TElement>, IEnqueue<TElement>, IPeek<TElement> { }
}
