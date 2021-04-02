using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsertSpan<TElement, out TResult> : IInsert<TElement, TResult> where TResult : IInsertSpan<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IInsert<TElement, TResult>.Insert(nint index, Memory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IInsert<TElement, TResult>.Insert(nint index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(nint index, Span<TElement> elements) => Insert(index, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(nint index, ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			foreach (TElement element in elements) {
				if ((result = ((IInsert<nint, TElement, TResult>)result).Insert(index++, element)) is null) { return default; }
			}
			return result;
		}
	}

	public static partial class TraitExtensions {
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
	}
}
