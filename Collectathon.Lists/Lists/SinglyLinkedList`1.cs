using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Nodes;
using Collectathon.Enumerators;

#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant. Microsoft's own MemberNotNullAttribute violates CLS Compliance.

namespace Collectathon.Lists {
	/// <summary>
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public sealed class SinglyLinkedList<TElement> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		IEquatable<SinglyLinkedList<TElement>>,
		IIndex<Int32, TElement>,
		IInsert<Int32, TElement>,
		IPostpend<TElement>,
		IPrepend<TElement>,
		IQueue<TElement>,
		IRemove<TElement>,
		IReplace<TElement>,
		ISequence<TElement, StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>>>,
		IStack<TElement> {
		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		private SinglyLinkedListNode<TElement>? Head;

		/// <summary>
		/// The tail node of the list; the last element.
		/// </summary>
		private SinglyLinkedListNode<TElement>? Tail;

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the list.</param>
		[MaybeLinksNewNode(1)]
		public SinglyLinkedList(params TElement[]? elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					Add(element);
				}
			}
		}

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		public TElement this[Int32 index] {
			get {
				SinglyLinkedListNode<TElement>? N = Head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						return N.Element;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
			set {
				SinglyLinkedListNode<TElement>? N = Head;
				for (Int32 i = 0; N is not null; i++) {
					if (i == index) {
						N.Element = value;
					}
					N = N.Next;
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add(TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Clear() {
			if (Head is not null) {
				Collection.Clear(Head);
				Head = null;
				Tail = null;
				Count = 0;
			}
		}

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Head is not null ? Collection.Contains(Head, element) : false;

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => Head is not null ? Collection.Contains(Head, predicate) : false;

		/// <inheritdoc/>
		[UnlinksNode]
		public TElement Dequeue() {
			if (Head is not null) {
				SinglyLinkedListNode<TElement> oldHead = Head;
				Head = Head.Next;
				oldHead.Unlink();
				return oldHead.Element;
			} else {
				throw new InvalidOperationException("Can't dequeue an element from an empty collection.");
			}
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Enqueue(TElement element) => Postpend(element);

		/// <inheritdoc/>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case SinglyLinkedList<TElement> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(SinglyLinkedList<TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(System.Collections.Generic.IEnumerable<TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>> GetEnumerator() => new StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>>(Head, Count);

		/// <inheritdoc/>
		[LinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(Int32 index, TElement element) {
			if (index == 0) {
				Prepend(element);
			} else if (index == Count) {
				Postpend(element);
			} else if (Head is null || Tail is null) {
				Add(element);
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
		public TElement Peek() => Head.Element;

		/// <inheritdoc/>
		public void Peek(out TElement element) => element = Head.Element;

		/// <inheritdoc/>
		[UnlinksNode]
		public TElement Pop() {
			if (Head is not null) {
				SinglyLinkedListNode<TElement> oldHead = Head;
				Head = Head.Next;
				oldHead.Unlink();
				return oldHead.Element;
			} else {
				throw new InvalidOperationException("Can't pop an element off an empty collection.");
			}
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend(TElement element) {
			if (Head is not null && Tail is not null) {
				Tail!.Next = Tail!.Postpend(element);
				Tail = Tail.Next;
			} else {
				Head = new SinglyLinkedListNode<TElement>(element, next: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Prepend(TElement element) {
			if (Head is not null && Tail is not null) {
				Head = Head!.Prepend(element);
			} else {
				Head = new SinglyLinkedListNode<TElement>(element, next: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Push(TElement element) => Prepend(element);

		/// <inheritdoc/>
		[UnlinksNode]
		public void Remove(TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[UnlinksNode]
		public void RemoveFirst(TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[UnlinksNode]
		public void RemoveLast(TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Replace(TElement search, TElement replace) {
			if (Head is not null) {
				Collection.Replace(Head, search, replace);
			}
		}

		/// <inheritdoc/>
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);
	}
}
