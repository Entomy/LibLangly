using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> : ISequence<TElement, Chain<TElement>.Enumerator> {
		/// <inheritdoc/>
		public override Chain<TElement>.Enumerator GetEnumerator() => new Enumerator(this);

		/// <summary>
		/// Provides enumeration over a <see cref="Chain{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumerator<TElement> {
			[DisallowNull]
			private readonly Chain<TElement> Chain;

			[AllowNull]
			private Node N;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="chain">The <see cref="Chain{TElement}"/> to enumerate.</param>
			public Enumerator([DisallowNull] Chain<TElement> chain) {
				Chain = chain;
				N = null;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => N[i];

			/// <inheritdoc/>
			public nint Count => Chain.Count;

			/// <inheritdoc/>
			public Boolean MoveNext() {
				// If the current node is null, we've just started
				if (N is null) {
					// So set it to the chains head
					N = Chain.Head;
					// If its still null
					if (N is null) {
						// The chain is empty
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
					return N is not null && i++ < N.Count - 1;
				}
			}

			/// <inheritdoc/>
			public void Reset() {
				N = Chain.Head;
				i = -1;
			}
		}
	}
}
