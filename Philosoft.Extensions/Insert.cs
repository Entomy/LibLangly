﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] TElement element) where TResult : IInsert<TIndex, TElement, TResult> {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, element) : (TResult)collection;
		}

		#region Insert(Collection, nint, TElement)
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] TElement element) where TResult : IInsert<TElement, TResult> => collection is not null ? ((IInsert<nint, TElement, TResult>)collection).Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns an <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("element")]
		public static TElement[] Insert<TElement>([AllowNull] this TElement[] collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			Array[index] = element;
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + 1));
			return Array;
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns an <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			Array[index] = element;
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + 1));
			return Array;
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>Returns an <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, [AllowNull] TElement element) {
			if (element is null) {
				return collection;
			} else if (collection.Length == 0) {
				return new[] { element };
			}
			TElement[] Array = new TElement[collection.Length + 1];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			Array[index] = element;
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + 1));
			return Array;
		}
		#endregion

		#region Insert(Collection, nint, TElement[])
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] params TElement[] elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns an <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("elements")]
		public static TElement[] Insert<TElement>([AllowNull] this TElement[] collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, [AllowNull] params TElement[] elements) {
			if (elements is null || elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}
		#endregion

		#region Insert(Collection, nint, Memory<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, Memory<TElement> elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static Memory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, Memory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}
		#endregion

		#region Insert(Collection, nint, ReadOnlyMemory<TElement>)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, ReadOnlyMemory<TElement> elements) where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>([AllowNull] this TElement[] collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection is null || collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this Memory<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and inserted elements.</returns>
		public static ReadOnlyMemory<TElement> Insert<TElement>(this ReadOnlyMemory<TElement> collection, nint index, ReadOnlyMemory<TElement> elements) {
			if (elements.Length == 0) {
				return collection;
			} else if (collection.Length == 0) {
				return elements;
			}
			TElement[] Array = new TElement[collection.Length + elements.Length];
			collection.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.Slice((Int32)index));
			collection.Slice((Int32)index).CopyTo(Array.Slice((Int32)index + elements.Length));
			return Array;
		}
		#endregion

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertSpan<TElement, TResult> collection, nint index, Span<TElement> elements) where TResult : IInsertSpan<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertSpan<TElement, TResult> collection, nint index, ReadOnlySpan<TElement> elements) where TResult : IInsertSpan<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <param name="length">The length of the <paramref name="collection"/>.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Insert<TElement, TResult>([AllowNull] this IInsertUnsafe<TElement, TResult> collection, nint index, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IInsertUnsafe<TElement, TResult> => collection is not null ? collection.Insert(index, elements, length) : (TResult)collection;

		#region Insert(Collection, nint, Sequence)
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult, TEnumerator>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> where TResult : IInsert<TElement, TResult> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		#endregion
	}
}
