using System;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Implements a doubly-linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <remarks>
	/// This is a type of linked list where each node of the list has two links, one to the next node, one to the previous node, in the list. This is the most well rounded purely linked list, offering a good trade off between memory usage, performance, and capabilities. As a result, it doesn't excel at anything. Use this as a good starting point, or if you don't know what else to use. Then, look at used features and benchmarks to determine whether swapping out with another list would be beneficial. You can consider this Good Ol' Reliable.
	/// </remarks>
	/// <seealso cref="DoublyLinkedList{TIndex, TElement}"/>
	public sealed partial class DoublyLinkedList<TElement> : LinkedList<TElement, DoublyLinkedList<TElement>, DoublyLinkedList<TElement>.Node> {
		/// <summary>
		/// Initializes a new <see cref="DoublyLinkedList{TElement}"/>.
		/// </summary>
		public DoublyLinkedList() : this(Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DoublyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="filter">The filter type to use.</param>
		public DoublyLinkedList(Filter filter) : base(filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private DoublyLinkedList(Filter<TElement> filterer) : base(filterer) { }

		/// <inheritdoc/>
		protected override void Add(TElement element) {
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			Tail = new Node(element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Count++;
		}

		/// <inheritdoc/>
		protected override DoublyLinkedList<TElement> Clone() {
			DoublyLinkedList<TElement> list = new DoublyLinkedList<TElement>(Filterer);
			Node N = Head;
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
					P!.Next = new Node(element, P!.Next, P); // P won't actually be null at any point, because in the case it is, we've already handled that with a special head push.
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
			Head = new Node(element, next: Head, previous: null);
			if (Tail is null) {
				Tail = Head;
			} else {
				Head.Next.Previous = Head;
			}
			Count++;
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
					N.Next = null;
					N.Previous = null;
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
					N.Next = null;
					N.Previous = null;
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
	}
}
