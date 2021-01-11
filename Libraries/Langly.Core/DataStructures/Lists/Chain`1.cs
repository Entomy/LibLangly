using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Represents a Chain, a type of highly sophisticated List.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the chain.</typeparam>
	/// <remarks>
	/// A chain is a hybrid list, employing various optimizations from partial-unrolling to skip-linkage, to reference slicing.
	/// </remarks>
	public sealed partial class Chain<TElement> : DataStructure<TElement, Chain<TElement>, Chain<TElement>.Enumerator>,
		IAdd<TElement, Chain<TElement>>,
		IConcat<TElement, Chain<TElement>>,
		IIndex<TElement>,
		IInsert<TElement, Chain<TElement>>,
		IReplace<TElement, Chain<TElement>> {
		/// <summary>
		/// The head node of the chain.
		/// </summary>
		[AllowNull]
		private Node Head;

		/// <summary>
		/// The tail node of the chain.
		/// </summary>
		[AllowNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Chain{TElement}"/>.
		/// </summary>
		public Chain() {
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Intializes a new <see cref="Chain{TElement}"/> with the initial <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The initial element.</param>
		internal Chain(TElement element) {
			Head = new ElementNode(element, previous: null, next: null);
			Tail = Head;
			Count = 1;
		}

		/// <summary>
		/// Initializes a new <see cref="Chain{TElement}"/> with the initial <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The initial element.</param>
		internal Chain(Memory<TElement> element) {
			Head = new MemoryNode(element, previous: null, next: null);
			Tail = Head;
			Count = 1;
		}

		/// <inheritdoc/>
		public TElement this[nint index] {
			get {
				Node N = Head;
				nint i = 0;
				// Seeks to the node the element is in, and calculate the index offset (i)
				while (N is not null && index >= i + N.Count) {
					i += N.Count;
					N = N.Next;
				}
				// If N is null, the index is out of bounds
				if (N is null) {
					throw new IndexOutOfRangeException();
				}
				// Return the element
				return N[index - i];
			}
			set => throw new NotImplementedException();
		}

		/// <inheritdoc/>
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add([AllowNull] TElement element) => ((IPostpend<TElement, Chain<TElement>>)this).Postpend(element);

		/// <inheritdoc/>
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add(ReadOnlyMemory<TElement> elements) => ((IPostpend<TElement, Chain<TElement>>)this).Postpend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<nint, TElement, Chain<TElement>>.Insert(nint index, [AllowNull] TElement element) {
			if (index == 0) {
				return ((IPrepend<TElement, Chain<TElement>>)this).Prepend(element);
			} else if (index == Count) {
				return ((IPostpend<TElement, Chain<TElement>>)this).Postpend(element);
			} else {
				Node N = Head;
				nint i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (index <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (index > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && index > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N.Previous;
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, element);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count++;
				// We're done
				return this;
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<nint, TElement, Chain<TElement>>.Insert(nint index, ReadOnlyMemory<TElement> elements) {
			if (index == 0) {
				return ((IPrepend<TElement, Chain<TElement>>)this).Prepend(elements);
			} else if (index == Count) {
				return ((IPostpend<TElement, Chain<TElement>>)this).Postpend(elements);
			} else {
				Node N = Head;
				nint i = 0;
				// Will the element be inserted into the only node in the chain?
				if (ReferenceEquals(Head, Tail)) {
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Replace this node with the chain section
					Head = head;
					Tail = tail;
				} else
				// Will the element be inserted into the head node?
				if (index <= Head.Count) {
					// Get the surrounding nodes
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					tail.Next = next;
					// Replace this node with the chain section
					Head = head;
					next.Previous = tail;
				} else
				// Will the element be inserted into the tail node?
				if (index > Count - Tail.Count) {
					// Set to the tail node
					N = Tail;
					i = Count - Tail.Count;
					// Get the surrounding nodes
					Node prev = N.Previous;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					head.Previous = prev;
					// Replace this node with the chain section
					Tail = tail;
					prev.Next = head;
				} else {
					// Seeks to the node the element will be inserted in, and calculate the index offset (i)
					while (N is not null && index > i + N.Count) {
						i += N.Count;
						N = N.Next;
					}
					// Get the surrounding nodes
					Node prev = N.Previous;
					Node next = N.Next;
					// Insert the element into the node, getting back a chain section
					(Node head, Node tail) = N.Insert(index - i, elements);
					// Link the chain section into the chain
					head.Previous = prev;
					tail.Next = next;
					// Replace this node with the chain section
					prev.Next = head;
					next.Previous = tail;
				}
				// Increment the counter
				Count++;
				// We're done
				return this;
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend([AllowNull] TElement element) {
			if (element is not null) {
				Tail = new ElementNode(element, previous: Tail, next: null);
				if (Head is null) {
					Head = Tail;
				} else {
					Tail.Previous.Next = Tail;
				}
				Count++;
			}
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend(ReadOnlyMemory<TElement> elements) {
			Tail = new MemoryNode(elements, previous: Tail, next: null);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Count += elements.Length;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend(ReadOnlySpan<TElement> elements) {
			Memory<TElement> buffer = new TElement[elements.Length];
			elements.CopyTo(buffer.Span);
			return ((IPostpend<TElement, Chain<TElement>>)this).Postpend(buffer);
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend([AllowNull] TElement element) {
			if (element is not null) {
				Head = new ElementNode(element, previous: null, next: Head);
				if (Tail is null) {
					Tail = Head;
				} else {
					Head.Next.Previous = Head;
				}
				Count++;
			}
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend(ReadOnlyMemory<TElement> elements) {
			Head = new MemoryNode(elements, previous: null, next: Head);
			if (Tail is null) {
				Tail = Head;
			} else {
				Head.Next.Previous = Head;
			}
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend(ReadOnlySpan<TElement> elements) {
			Memory<TElement> buffer = new TElement[elements.Length];
			elements.CopyTo(buffer.Span);
			return ((IPrepend<TElement, Chain<TElement>>)this).Prepend(buffer);
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IReplace<TElement, TElement, Chain<TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			// If the head node is null
			if (Head is null) {
				// The chain is empty and there's nothing to do
				return this;
			}
			Node N = Head;
			Node head = Head;
			Node tail = Tail;
			Node prev = null;
			// Iterate through the entire chain, doing any necessary replacements. Unchanged nodes are reused for efficiency.
			while (N is not null) {
				(head, tail) = N.Replace(search, replace);
				// If the head hasn't been relinked yet. This works because prev is only null on the first iteration. After each iteration prev is always the end of the chain.
				if (prev is null) {
					// Relink it
					Head = head;
					// This entire chain is now the chain section that was just created
				} else {
					// Attach the chain section to the new chain
					prev.Next = head;
					head.Previous = prev;
				}
				// Move to the next node
				prev = tail;
				N = N.Next;
			}
			// Finish linking the last node
			Tail = tail;
			// All done
			return this;
		}
	}
}
