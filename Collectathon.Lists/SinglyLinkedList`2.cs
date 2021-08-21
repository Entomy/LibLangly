using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;
using Collectathon.Nodes;
using Collectathon.Enumerators;

namespace Collectathon {
	/// <summary>
	/// Represents an associative singly-linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public sealed class SinglyLinkedList<TIndex, TElement> :
		IClear,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement>,
		ISequence<(TIndex Index, TElement Element), StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>>>
		where TIndex : notnull {
		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		private SinglyLinkedListNode<TIndex, TElement>? Head;

		/// <summary>
		/// The tail node of the list; the second element.
		/// </summary>
		private SinglyLinkedListNode<TIndex, TElement>? Tail;

		/// <summary>
		/// initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/> witht he given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		[LinksNewNode(1)]
		public SinglyLinkedList(params (TIndex Index, TElement Element)[] entries) {
			foreach ((TIndex Index, TElement Element) in entries) {
				Insert(Index, Element);
			}
		}

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		public TElement this[TIndex index] {
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

		/// <inheritdoc/>
		public void Clear() {
			if (Head is not null) {
				Collection.Clear(ref Head, ref Tail);
				Head = null;
				Tail = null;
				Count = 0;
			}
		}

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case SinglyLinkedList<TIndex, TElement> list:
				return Equals(list);
			case (TIndex, TElement)[] array:
				return Equals(array);
			case ArraySegment<(TIndex, TElement)> segment:
				return Equals(segment);
			case Memory<(TIndex, TElement)> memory:
				return Equals(memory);
			case ReadOnlyMemory<(TIndex, TElement)> memory:
				return Equals(memory);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(SinglyLinkedList<TIndex, TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(params (TIndex Index, TElement Element)[]? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ArraySegment<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Memory<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlyMemory<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Span<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlySpan<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>> GetEnumerator() => new StandardListEnumerator<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>>(Head, Count);

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Insert(TIndex index, TElement element) {
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
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);
	}
}
