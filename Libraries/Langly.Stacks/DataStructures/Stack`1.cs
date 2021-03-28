using System;
using System.Diagnostics.CodeAnalysis;
using Xunit.Abstractions;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a stack, a simple FIFO collection.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the stack.</typeparam>
	public sealed partial class Stack<TElement> : DataStructure<TElement, Stack<TElement>, Stack<TElement>.Enumerator>,
		IPeek<TElement, Stack<TElement>>,
		IWrite<TElement, Stack<TElement>> {
		/// <summary>
		/// The head node of the stack; the top.
		/// </summary>
		[AllowNull]
		private Node Head;

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/>.
		/// </summary>
		public Stack() : base(DataStructures.Filter.None) { }

		/// <inheritdoc/>
		public Boolean Readable => Count > 0;

		/// <inheritdoc/>
		public Boolean Writable => true;

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IAdd<TElement, Stack<TElement>>.Add([AllowNull] TElement element) {
			Head = new Node(element, next: Head);
			Count++;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IPeek<TElement, Stack<TElement>>.Peek([MaybeNull] out TElement element) {
			element = Head.Element;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		Stack<TElement> IRead<TElement, Stack<TElement>>.Read([MaybeNull] out TElement element) {
			if (Readable) {
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

		/// <inheritdoc/>
		protected override void Deserialize(IXunitSerializationInfo info) {
			foreach (TElement item in info.GetValue<TElement[]>("Array")) {
				((IAdd<TElement, Stack<TElement>>)this).Add(item);
			}
		}
	}
}
