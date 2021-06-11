using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Stacks {
	public partial class Stack<TElement> {
		/// <summary>
		/// Represents a stack node.
		/// </summary>
		private sealed class Node : IContains<TElement>, IElement<TElement>, INext<Node>, IUnlink {
			/// <summary>
			/// Initializes a new <see cref="Node"/>
			/// </summary>
			/// <param name="element">The element contained in this node.</param>
			/// <param name="next">The next node of the stack.</param>
			public Node([AllowNull] TElement element, [AllowNull] Node next) {
				Element = element;
				Next = next;
			}

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public TElement Element { get; }

			/// <inheritdoc/>
			[AllowNull, MaybeNull]
			public Node Next { get; private set; }

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
