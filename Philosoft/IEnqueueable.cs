namespace Langly {
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

	public static partial class Extensions {
		/// <summary>
		/// Adds an element to the end of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void Enqueue<TElement>(this IEnqueueable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Enqueue(element);
		}

		/// <summary>
		/// Adds the elements to the end of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void Enqueue<TElement>(this IEnqueueable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Enqueue(elements);
		}

		/// <summary>
		/// Adds the elements to the end of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		public static void Enqueue<TElement, TEnumerator>(this IEnqueueable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Enqueue(elements);
		}
	}
}
