using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsert<in TIndex, TElement, out TResult> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>The result of inserting the element.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, [AllowNull] TElement element);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, [AllowNull] params TElement[] elements) => Insert(index, elements.AsMemory());

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, Memory<TElement> elements) => Insert(index, (ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, Span<TElement> elements) => Insert(index, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert([DisallowNull] TIndex index, ReadOnlySpan<TElement> elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert<TEnumerator>([DisallowNull] TIndex index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement>;
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, element) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] params TElement[] elements) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, Memory<TElement> elements) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, ReadOnlyMemory<TElement> elements) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, Span<TElement> elements) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, ReadOnlySpan<TElement> elements) {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TIndex">The type of the indicies.</typeparam>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TIndex, TElement, TResult, TEnumerator>([AllowNull] this IInsert<TIndex, TElement, TResult> collection, [DisallowNull] TIndex index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (index is null) {
				throw new IndexOutOfRangeException();
			}
			return collection is not null ? collection.Insert(index, elements) : (TResult)collection;
		}
	}
}
