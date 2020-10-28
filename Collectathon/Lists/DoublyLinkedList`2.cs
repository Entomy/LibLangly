using System;
using Collectathon.Filters;

namespace Collectathon.Lists {
	/// <summary>
	/// Implements an associative doubly-linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <remarks>
	/// This is a type of associative linked list where each node of the list has two links, one to the next node, one to the previous node, in the list. This is the most well rounded purely linked list, offering a good trade off between memory usage, performance, and capabilities. As a result, it doesn't excel at anything. Use this as a good starting point, or if you don't know what else to use. Then, look at used features and benchmarks to determine whether swapping out with another list would be beneficial. You can consider this Good Ol' Reliable.
	/// </remarks>
	/// <seealso cref="DoublyLinkedList{TElement}"/>
	[Serializable]
	public sealed partial class DoublyLinkedList<TIndex, TElement> : LinkedList<TIndex, TElement, DoublyLinkedList<TIndex, TElement>, DoublyLinkedList<TIndex, TElement>.Node> where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// Initializes a new <see cref="DoublyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public DoublyLinkedList() : this(Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DoublyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="filter">The filter type to use.</param>
		public DoublyLinkedList(Filter filter) : base(filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private DoublyLinkedList(Filter<TElement> filterer) : base(filterer) { }

		/// <inheritdoc/>
		protected override void Add(TIndex index, TElement element) {
			Tail = new Node(index, element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Count++;
		}

		/// <inheritdoc/>
		protected override DoublyLinkedList<TIndex, TElement> Clone() {
			DoublyLinkedList<TIndex, TElement> list = new DoublyLinkedList<TIndex, TElement>(Filterer);
			Node N = Head;
			while (N is not null) {
				list.Add(N.Index, N.Element);
			}
			return list;
		}

		/// <inheritdoc/>
		protected override void Remove(TElement element) {
			Node P = null;
			Node N = Head;
			if (N == element) {
				//We just need to detach the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (N == element) {
					// Detatch the node from the list.
					P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
					if (N is not null && N.Next is not null) {
						N.Next.Previous = N.Previous;
					}
					// Detatch the remainder of the list from the node.
					N.Clear();
					// Set to the new next
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
			if (match is null) {
				return;
			}
			Node P = null;
			Node N = Head;
			if (match(N.Element)) {
				//We just need to detach the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (match(N.Element)) {
					// Detatch the node from the list.
					P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
					if (N is not null && N.Next is not null) {
						N.Next.Previous = N.Previous;
					}
					// Detatch the remainder of the list from the node.
					N.Clear();
					// Set to the new next
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
		protected override void RemoveAt(TIndex index) {
			Node P = null;
			Node N = Head;
			if (index.Equals(N.Index)) {
				//We just need to detach the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (index.Equals(N.Index)) {
					// Detatch the node from the list.
					P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
					if (N is not null && N.Next is not null) {
						N.Next.Previous = N.Previous;
					}
					// Detatch the remainder of the list from the node.
					N.Clear();
					// Set to the new next
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

		private TElement Pop() {
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
	}
}
