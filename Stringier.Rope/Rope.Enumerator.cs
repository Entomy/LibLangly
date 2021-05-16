using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Provides enumeration over a <see cref="Rope"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<Char> {
			/// <summary>
			/// The list being enumerated.
			/// </summary>
			[AllowNull, MaybeNull]
			private Rope List;

			/// <summary>
			/// The current node.
			/// </summary>
			[AllowNull, MaybeNull]
			private Node N;

			/// <summary>
			/// The index offset within <see cref="N"/>.
			/// </summary>
			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="list">The list to enumerate.</param>
			public Enumerator([DisallowNull] Rope list) {
				List = list;
				N = default;
				i = -1;
			}

			/// <inheritdoc/>
			[MaybeNull]
			public Char Current => N[i];

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
			public IEnumerator<Char> GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => this;

			/// <inheritdoc/>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[return: NotNull]
			System.Collections.Generic.IEnumerator<Char> System.Collections.Generic.IEnumerable<Char>.GetEnumerator() => this;

			/// <inheritdoc/>
			public Boolean MoveNext() {
				// If the list has been set to null
				if (List is null) {
					// We've finished
					return false;
				}
				// If the current node is null, we've just started
				if (N is null) {
					// So set it to the ropes head
					N = List.Head;
					// If its still null
					if (N is null) {
						// The rope is empty
						return false;
					}
				}
				// We have a node, so now try traversing it
				if (++i <= N.Count - 1) {
					// All good
					return true;
				} else {
					// That node was finished, so grab the next one
					N = N.Next;
					i = -1;
					// Was there another node, and could it be traversed?
					if (N is not null) {
						// Count it be traversed?
						return ++i < N.Count;
					} else {
						// Null the list to indicate we're finished
						List = null;
						return false;
					}
				}
			}

			/// <inheritdoc/>
			public void Reset() {
				N = default;
				i = -1;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Collection.ToString(this);

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => Collection.ToString(this, amount);
		}
	}
}
