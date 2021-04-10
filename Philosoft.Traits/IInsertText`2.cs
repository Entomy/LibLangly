using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System.Traits {
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
}
