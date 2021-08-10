﻿using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert(this IInsert<Index, Char> collection, Index index, String? elements) => Insert(collection, index, elements.AsSpan());

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert(this IInsertMemory<Index, Char> collection, Index index, String? elements) => collection.Insert(index, elements.AsMemory());

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, params TElement[]? elements) => Insert(collection, index, elements.AsSpan());

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, ArraySegment<TElement> elements) => Insert(collection, index, elements.AsSpan());

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, Memory<TElement> elements) => Insert(collection, index, elements.Span);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// /// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, ReadOnlyMemory<TElement> elements) => Insert(collection, index, elements.Span);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, Span<TElement> elements) => Insert(collection, index, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Insert(index, elements[i]);
				index = index.Value + 1;
			}
		}

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Insert<TElement>(this IInsert<Index, TElement> collection, Index index, TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Insert(index, elements[i]);
				index = index.Value + 1;
			}
		}

		/// <summary>
		/// Inserts the elements to this collection at the specified index, as a batch.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe void Insert<TElement>(this IInsertSpan<Index, TElement> collection, Index index, TElement* elements, Int32 length) where TElement : unmanaged => collection.Insert(index, new Span<TElement>(elements, length));

		/// <summary>
		/// Inserts the elements into the collection at the specified index, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		public static void Insert<TElement, TEnumerator>(this IInsert<Index, TElement> collection, Index index, IGetEnumerator<TElement, TEnumerator>? elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Insert(index, element);
					index = index.Value + 1;
				}
			}
		}
	}
}
