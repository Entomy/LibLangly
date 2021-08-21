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
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public sealed class SinglyLinkedList<TElement> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		IEquatable<SinglyLinkedList<TElement>>,
		IIndex<Index, TElement>,
		IInsert<Index, TElement>,
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
		public TElement this[Index index] {
			get {
				Int32 idx = index.GetOffset(Count);
				if (idx < Count) {
					SinglyLinkedListNode<TElement>? N = Head;
					for (Int32 i = 0; N is not null; i++) {
						if (i == idx) {
							return N.Element;
						}
						N = N.Next;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				Int32 idx = index.GetOffset(Count);
				if (idx < Count) {
					SinglyLinkedListNode<TElement>? N = Head;
					for (Int32 i = 0; N is not null; i++) {
						if (i == idx) {
							N.Element = value;
						}
						N = N.Next;
					}
				}
				throw new IndexOutOfRangeException();
			}
		}

		/// <inheritdoc/>
		[MaybeLinksNewNode(1)]
		public void Add(TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(ref Head, ref Tail);
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Head is not null ? Collection.Contains(Head, element) : false;

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => Head is not null ? Collection.Contains(Head, predicate) : false;

		/// <inheritdoc/>
		[UnlinksNode]
		public TElement Dequeue() {
			Collection.Dequeue(ref Head, ref Tail, out TElement element);
			Count--;
			return element;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public void Enqueue(TElement element) => Postpend(element);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case SinglyLinkedList<TElement> list:
				return Equals(list);
			case TElement[] array:
				return Equals(array);
			case ArraySegment<TElement> segment:
				return Equals(segment);
			case Memory<TElement> memory:
				return Equals(memory);
			case ReadOnlyMemory<TElement> memory:
				return Equals(memory);
			case System.Collections.Generic.IEnumerable<TElement> enumerable:
				return Equals(enumerable);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(SinglyLinkedList<TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(params TElement[]? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ArraySegment<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Memory<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlyMemory<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Span<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlySpan<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(System.Collections.Generic.IEnumerable<TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>> GetEnumerator() => new StandardListEnumerator<TElement, SinglyLinkedListNode<TElement>>(Head, Count);

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public unsafe void Insert(Index index, TElement element) {
			Collection.Insert(ref Head, ref Tail, Count, index, element, &NewNode);
			Count++;
		}

		/// <inheritdoc/>
		public TElement Peek() {
			if (Head is not null) {
				return Head.Element;
			} else {
				throw new InvalidOperationException("Can't pop an element off an empty collection.");
			}
		}

		/// <inheritdoc/>
		public void Peek(out TElement element) {
			if (Head is not null) {
				element = Head.Element;
			} else {
				throw new InvalidOperationException("Can't pop an element off an empty collection.");
			}
		}

		/// <inheritdoc/>
		[UnlinksNode]
		public TElement Pop() {
			Collection.Pop(ref Head, ref Tail, out TElement element);
			Count--;
			return element;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public unsafe void Postpend(TElement element) {
			Collection.Postpend(ref Head, ref Tail, element, &NewNode);
			Count++;
		}

		/// <inheritdoc/>
		[LinksNewNode(1)]
		public unsafe void Prepend(TElement element) {
			Collection.Prepend(ref Head, ref Tail, element, &NewNode);
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

		/// <summary>
		/// Creates a new node with no linkage.
		/// </summary>
		/// <param name="element">The element to put into the node.</param>
		/// <returns>A new, unlinked, node containing the <paramref name="element"/>.</returns>
		private static SinglyLinkedListNode<TElement> NewNode(TElement element) => new SinglyLinkedListNode<TElement>(element, next: null);
	}
}
