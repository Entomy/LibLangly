using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over a standard linked list.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	/// <typeparam name="TNode">The type of the nodes being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct StandardListEnumerator<TElement, TNode> : IEnumerator<TElement> where TNode : class, IElement<TElement>, INext<TNode> {
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
		/// Initializes a new <see cref="StandardListEnumerator{TElement, TNode}"/>.
		/// </summary>
		/// <param name="head">The head node of the list.</param>
		/// <param name="length">The length of the sequence.</param>
		public StandardListEnumerator([AllowNull] TNode head, Int32 length) {
			Head = head;
			N = null;
			Count = length;
		}

		/// <inheritdoc/>
		[MaybeNull]
		public TElement Current => N.Element;

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MaybeNull]
		Object System.Collections.IEnumerator.Current => Current;

		/// <inheritdoc/>
		public Int32 Count { get; }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[return: NotNull]
		public IEnumerator<TElement> GetEnumerator() => this;

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
		public String ToString(Int32 amount) => Collection.ToString(Head, Count, amount);
	}
}
