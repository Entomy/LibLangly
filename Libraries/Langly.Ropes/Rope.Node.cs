using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly {
	public partial class Rope {
		/// <summary>
		/// Represents any Node of a <see cref="Rope"/>.
		/// </summary>
		private abstract class Node : Record<Node>,
			IClear<Node>,
			IIndexReadOnly<Char> {
			/// <summary>
			/// The next node in the rope.
			/// </summary>
			[AllowNull, MaybeNull]
			public Node Next;

			/// <summary>
			/// The previous node in the rope.
			/// </summary>
			[AllowNull, MaybeNull]
			public Node Previous;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="previous">The previous node in the rope.</param>
			/// <param name="next">The next node in the rope.</param>
			protected Node([AllowNull] Node previous, [AllowNull] Node next) {
				Next = next;
				Previous = previous;
			}

			/// <inheritdoc/>
			public abstract Char this[nint index] { get; }

			/// <inheritdoc/>
			public abstract nint Count { get; }

			/// <inheritdoc/>
			[return: NotNull]
			public Node Clear() {
				Next = null;
				Previous = null;
				return this;
			}
		}
	}
}
