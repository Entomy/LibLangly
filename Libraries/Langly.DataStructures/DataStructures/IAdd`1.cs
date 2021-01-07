using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Indicates the type can have other elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IAdd<TElement> {
		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add([AllowNull] TElement element);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add([AllowNull] TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(Memory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(Span<TElement> elements) => Add((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				Add(element);
			}
		}

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Add(element);
			}
		}
	}

	public static partial class DataStructureExtensions {
		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, [AllowNull] TElement element) => collection?.Add(element);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, [AllowNull] TElement[] elements) => collection?.Add(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, Memory<TElement> elements) => collection?.Add(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, ReadOnlyMemory<TElement> elements) => collection?.Add(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, Span<TElement> elements) => collection?.Add(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([AllowNull] this IAdd<TElement> collection, ReadOnlySpan<TElement> elements) => collection?.Add(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement, TEnumerator>([AllowNull] this IAdd<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection?.Add(elements);
	}
}
