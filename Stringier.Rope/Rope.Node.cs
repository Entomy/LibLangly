using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>.
		/// </summary>
		public abstract class Node : IContains<Char>, IIndexReadOnly<Int32, Char>, INext<Node>, IPrevious<Node>, IUnlink {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="next">The next node in the list.</param>
			/// <param name="previous">The previous node in the list.</param>
			protected Node([AllowNull] Node next, [AllowNull] Node previous) {
				Next = next;
				Previous = previous;
			}

			/// <inheritdoc/>
			public abstract Int32 Count { get; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Next { get; set; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Previous { get; set; }

			/// <inheritdoc/>
			public abstract Char this[Int32 index] { get; }

			/// <inheritdoc/>
			public abstract Boolean Contains(Char element);

			public abstract (Node Head, Node Tail) Insert(Int32 index, [AllowNull] Char element);

			public abstract (Node Head, Node Tail) Insert(Int32 index, ReadOnlyMemory<Char> elements);

			[return: NotNull]
			public Node Postpend([AllowNull] Char element) {
				Next = new CharNode(element, next: null, previous: this);
				return Next;
			}

			[return: NotNull]
			public Node Postpend(ReadOnlyMemory<Char> elements) {
				Next = new MemoryNode(elements, next: null, previous: this);
				return Next;
			}

			[return: NotNull]
			public Node Prepend([AllowNull] Char element) => new CharNode(element, next: this, previous: null);

			[return: NotNull]
			public Node Prepend(ReadOnlyMemory<Char> elements) => new MemoryNode(elements, next: this, previous: null);

			public abstract (Node Head, Node Tail) Remove([AllowNull] Char element);

			public abstract (Node Head, Node Tail) Replace(Char search, Char replace);

			/// <inheritdoc/>
			public void Unlink() {
				Next = null;
				Previous = null;
			}
		}
	}
}
