using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Queues {
	public static partial class QueueExtensions {
		/// <summary>
		/// Requeues the next element, placing it back into the queue.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the queue.</typeparam>
		/// <param name="queue">This queue.</param>
		public static void Requeue<TElement>([DisallowNull] this Queue<TElement> queue) => queue.Enqueue(queue.Dequeue());
	}
}
