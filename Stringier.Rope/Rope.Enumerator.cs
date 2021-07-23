using System;
using System.ComponentModel;
using System.Traits.Concepts;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Provides enumeration over a <see cref="Stringier.Rope"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator : IEnumerator<Char> {
			/// <summary>
			/// The rope being enumerated.
			/// </summary>
			private Rope? Rope;

			/// <summary>
			/// The current node.
			/// </summary>
			private Node? N;

			/// <summary>
			/// The index offset within <see cref="N"/>.
			/// </summary>
			private Int32 i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="rope">The rope to enumerate.</param>
			public Enumerator(Rope rope) {
				Rope = rope;
				N = default;
				Count = rope.Count;
				i = -1;
			}

			/// <inheritdoc/>
			public Char Current => N![i]; // MoveNext() ensures this isn't null so long as it returns `true`. Manual use of an enumerator is considered dangerous anyways.

			/// <inheritdoc/>
			public Int32 Count { get; }

			/// <inheritdoc/>
			public Boolean MoveNext() {
				// If the list has been set to null
				if (Rope is null) {
					// We've finished
					return false;
				}
				// If the current node is null, we've just started
				if (N is null) {
					// So set it to the ropes head
					N = Rope.Head;
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
					// Was there another node
					if (N is not null) {
						// Could it be traversed?
						return ++i < N.Count;
					} else {
						// Null the list to indicate we're finished
						Rope = null;
						return false;
					}
				}
			}

			/// <inheritdoc/>
			public void Reset() {
				N = default;
				i = -1;
			}
		}
	}
}
