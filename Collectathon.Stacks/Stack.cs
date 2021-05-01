using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Stacks {
	/// <summary>
	/// Represents a stack, a type of FIFO data structure.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the stack.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed partial class Stack<TElement> :
		IClear<Stack<TElement>>,
		IPeek<TElement, Stack<TElement>>,
		IRead<TElement, Stack<TElement>>,
		ISequence<TElement, Stack<TElement>.Enumerator>,
		IWrite<TElement, Stack<TElement>> {
		/// <summary>
		/// The head of the stack; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		private Node Head;

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/>.
		/// </summary>
		public Stack() { }

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the stack.</param>
		public Stack([DisallowNull] params TElement[] elements) {
			foreach	(TElement element in elements) {
				Head = new Node(element, next: Head);
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
		public Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => ToString(Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => ISequence<TElement, Enumerator>.ToString(this, amount);

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IAdd<TElement, Stack<TElement>>.Add([AllowNull] TElement element) {
			Head = new Node(element, next: Head);
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Stack<TElement> IClear<Stack<TElement>>.Clear() {
			Node P = null;
			Node N = Head;
			while (N is not null) {
				P = N;
				N = N.Next;
				P.Next = null;
			}
			Count = 0;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IPeek<TElement, Stack<TElement>>.Peek([AllowNull, MaybeNull] out TElement element) {
			if (Head is not null) {
				element = Head.Element;
				return this;
			} else {
				element = default;
				return null;
			}
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IRead<TElement, Stack<TElement>>.Read([AllowNull, MaybeNull] out TElement element) {
			if (Head is not null) {
				element = Head.Element;
				Node old = Head;
				Head = Head.Next;
				old.Next = null;
				Count--;
				return this;
			} else {
				element = default;
				return null;
			}
		}
	}
}
