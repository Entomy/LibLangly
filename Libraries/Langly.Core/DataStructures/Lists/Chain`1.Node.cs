using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> {
		/// <summary>
		/// Represents any Node of a <see cref="Chain{TElement}"/>.
		/// </summary>
		private abstract class Node : Record<Node> {
			/// <summary>
			/// The next node in the chain.
			/// </summary>
			[AllowNull]
			public Node Next;

			/// <summary>
			/// The previous node in the chain.
			/// </summary>
			[AllowNull]
			public Node Previous;

			/// <summary>
			/// Initialize a new <see cref="Node"/>.
			/// </summary>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			protected Node([AllowNull] Node previous, [AllowNull] Node next) {
				Next = next;
				Previous = previous;
			}

			/// <inheritdoc/>
			public abstract ref readonly TElement this[nint index] { get; }

			/// <inheritdoc/>
			public abstract nint Count { get; }

			/// <inheritdoc/>
			[return: NotNull]
			public Node Clear() {
				Next = null;
				Previous = null;
				return this;
			}

			/// <inheritdoc/>
			public abstract (Node Head, Node Tail) Insert(nint index, [AllowNull] TElement element);

			/// <inheritdoc/>
			public abstract (Node Head, Node Tail) Insert(nint index, ReadOnlyMemory<TElement> elements);

			/// <inheritdoc/>
			public abstract (Node Head, Node Tail) Replace([AllowNull] TElement search, [AllowNull] TElement replace);
		}
	}
}
