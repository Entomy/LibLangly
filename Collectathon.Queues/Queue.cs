using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Queues {
	public sealed partial class Queue<TElement> :
		IClear,
		IContains<TElement>,
		IPeek<TElement>,
		ISequence<TElement, Queue<TElement>.Enumerator>,
		IWrite<TElement> {
		/// <summary>
		/// The head of the queue; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Head;

		/// <summary>
		/// The tail of the queue; the last element.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Queue{TElement}"/>.
		/// </summary>
		public Queue() { }

		/// <summary>
		/// Initializes a new <see cref="Queue{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the queue.</param>
		public Queue([DisallowNull] params TElement[] elements) {
			foreach (TElement element in elements) {
				Write(element);
			}
		}

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public Boolean Writable => true;

		/// <inheritdoc/>
		public void Add([AllowNull] TElement element) => Enqueue(element);

		/// <inheritdoc/>
		public void Clear() {
			Collection.Clear(Head);
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Head, element);

		/// <summary>
		/// Dequeues the first element in this <see cref="Queue{TElement}"/>.
		/// </summary>
		/// <returns>The first element.</returns>
		[return: MaybeNull]
		public TElement Dequeue() {
			Read(out TElement? element);
			return element;
		}

		/// <summary>
		/// Enqueues the <paramref name="element"/> into this <see cref="Queue{TElement}"/>.
		/// </summary>
		/// <param name="element">The element to enqueue.</param>
		public void Enqueue([AllowNull] TElement element) {
			if (Count > 0) {
				Tail!.Next = new Node(element);
				Tail = Tail.Next;
			} else {
				Head = new Node(element);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		public void Peek([MaybeNull] out TElement element) => element = Head.Element;

		/// <summary>
		/// Peeks at the first element in this <see cref="Queue{TElement}"/>.
		/// </summary>
		/// <returns>The first element.</returns>
		[return: MaybeNull]
		public TElement Peek() => Head.Element;

		/// <inheritdoc/>
		public void Read([MaybeNull] out TElement element) {
			element = Head.Element;
			Node N = Head;
			Head = Head.Next;
			N.Next = null;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Head, Count, amount);

		/// <inheritdoc/>
		public void Write([AllowNull] TElement element) => Enqueue(element);
	}
}
