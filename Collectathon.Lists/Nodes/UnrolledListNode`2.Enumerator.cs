using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Nodes {
	public partial class UnrolledListNode<TElement, TSelf> {
		/// <summary>
		/// Provides enumeration over a <see cref="UnrolledListNode{TElement, TSelf}"/>.
		/// </summary>
		[DebuggerDisplay("{ToString(5),nq}")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The node being enumerated.
			/// </summary>
			private readonly UnrolledListNode<TElement, TSelf> Node;

			/// <summary>
			/// The current index.
			/// </summary>
			private nint i;
			
			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="node">The <see cref="UnrolledListNode{TElement, TSelf}"/> to enumerate.</param>
			public Enumerator([DisallowNull] UnrolledListNode<TElement, TSelf> node) {
				Node = node;
				i = -1;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public TElement Current => Node[i];

			/// <inheritdoc/>
			[MaybeNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count => Node.Count;

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
			public Boolean MoveNext() => ++i < Count;

			/// <inheritdoc/>
			public void Reset() => i = -1;

			/// <inheritdoc/>
			public override String ToString() => Node.ToString();

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => Node.ToString(amount);
		}
	}
}
