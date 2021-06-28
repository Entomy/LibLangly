using System.Diagnostics.CodeAnalysis;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Requeues the next element.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="queue">This queue.</param>
		public static void Requeue<TElement>([DisallowNull] this IQueue<TElement> queue) => queue.Enqueue(queue.Dequeue());
	}
}
