using System.Diagnostics.CodeAnalysis;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="SinglyLinkedList{TIndex, TElement}"/>.
	/// </summary>
	public sealed class SinglyLinkedListNode<TIndex, TElement> : StandardListNode<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>> {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedListNode{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		public SinglyLinkedListNode([DisallowNull] TIndex index, [AllowNull] TElement element, [AllowNull] SinglyLinkedListNode<TIndex, TElement> next) : base(index, element, next) { }

		/// <inheritdoc/>
		public override void Unlink() => Next = null;

		/// <inheritdoc/>
		[return: NotNull]
		public override SinglyLinkedListNode<TIndex, TElement> Postpend([DisallowNull] TIndex index, [AllowNull] TElement element) {
			Next = new SinglyLinkedListNode<TIndex, TElement>(index, element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override SinglyLinkedListNode<TIndex, TElement> Prepend([DisallowNull] TIndex index, [AllowNull] TElement element) => new SinglyLinkedListNode<TIndex, TElement>(index, element, next: this);
	}
}
