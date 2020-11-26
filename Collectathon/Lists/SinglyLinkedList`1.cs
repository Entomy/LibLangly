using System;
using Collectathon.Filters;
using Langly;

namespace Collectathon.Lists {
	/// <summary>
	/// Implements a singly-linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <remarks>
	/// This is a type of linked list where each node of the list has a single link to the next node in the list. While this is the most compact form of linked list, it does mean only forward enumeration is feasible. Use this if you know you won't need reverse enumeration and need to save on memory.
	/// </remarks>
	/// <seealso cref="SinglyLinkedList{TIndex, TElement}"/>
	[Serializable]
	public sealed partial class SinglyLinkedList<TElement> : LinkedList<TElement, SinglyLinkedList<TElement>, SinglyLinkedList<TElement>.Node> {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public SinglyLinkedList() : this(Filter.None) { }

		/// <summary>
		/// Intializes a new <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="filter">The filter type to use.</param>
		public SinglyLinkedList(Filter filter) : base(filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private SinglyLinkedList(Filter<TElement> filterer) : base(filterer) { }

		/// <inheritdoc/>
		protected override void Add(TElement element) {
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			if (Tail is null) {
				Tail = new Node(element, null);
				if (Head is null) {
					Head = Tail;
				}
			} else {
				Tail.Next = new Node(element, null);
				Tail = Tail.Next;
			}
			Count++;
		}

		/// <inheritdoc/>
		protected override SinglyLinkedList<TElement> Clone() {
			SinglyLinkedList<TElement> list = new SinglyLinkedList<TElement>(Filterer);
			Node? N = Head;
			while (N is not null) {
				list.Add(N.Element);
			}
			return list;
		}

		/// <inheritdoc/>
		protected override void Insert(nint index, TElement element) {
			if (index == 0) {
				// We're just pushing a value onto the head, which is far easier.
				Push(element);
				return;
			} else if (index == Count) {
				// We're just pushing a value onto the tail, which is far easier.
				this.Enqueue(element);
				return;
			}
			// Check this here because Push and Enqueue/Add are going to check this as well.
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			Node P = null;
			Node N = Head;
			Int32 i = 0;
			while (N is not null) {
				if (i++ == index) {
					P!.Next = new Node(element, P!.Next); // P won't actually be null at any point, because in the case it is, we've already handled that with a special head push.
					Count++;
					return;
				}
				P = N;
				N = N.Next;
			}
		}

		/// <inheritdoc/>
		protected override TElement Pop() {
			if (Head is null) {
				throw new InvalidOperationException("Collection is empty");
			}
			TElement result = Head.Element;
			Node OldHead = Head;
			Head = Head.Next;
			OldHead.Clear();
			Count--;
			return result;
		}

		/// <inheritdoc/>
		protected override void Push(TElement element) {
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			if (Head is null && Tail is null) {
				Head = new Node(element, null);
				Tail = Head;
			} else if (Head is null) {
				Head = new Node(element, Tail);
			} else if (Tail is null) {
				Head = new Node(element, Head);
				Node N = Head;
				while (N is not null) {
					N = N.Next;
				}
				Tail = N;
			} else {
				Head = new Node(element, Head);
			}
			Count++;
		}

		/// <inheritdoc/>
		protected override void Remove(TElement element) {
			Node P = null;
			Node N = Head;
			if (N == element) {
				// We just need to remove the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (N == element) {
					// Detach the node from the list.
					P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
									  // Detach the remainder of the list from the node.
					N.Next = null;
					// Set to the new next.
					N = P.Next;
					Count--;
				}
				// If we've reached the end of the list.
				if (N is null) {
					// Set the tail.
					Tail = P;
					// We're done.
					return;
				}
				// Move to the next position.
				P = N;
				N = N.Next;
			}
		}

		/// <inheritdoc/>
		protected override void Remove(Predicate<TElement> match) {
			Node P = null;
			Node N = Head;
			if (match(N.Element)) {
				// We just need to remove the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (match(N.Element)) {
					// Detach the node from the list.
					P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
									  // Detach the remainder of the list from the node.
					N.Next = null;
					// Set to the new next.
					N = P.Next;
					Count--;
				}
				// If we've reached the end of the list.
				if (N is null) {
					// Set the tail.
					Tail = P;
					// We're done.
					return;
				}
				// Move to the next position.
				P = N;
				N = N.Next;
			}
		}
	}
}
