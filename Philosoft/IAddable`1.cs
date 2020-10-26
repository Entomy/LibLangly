using System;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection can have elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <seealso cref="IAddable{TIndex, TElement}"/>
	public interface IAddable<TElement> {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(TElement element);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(params TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Memory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Span<TElement> elements) => Add((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add<TEnumerator>(IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(element);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, params TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, Memory<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, ReadOnlyMemory<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, Span<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement>(this IAddable<TElement> collection, ReadOnlySpan<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds the elements into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this collection.</typeparam>
		/// <remarks>
		/// The behavior of this operation is collection dependent, and no particular location in the collection should be assumed.
		/// </remarks>
		public static void Add<TElement, TEnumerator>(this IAddable<TElement> collection, IEnumerable<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}
	}
}
