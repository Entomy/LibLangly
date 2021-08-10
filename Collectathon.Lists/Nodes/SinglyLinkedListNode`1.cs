using System;
using System.Traits;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="SinglyLinkedList{TElement}"/>.
	/// </summary>
	public sealed class SinglyLinkedListNode<TElement> :
		IContains<TElement>,
		ICount,
		IElement<TElement>,
		INext<SinglyLinkedListNode<TElement>?>,
		IReplace<TElement>,
		IUnlink {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedListNode{TElement}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		public SinglyLinkedListNode(TElement element, SinglyLinkedListNode<TElement>? next) {
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		public Int32 Count => 1;

		/// <inheritdoc/>
		public TElement Element { get; set; }

		/// <summary>
		/// The next node in the list.
		/// </summary>
		public SinglyLinkedListNode<TElement>? Next { get; set; }

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Equals(Element, element);

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => predicate?.Invoke(Element) ?? Element is null;

		/// <inheritdoc/>
		public SinglyLinkedListNode<TElement> Postpend(TElement element) {
			Next = new SinglyLinkedListNode<TElement>(element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		public SinglyLinkedListNode<TElement> Prepend(TElement element) => new SinglyLinkedListNode<TElement>(element, next: this);

		/// <inheritdoc/>
		public void Replace(TElement search, TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		public override String ToString() => Element?.ToString() ?? "";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
