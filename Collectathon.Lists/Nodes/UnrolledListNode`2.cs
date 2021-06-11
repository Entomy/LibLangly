using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="UnrolledList{TElement, TNode, TSelf}"/> node.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the nodes.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract partial class UnrolledListNode<TElement, TSelf> : ListNode<TElement, TSelf>,
		IIndexReadOnly<nint, TElement>,
		ISequence<TElement, UnrolledListNode<TElement, TSelf>.Enumerator>
		where TSelf : UnrolledListNode<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="UnrolledListNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="next">The next node in the list.</param>
		protected UnrolledListNode([AllowNull] TSelf next) : base(next) { }

		/// <inheritdoc/>
		[MaybeNull]
		public abstract TElement this[[DisallowNull] nint index] { get; }

		/// <inheritdoc/>
		[return: NotNull]
		public UnrolledListNode<TElement, TSelf>.Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>A list section to be relinked.</returns>
		public abstract (TSelf Head, TSelf Tail) Insert(nint index, [AllowNull] TElement element);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		/// <returns>A list section to be relinked.</returns>
		public abstract (TSelf Head, TSelf Tail) Insert(nint index, ReadOnlyMemory<TElement> elements);

		/// <summary>
		/// Postpends the <paramref name="elements"/> onto this node.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The node that was postpended.</returns>
		[return: NotNull]
		public abstract TSelf Postpend(ReadOnlyMemory<TElement> elements);

		/// <summary>
		/// Prepends the <paramref name="elements"/> onto this node.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The node that was prepended.</returns>
		[return: NotNull]
		public abstract TSelf Prepend(ReadOnlyMemory<TElement> elements);

		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <param name="element">The element to remove.</param>
		/// <returns>A list section to be relinked.</returns>
		public abstract (TSelf Head, TSelf Tail) Remove([AllowNull] TElement element);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();

		/// <inheritdoc/>
		[return: NotNull]
		public abstract String ToString(nint amount);
	}
}
