using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Nodes;
using Collectathon.Enumerators;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public sealed class SinglyLinkedList<TIndex, TElement> :
		IClear,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement>,
		ISequence<(TIndex Index, TElement Element), StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>>> {
		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected SinglyLinkedListNode<TIndex, TElement> Head;

		/// <summary>
		/// The tail node of the list; the second element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected SinglyLinkedListNode<TIndex, TElement> Tail;

		/// <summary>
		/// initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/> witht he given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		[LinksNewNode(1)]
		public SinglyLinkedList([DisallowNull] params (TIndex Index, TElement? Element)[] entries) {
			foreach ((TIndex Index, TElement? Element) in entries) {
				Insert(Index, Element);
			}
		}

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				SinglyLinkedListNode<TIndex, TElement>? N = Head;
				for (nint i = 0; N is not null; i++) {
					if (Equals(N.Index, index)) {
						return N.Element;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
			set {
				SinglyLinkedListNode<TIndex, TElement>? N = Head;
				for (nint i = 0; N is not null; i++) {
					if (Equals(N.Index, index)) {
						N.Element = value;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Converts the <paramref name="entries"/> to a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="entries">The entries to convert to a list.</param>
		[return: MaybeNull, NotNullIfNotNull("elements")]

		public static implicit operator SinglyLinkedList<TIndex, TElement>([AllowNull] (TIndex Index, TElement Element)[] entries) => entries is not null ? new(entries) : null;

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(Head);
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>> GetEnumerator() => new StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>>(Head, Count);

		/// <inheritdoc/>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		System.Collections.Generic.IEnumerator<(TIndex Index, TElement Element)> System.Collections.Generic.IEnumerable<(TIndex Index, TElement Element)>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(index, element);
				Tail = Tail.Next;
			} else {
				Head = new SinglyLinkedListNode<TIndex, TElement>(index, element, next: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);
	}
}
