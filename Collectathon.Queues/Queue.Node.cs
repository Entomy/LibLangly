using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Queues {
	public partial class Queue<TElement> {
		/// <summary>
		/// Represents a queue node.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public sealed class Node : IContains<TElement>, IElement<TElement>, INext<Node>, IUnlink {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element contained in this node.</param>
			public Node([AllowNull] TElement element) : this(element, null) { }

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element contained in this node.</param>
			/// <param name="next">The next node of the queue.</param>
			public Node([AllowNull] TElement element, [AllowNull] Node next) {
				Element = element;
				Next = next;
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public TElement Element { get; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Next { get; set; }

			/// <inheritdoc/>
			public Boolean Contains([AllowNull] TElement element) => Equals(Element, element);

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Element?.ToString() ?? "null";

			/// <inheritdoc/>
			public void Unlink() => Next = null;
		}
	}
}
