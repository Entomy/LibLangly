using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using Collectathon.Nodes;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over a stack.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct StackEnumerator<TElement> : IEnumerator<TElement> {
		/// <summary>
		/// The head node.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly StackNode<TElement?> Head;

		/// <summary>
		/// The current node.
		/// </summary>
		[AllowNull, MaybeNull]
		private StackNode<TElement?> N;

		/// <summary>
		/// The index into the <see cref="N"/>.
		/// </summary>
		private nint i;

		/// <summary>
		/// Initializes a new <see cref="StackEnumerator{TElement}"/>.
		/// </summary>
		/// <param name="head">The head node of the list.</param>
		/// <param name="length">The length of the sequence.</param>
		public StackEnumerator([DisallowNull] StackNode<TElement?> head, nint length) {
			Head = head;
			N = null;
			i = -1;
			Count = length;
		}

		/// <inheritdoc/>
		[MaybeNull]
		public TElement Current => N.Elements[i];

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MaybeNull]
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		public nint Count { get; }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public readonly void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public readonly IEnumerator<TElement> GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => this;

		/// <inheritdoc/>
		public Boolean MoveNext() {
			// If the current node is null, we've just started
			if (N is null) {
				// So set it to the head
				N = Head;
				i = N.Count;
			}
			// We have a node, so try traversing it
			if (i-- >= 0) {
				// All good
				return true;
			} else {
				// That node was finished, so grab the next one
				N = N.Next;
				// Was there another node?
				if (N is not null) {
					i = N.Count;
					// Could it be traversed?
					return i-- >= 0;
				} else {
					// We're finished
					return false;
				}
			}
		}

		/// <inheritdoc/>
		public void Reset() => N = null;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public readonly override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public readonly String ToString(nint amount) => Collection.ToString(Head, Count, amount);
	}
}
