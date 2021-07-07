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
		INext<SinglyLinkedListNode<TIndex, TElement>>,
		IReplace<TElement>,
		IUnlink {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedListNode{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		public SinglyLinkedListNode([DisallowNull] TIndex index, [AllowNull] TElement element, [AllowNull] SinglyLinkedListNode<TIndex, TElement> next) {
			Index = index;
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		public Int32 Count => 1;

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement Element { get; set; }

		/// <inheritdoc/>
		[DisallowNull, NotNull]
		public TIndex Index { get; set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public SinglyLinkedListNode<TIndex, TElement> Next { get; set; }

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Equals(Element, element);

		public Boolean Contains([AllowNull] Predicate<TElement> predicate) => predicate?.Invoke(Element) ?? Element is null;

		/// <inheritdoc/>
		[return: NotNull]
		public SinglyLinkedListNode<TIndex, TElement> Postpend([DisallowNull] TIndex index, [AllowNull] TElement element) {
			Next = new SinglyLinkedListNode<TIndex, TElement>(index, element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public SinglyLinkedListNode<TIndex, TElement> Prepend([DisallowNull] TIndex index, [AllowNull] TElement element) => new SinglyLinkedListNode<TIndex, TElement>(index, element, next: this);

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => $"{Index}{Element?.ToString() ?? ""}";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
