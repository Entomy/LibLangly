using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using Langly;

namespace Collectathon.Queues {
	public partial class Queue<TElement> {
		/// <summary>
		/// Provides enumeration over a <see cref="Queue{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DebuggerDisplay("{ToString(5),nq}")]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The queue being enumerated.
			/// </summary>
			[DisallowNull, NotNull]
			private readonly Queue<TElement> Queue;

			/// <summary>
			/// The current node.
			/// </summary>
			[AllowNull, MaybeNull]
			private Node N;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="queue">The queue to enumerate.</param>
			public Enumerator([DisallowNull] Queue<TElement> queue) {
				Queue = queue;
				N = null;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public TElement Current => N.Element;

			/// <inheritdoc/>
			[MaybeNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count => Queue.Count;

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
				N = N is null ? Queue.Head : N.Next;
				return N is not null;
			}

			/// <inheritdoc/>
			public void Reset() => N = null;

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Collection.ToString(this);

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => Collection.ToString(this, amount);
		}
	}
}
