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
}
