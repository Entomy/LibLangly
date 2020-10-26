using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements removed from it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IRemovable<TElement> {
		/// <summary>
		/// Removes all instances of the <paramref name="element"/> from the collection.
		/// </summary>
		/// <param name="element">The element to remove from the collection.</param>
		void Remove(TElement element);

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <param name="elements">The elements to remove from the collection.</param>
		void Remove(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Remove(element);
			}
		}

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to remove from the collection.</param>
		void Remove<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Remove(element);
			}
		}

		/// <summary>
		/// Removes all instances that match the specified predicate from the collection.
		/// </summary>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to remove.</param>
		void Remove(Predicate<TElement> match);
	}

	public static partial class Extensions {
		/// <summary>
		/// Removes all instances of the <paramref name="element"/> from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to remove from the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Remove(element);
		}

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove from the collection.</param>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Remove(elements);
		}

		/// <summary>
		/// Removes all instances of the <paramref name="elements"/> from the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove from the collection.</param>
		public static void Remove<TElement, TEnumerator>(this IRemovable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Remove(elements);
		}

		/// <summary>
		/// Removes all instances that match the specified predicate from the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to remove.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		public static void Remove<TElement>(this IRemovable<TElement> collection, Predicate<TElement> match) {
			if (collection is null) {
				return;
			}
			collection.Remove(match);
		}
	}
}
