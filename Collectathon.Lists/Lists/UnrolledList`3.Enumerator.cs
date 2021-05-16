using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace Collectathon.Lists {
	public partial class UnrolledList<TElement, TNode, TSelf> {
		/// <summary>
		/// Provides enumeration over a <see cref="UnrolledList{TElement, TNode, TSelf}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<TElement> {
			/// <summary>
			/// The list being enumerated.
			/// </summary>
			[AllowNull, MaybeNull]
			private UnrolledList<TElement, TNode, TSelf> List;

			/// <summary>
			/// The current node.
			/// </summary>
			[AllowNull, MaybeNull]
			private TNode N;

			/// <summary>
			/// The current index offset;
			/// </summary>
			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="list">The list to enumerate.</param>
			public Enumerator([DisallowNull] UnrolledList<TElement, TNode, TSelf> list) {
				List = list;
				N = default;
				i = -1;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public TElement Current => N[i];

			/// <inheritdoc/>
			[MaybeNull]
			Object System.Collections.IEnumerator.Current => Current;

			/// <inheritdoc/>
			public nint Count => List.Count;

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
				if (List is null) return false;
				N = N is null ? List.Head : N.Next;
				if (N is not null) {
					return true;
				} else {
					List = null;
					return false;
				}
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
