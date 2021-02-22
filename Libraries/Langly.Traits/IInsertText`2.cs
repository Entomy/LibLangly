using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection can have elements inserted into it, indexed by textual elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being inserted.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IInsertText<TElement, out TResult> : IInsert<Char, TElement, TResult> where TResult : IInsertText<TElement, TResult> {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(Rune index, [AllowNull] TElement element) {
			Span<Char> buffer = new Char[2];
			if (index.EncodeToUtf16(buffer) == 1) {
				return Insert(buffer[0], element);
			} else {
				return Insert(buffer, element);
			}
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert([DisallowNull] String index, [AllowNull] TElement element) => Insert(index.AsMemory(), element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert([DisallowNull] Char[] index, [AllowNull] TElement element) => Insert(index.AsMemory(), element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(Memory<Char> index, [AllowNull] TElement element) => Insert((ReadOnlyMemory<Char>)index, element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(ReadOnlyMemory<Char> index, [AllowNull] TElement element) => Insert(index.Span, element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(Span<Char> index, [AllowNull] TElement element) => Insert((ReadOnlySpan<Char>)index, element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Insert(ReadOnlySpan<Char> index, [AllowNull] TElement element);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, Rune index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, [DisallowNull] String index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, [DisallowNull] Char[] index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, Memory<Char> index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, ReadOnlyMemory<Char> index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, Span<Char> index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TResult"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Insert<TElement, TResult>([AllowNull] this IInsertText<TElement, TResult> collection, ReadOnlySpan<Char> index, [AllowNull] TElement element) where TResult : IInsertText<TElement, TResult> => collection is not null ? collection.Insert(index, element) : (TResult)collection;
	}
}
