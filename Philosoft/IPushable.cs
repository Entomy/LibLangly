namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements pushed onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPushable<TElement> {
		/// <summary>
		/// Inserts an element at the top of the collection.
		/// </summary>
		/// <param name="element">The element to push onto the collection.</param>
		void Push(TElement element);

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="elements">The elements to push onto the collection.</param>
		void Push(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Push(element);
			}
		}

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		void Push<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Push(element);
			}
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Inserts an element at the top of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to push onto the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Push<TElement>(this IPushable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Push(element);
		}

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The element to push onto the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Push<TElement>(this IPushable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Push(elements);
		}

		/// <summary>
		/// Inserts the elements at the top of the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The element to push onto the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		public static void Push<TElement, TEnumerator>(this IPushable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Push(elements);
		}
	}
}
