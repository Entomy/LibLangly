using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="SinglyLinkedList{TIndex, TElement}"/>.
	/// </summary>
	public sealed class SinglyLinkedListNode<TIndex, TElement> :
		IContains<TElement>,
		ICount,
		IElement<TElement>,
		IIndex<TIndex>,
		INext<SinglyLinkedListNode<TIndex, TElement>?>,
		IReplace<TElement>,
		IUnlink
		where TIndex : notnull {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedListNode{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		public SinglyLinkedListNode(TIndex index, TElement element, SinglyLinkedListNode<TIndex, TElement>? next) {
			Index = index;
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		public Int32 Count => 1;

		/// <inheritdoc/>
		public TElement Element { get; set; }

		/// <inheritdoc/>
		public TIndex Index { get; set; }

		/// <inheritdoc/>
		public SinglyLinkedListNode<TIndex, TElement>? Next { get; set; }

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Equals(Element, element);

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => predicate?.Invoke(Element) ?? Element is null;

		/// <inheritdoc/>
		public SinglyLinkedListNode<TIndex, TElement> Postpend(TIndex index, TElement element) {
			Next = new SinglyLinkedListNode<TIndex, TElement>(index, element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		public SinglyLinkedListNode<TIndex, TElement> Prepend(TIndex index, TElement element) => new SinglyLinkedListNode<TIndex, TElement>(index, element, next: this);

		/// <inheritdoc/>
		public void Replace(TElement search, TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		public override String ToString() => $"{Index}:{Element?.ToString() ?? "null"}";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
