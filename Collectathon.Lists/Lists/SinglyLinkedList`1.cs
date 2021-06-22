using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	public sealed class SinglyLinkedList<TElement> : StandardList<TElement, SinglyLinkedListNode<TElement>, SinglyLinkedList<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the list.</param>
		public SinglyLinkedList([DisallowNull] params TElement[] elements) : base(elements) { }

		/// <summary>
		/// Converts the <paramref name="elements"/> to a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements to convert to a list.</param>
		[return: MaybeNull, NotNullIfNotNull("elements")]

		public static implicit operator SinglyLinkedList<TElement>([AllowNull] TElement[] elements) => elements is not null ? new(elements) : null;

		/// <inheritdoc/>
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public override void Insert(Int32 index, [AllowNull] TElement element) {
			if (index == 0) {
				Prepend(element);
			} else if (index == Count) {
				Postpend(element);
			} else if (Count > 0) {
				SinglyLinkedListNode<TElement> P = null!;
				SinglyLinkedListNode<TElement>? N = Head;
				Int32 i = 0;
				while (N is not null) {
					P = N;
					N = N.Next;
					i++;
					if (i == index) break;
				}
				P.Next = new SinglyLinkedListNode<TElement>(element, next: N);
				Count++;
			} else {
				Head = new SinglyLinkedListNode<TElement>(element, next: null);
				Tail = Head;
				Count++;
			}
		}

		/// <inheritdoc/>
		public override void Remove([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public override void RemoveFirst([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public override void RemoveLast([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		protected override SinglyLinkedListNode<TElement> NewUnlinkedNode([AllowNull] TElement element) => new SinglyLinkedListNode<TElement>(element, next: null);
	}
}
