using Langly.DataStructures.Views;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> : ISequenceBidi<TElement, Chain<TElement>.Enumerator> {
		/// <inheritdoc/>
		public override Chain<TElement>.Enumerator GetEnumerator() => new Enumerator(this);

		/// <inheritdoc/>
		public IEnumerator<TElement> Reverse() => throw new NotImplementedException();

		/// <summary>
		/// Provides enumeration over a <see cref="Chain{TElement}"/>.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[StructLayout(LayoutKind.Auto)]
		public struct Enumerator : IEnumeratorBidi<TElement> {
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
			public Boolean MovePrevious() {
				// If the current node is null, we've just started
				if (N is null) {
					// So set it to the chains tail
					N = Chain.Tail;
					// If its still null
					if (N is null) {
						// The chain is empty
						return false;
					}
				}
				// We have a node, so now try traversing it
				if (--i >= 0) {
					// All good
					return true;
				} else {
					// That node was finished, so grab the next one
					N = N.Previous;
					// If the new node is null
					if (N is null) {
						// We passed the beginning of the chain
						return false;
					} else {
						// We still have a node
						i = N.Count;
						// Can it be traversed?
						return --i >= 0;
					}
				}
			}

			/// <inheritdoc/>
			public void ResetBeginning() {
				N = Chain.Head;
				i = -1;
			}

			/// <inheritdoc/>
			public void ResetEnding() {
				N = Chain.Tail;
				i = N.Count;
			}
		}
	}
}
