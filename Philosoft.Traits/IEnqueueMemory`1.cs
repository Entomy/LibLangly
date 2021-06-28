using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements enqueued into it, with additional array and memory operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IEnqueueMemory<TElement> : IEnqueue<TElement> {
		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue([AllowNull] params TElement?[] elements);

		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue(ArraySegment<TElement?> elements);

		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue(Memory<TElement?> elements);

		/// <summary>
		/// Enqueues the elements into this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to enqueue.</param>
		void Enqueue(ReadOnlyMemory<TElement?> elements);
	}
}
