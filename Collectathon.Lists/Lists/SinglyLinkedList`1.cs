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
		[AllowNull, MaybeNull]
		private SinglyLinkedListNode<TElement> Head;

		/// <summary>
		/// The tail node of the list; the last element.
		/// </summary>
		[AllowNull, MaybeNull]
		private SinglyLinkedListNode<TElement> Tail;

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public SinglyLinkedList() { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the list.</param>
		[MaybeLinksNewNode(1)]
		public SinglyLinkedList([DisallowNull] params TElement?[] elements) {
			foreach (TElement? element in elements) {
				Add(element);
			}
		}

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
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

		/// <summary>
		/// Converts the <paramref name="elements"/> to a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements to convert to a list.</param>
		[return: MaybeNull, NotNullIfNotNull("elements")]

		public static implicit operator SinglyLinkedList<TElement?>([AllowNull] TElement?[] elements) => elements is not null ? new(elements) : null;

		/// <inheritdoc/>
		[MaybeLinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Add([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(Head);
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Head, element);

		/// <inheritdoc/>
		[UnlinksNode]
		[return: MaybeNull]
		public TElement Dequeue() {
			SinglyLinkedListNode<TElement> oldHead = Head;
			Head = Head.Next;
			oldHead.Unlink();
			return oldHead.Element;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Enqueue([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case SinglyLinkedList<TElement?> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] SinglyLinkedList<TElement?> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] System.Collections.Generic.IEnumerable<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>> GetEnumerator() => new StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>>(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		[LinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Insert(Int32 index, [AllowNull] TElement element) {
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
		[return: MaybeNull]
		public TElement Peek() => Head.Element;

		/// <inheritdoc/>
		public void Peek([MaybeNull] out TElement element) => element = Head.Element;

		/// <inheritdoc/>
		[UnlinksNode]
		[return: MaybeNull]
		public TElement Pop() {
			SinglyLinkedListNode<TElement> oldHead = Head;
			Head = Head.Next;
			oldHead.Unlink();
			return oldHead.Element;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		[MemberNotNull(nameof(Head), nameof(Tail))]
		public void Postpend([AllowNull] TElement element) {
			if (Count > 0) {
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
		public void Prepend([AllowNull] TElement element) {
			if (Count > 0) {
				Head = Head!.Prepend(element);
			} else {
				Head = new SinglyLinkedListNode<TElement>(element, next: null);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Push([AllowNull] TElement element) => Prepend(element);

		/// <inheritdoc/>
		[UnlinksNode]
		public void Remove([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[UnlinksNode]
		public void RemoveFirst([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[UnlinksNode]
		public void RemoveLast([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Collection.Replace(Head, search, replace);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);
	}
}
