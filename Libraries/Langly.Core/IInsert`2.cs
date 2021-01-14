using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsert<TElement, out TResult> : IInsert<nint, TElement, TResult> {
		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert(nint index, [AllowNull] params TElement[] elements) => Insert(index, elements.AsMemory());

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert(nint index, Memory<TElement> elements) => Insert(index, (ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert(nint index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>The result of inserting the elements.</returns>
		[return: NotNull]
		TResult Insert(nint index, Span<TElement> elements) => Insert(index, (ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		[return: NotNull]
		TResult Insert(nint index, ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				_ = ((IInsert<nint, TElement, TResult>)this).Insert(index++, element);
			}
			return (TResult)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TResult Insert<TEnumerator>(nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					_ = ((IInsert<nint, TElement, TResult>)this).Insert(index++, element);
				}
			}
			return (TResult)this;
		}
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] params TElement[] elements) => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, Memory<TElement> elements) => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, Span<TElement> elements) => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsert<TElement, TResult> collection, nint index, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Insert(index, elements) : (TResult)collection;

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Insert<TElement, TResult, TEnumerator>([AllowNull] this IInsert<TElement, TResult> collection, nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Insert(index, elements) : (TResult)collection;
	}
}
