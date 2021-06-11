using System.Diagnostics.CodeAnalysis;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="SinglyLinkedList{TElement}"/>.
	/// </summary>
	public sealed class SinglyLinkedListNode<TElement> : StandardListNode<TElement, SinglyLinkedListNode<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedListNode{TElement}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		public SinglyLinkedListNode([AllowNull] TElement element, [AllowNull] SinglyLinkedListNode<TElement> next) : base(element, next) { }

		/// <inheritdoc/>
		public override void Unlink() => Next = null;

		/// <inheritdoc/>
		[return: NotNull]
		public override SinglyLinkedListNode<TElement> Postpend([AllowNull] TElement element) {
			Next = new SinglyLinkedListNode<TElement>(element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override SinglyLinkedListNode<TElement> Prepend([AllowNull] TElement element) => new SinglyLinkedListNode<TElement>(element, next: this);
	}
}
