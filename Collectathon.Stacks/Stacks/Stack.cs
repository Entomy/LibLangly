using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Traits;
using Collectathon.Enumerators;
using Collectathon.Nodes;

namespace Collectathon.Stacks {
	/// <summary>
	/// Represents a stack, a type of FIFO data structure.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the stack.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class Stack<TElement> :
		IClear,
		IContains<TElement>,
		IPeek<TElement>,
		ISequence<TElement, StackEnumerator<TElement>>,
		IWrite<TElement> {
		/// <summary>
		/// The size of each chunk of the stack.
		/// </summary>
		internal const nint ChunkSize = 32;

		/// <summary>
		/// The head of the stack; the first element.
		/// </summary>
		[DisallowNull, NotNull]
		private StackNode<TElement?> Head;

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/>.
		/// </summary>
		public Stack() => Head = new StackNode<TElement?>(Head);

		/// <summary>
		/// Initializes a new <see cref="Stack{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The initial elements of the stack.</param>
		public Stack([AllowNull] params TElement?[] elements) {
			Head = new StackNode<TElement?>(Head);
			if (elements is not null) {
				foreach (TElement? element in elements) {
					Push(element);
				}
			}
		}

		/// <inheritdoc/>
		public nint Count {
			get {
				nint c = 0;
				StackNode<TElement?>? N = Head;
				while (N is not null) {
					c += N.Count;
					N = N.Next;
				}
				return c;
			}
		}

		/// <inheritdoc/>
		Boolean IRead<TElement>.Readable => Count > 0;

		/// <inheritdoc/>
		Boolean IWrite<TElement>.Writable => true;

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add([AllowNull] TElement element) => Push(element);

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear() => Collection.Clear(Head);

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Head, element);

		/// <inheritdoc/>
		public StackEnumerator<TElement> GetEnumerator() => new StackEnumerator<TElement>(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Peek([AllowNull, MaybeNull] out TElement element) => element = Head.Peek();

		/// <summary>
		/// Peeks at the top element of this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public TElement Peek() => Head.Peek();

		/// <summary>
		/// Pops the top element off this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <returns>The top element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[return: MaybeNull]
		public TElement Pop() {
			if (Head.Count == 0 && Head.Next is not null) {
				StackNode<TElement?> old = Head;
				Head = Head.Next;
				old.Unlink();
			}
			return Head.Pop();
		}

		/// <summary>
		/// Pushes the <paramref name="element"/> onto this <see cref="Stack{TElement}"/>.
		/// </summary>
		/// <param name="element">The element to push.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Push([AllowNull] TElement element) {
			if (Head.Count == Head.Capacity) {
				Head = new StackNode<TElement?>(Head);
			}
			Head.Push(element);
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Read([AllowNull, MaybeNull] out TElement element) => element = Pop();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Head, Count, amount);

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write([AllowNull] TElement element) => Push(element);
	}
}
