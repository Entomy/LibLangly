using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon.Lists {
	/// <summary>
	/// Provides enumeration over a standard associative linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	/// <typeparam name="TNode">The type of the nodes being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct StandardListEnumerator<TIndex, TElement, TNode> : IEnumerator<(TIndex Index, TElement? Element)> where TNode : class, IElement<TElement>, IIndex<TIndex>, INext<TNode> {
		/// <summary>
		/// The head node.
		/// </summary>
		[AllowNull, MaybeNull]
		private readonly TNode Head;

		/// <summary>
		/// The current node.
		/// </summary>
		[AllowNull, MaybeNull]
		private TNode N;

		/// <summary>
		/// Initializes a new <see cref="StandardListEnumerator{TIndex, TElement, TNode}"/>.
		/// </summary>
		/// <param name="head">The head node of the list.</param>
		/// <param name="length">The length of the sequence.</param>
		public StandardListEnumerator([AllowNull] TNode head, nint length) {
			Head = head;
			N = null;
			Count = length;
		}

		/// <inheritdoc/>
		public (TIndex Index, TElement? Element) Current => (N.Index, N.Element);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MaybeNull]
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		public nint Count { get; }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public IEnumerator<(TIndex Index, TElement? Element)> GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		System.Collections.Generic.IEnumerator<(TIndex Index, TElement? Element)> System.Collections.Generic.IEnumerable<(TIndex Index, TElement? Element)>.GetEnumerator() => this;

		/// <inheritdoc/>
		public Boolean MoveNext() {
			N = N is null ? Head : N.Next;
			return N is not null;
		}

		/// <inheritdoc/>
		public void Reset() => N = null;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public override String ToString() => Collection.ToString(Head, Count);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Head, Count, amount);
	}
}
