using System;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Implements an associative singly-linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <remarks>
	/// This is a type of associative linked list where each node of the list has a single link to the next node in the list. While this is the most compact form of linked list, it does mean only forward enumeration is feasible. Use this if you know you won't need reverse enumeration and need to save on memory.
	/// </remarks>
	/// <seealso cref="SinglyLinkedList{TElement}"/>
	[Serializable]
	public sealed partial class SinglyLinkedList<TIndex, TElement> : LinkedList<TIndex, TElement, SinglyLinkedList<TIndex, TElement>, SinglyLinkedList<TIndex, TElement>.Node> where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public SinglyLinkedList() : base(Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="filter">The filter type to use.</param>
		public SinglyLinkedList(Filter filter) : base(filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private SinglyLinkedList(Filter<TElement> filterer) : base(filterer) { }

		/// <inheritdoc/>
		protected override void Add(TIndex index, TElement element) {
			if (Tail is null) {
				Tail = new Node(index, element, null);
				if (Head is null) {
					Head = Tail;
				}
			} else {
				Tail.Next = new Node(index, element, null);
				Tail = Tail.Next;
			}
			Count++;
		}

		/// <inheritdoc/>
		protected override SinglyLinkedList<TIndex, TElement> Clone() {
			SinglyLinkedList<TIndex, TElement> list = new SinglyLinkedList<TIndex, TElement>(Filterer);
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

		/// <inheritdoc/>
		protected override void RemoveAt(TIndex index) {
			Node P = null;
			Node N = Head;
			if (index.Equals(N.Index)) {
				// We just need to remove the head, which is far easier.
				_ = Pop();
				// Set to the new head.
				N = Head;
			}
			// Enumerate through the list.
			while (true) {
				if (index.Equals(N.Index)) {
					if (index.Equals(N.Index)) {
						// Detach the node from the list.
						P!.Next = N.Next; // P won't actually be null at any point, because in the case it is, we've already handled that with a special head removal.
										  // Detach the remainder of the list from the node.
						N.Next = null;
						// Set to the new next.
						N = P.Next;
						Count--;
						return;
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
