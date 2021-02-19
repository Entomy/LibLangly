using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures;

namespace Langly.DataStructures {
	public partial class Counter<TElement> {
		/// <summary>
		/// Represents an individual <see cref="Counter{TElement}"/> entry.
		/// </summary>
		private sealed class Node : Node<TElement, nint, Node> // This is deliberately backwards, as the element is effectively the index
			{
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element of the node.</param>
			/// <param name="previous">The previous node.</param>
			/// <param name="next">The next node.</param>
			public Node([AllowNull] TElement element, [AllowNull] Node previous, [AllowNull] Node next) : this(element, 0, previous, next) { }

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element of the node.</param>
			/// <param name="count">The count of the <paramref name="element"/>.</param>
			/// <param name="previous">The previous node.</param>
			/// <param name="next">The next node.</param>
			public Node([AllowNull] TElement element, nint count, [AllowNull] Node previous, [AllowNull] Node next) : base(element, count) {
				Previous = previous;
				Next = next;
			}

			/// <summary>
			/// The next node.
			/// </summary>
			[AllowNull, MaybeNull]
			public Node Next { get; set; }

			/// <summary>
			/// The previous node.
			/// </summary>
			[AllowNull, MaybeNull]
			public Node Previous { get; set; }

			/// <inheritdoc/>
			public override Boolean Contains([AllowNull] nint element) => Element == element;

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Replace([AllowNull] nint search, [AllowNull] nint replace) {
				if (Element.Equals(search)) {
					Element = replace;
				}
				return this;
			}
		}
	}
}
