using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Lists {
	public partial class StandardList<TIndex, TElement, TNode, TSelf> {
		/// <summary>
		/// Provides enumeration over a <see cref="StandardList{TIndex, TElement, TNode, TSelf}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<(TIndex Index, TElement Element)> {
			/// <summary>
			/// The list being enumerated.
			/// </summary>
			[AllowNull, MaybeNull]
			private StandardList<TIndex, TElement, TNode, TSelf> List;

			/// <summary>
			/// The current node.
			/// </summary>
			[AllowNull, MaybeNull]
			private TNode N;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="list">The list to enumerate.</param>
			public Enumerator([DisallowNull] StandardList<TIndex, TElement, TNode, TSelf> list) {
				List = list;
				N = default;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public (TIndex Index, TElement Element) Current => (N.Index, N.Element);

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
			public IEnumerator<(TIndex Index, TElement Element)> GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.Generic.IEnumerator<(TIndex Index, TElement Element)> System.Collections.Generic.IEnumerable<(TIndex Index, TElement Element)>.GetEnumerator() => this;

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
			public override String ToString() => Collection.ToString(List.Head, List.Count);

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => Collection.ToString(List.Head, List.Count, amount);
		}
	}
}
