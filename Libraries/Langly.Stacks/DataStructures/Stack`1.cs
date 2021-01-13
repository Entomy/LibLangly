using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a stack, a simple FIFO collection.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the stack.</typeparam>
	public sealed partial class Stack<TElement> : DataStructure<TElement, Stack<TElement>, Stack<TElement>.Enumerator>,
		IPeek<TElement, Stack<TElement>>,
		IPop<TElement, Stack<TElement>>,
		IPush<TElement, Stack<TElement>> {
		/// <summary>
		/// The head node of the stack; the top.
		/// </summary>
		[AllowNull]
		private Node Head;

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/>.
		/// </summary>
		public Stack() { }

		/// <inheritdoc/>
		[return: NotNull]
		Stack<TElement> IPeek<TElement, Stack<TElement>>.Peek([MaybeNull] out TElement element) {
			element = Head.Element;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Stack<TElement> IPop<TElement, Stack<TElement>>.Pop([MaybeNull] out TElement element) {
			element = Head.Element;
			Node old = Head;
			Head = Head.Next;
			old.Next = null;
			Count--;
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Stack<TElement> IPush<TElement, Stack<TElement>>.Push([AllowNull] TElement element) {
			Head = new Node(element, next: Head);
			Count++;
			return this;
		}
	}
}
