using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;
using Collectathon.Nodes;

namespace Collectathon.Stacks {
	/// <summary>
	/// Represents a stack, a type of FIFO data structure.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the stack.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed partial class Stack<TElement> :
		IClear,
		IContains<TElement>,
		IPeek<TElement>,
		ISequence<TElement, StandardListEnumerator<TElement, StackNode<TElement>>>,
		IWrite<TElement> {
		/// <summary>
		/// The head of the stack; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		private StackNode<TElement> Head;

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/>.
		/// </summary>
		public Stack() { }

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the stack.</param>
		public Stack([DisallowNull] params TElement[] elements) {
			foreach (TElement element in elements) {
				Head = new StackNode<TElement>(element, next: Head);
			}
			Count = elements.Length;
		}

		/// <inheritdoc/>
		public nint Count { get; private set; }

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public Boolean Writable => true;

		/// <inheritdoc/>
		public void Add([AllowNull] TElement element) => Push(element);

		/// <inheritdoc/>
		public void Clear() {
			if (Head is not null) Collection.Clear(Head);
			Head = null;
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Head, element);

		/// <inheritdoc/>
		public StandardListEnumerator<TElement, StackNode<TElement>> GetEnumerator() => new StandardListEnumerator<TElement, StackNode<TElement>>(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		public void Peek([AllowNull, MaybeNull] out TElement element) => element = Peek();

		/// <summary>
		/// Peeks at the top element of this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[return: MaybeNull]
		public TElement Peek() {
			if (Head is not null) {
				return Head.Element;
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// Pops the top element off this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[return: MaybeNull]
		public TElement Pop() {
			Read(out TElement? element);
			return element;
		}

		/// <summary>
		/// Pushes the <paramref name="element"/> onto this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <param name="element">The element to push.</param>
		public void Push([AllowNull] TElement element) {
			Head = new StackNode<TElement>(element, next: Head);
			Count++;
		}

		/// <inheritdoc/>
		public void Read([AllowNull, MaybeNull] out TElement element) {
			if (Head is not null) {
				element = Head.Element;
				StackNode<TElement> old = Head;
				Head = Head.Next;
				old.Unlink();
				Count--;
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Head, Count, amount);

		/// <inheritdoc/>
		public void Write([AllowNull] TElement element) => Push(element);
	}
}
