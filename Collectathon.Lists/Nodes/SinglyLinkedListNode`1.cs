using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

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
		public SinglyLinkedListNode([AllowNull] TElement element, [AllowNull] SinglyLinkedListNode<TElement> next) {
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		public Int32 Count => 1;

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement Element { get; set; }

		/// <summary>
		/// The next node in the list.
		/// </summary>
		[AllowNull, MaybeNull]
		public SinglyLinkedListNode<TElement> Next { get; set; }

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Equals(Element, element);

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] Predicate<TElement> predicate) => predicate?.Invoke(Element) ?? Element is null;

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		[return: NotNull]
		public SinglyLinkedListNode<TElement> Postpend([AllowNull] TElement element) {
			Next = new SinglyLinkedListNode<TElement>(element, next: null);
			return Next;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public SinglyLinkedListNode<TElement> Prepend([AllowNull] TElement element) => new SinglyLinkedListNode<TElement>(element, next: this);

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Element?.ToString() ?? "";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
