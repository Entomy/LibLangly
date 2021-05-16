using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Nodes;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>.
		/// </summary>
		public abstract class Node : UnrolledListNode<Char, Node> {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			protected Node([AllowNull] Node next, [AllowNull] Node previous) : base(next) => Previous = previous;

			/// <summary>
			/// The previous node in the list.
			/// </summary>
			[AllowNull, MaybeNull]
			public Node Previous { get; set; }

			/// <inheritdoc/>
			public sealed override void Clear() {
				Next = null;
				Previous = null;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public sealed override Node Postpend([AllowNull] Char element) {
				Next = new CharNode(element, next: null, previous: this);
				return Next;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public sealed override Node Postpend(ReadOnlyMemory<Char> elements) {
				Next = new MemoryNode(elements, next: null, previous: this);
				return Next;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public sealed override Node Prepend([AllowNull] Char element) => new CharNode(element, next: this, previous: null);

			/// <inheritdoc/>
			[return: NotNull]
			public sealed override Node Prepend(ReadOnlyMemory<Char> elements) => new MemoryNode(elements, next: this, previous: null);
		}
	}
}
