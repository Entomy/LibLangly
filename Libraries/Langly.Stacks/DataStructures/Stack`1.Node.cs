using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	public partial class Stack<TElement> {
		/// <summary>
		/// Represents a node containing an individual element within the <see cref="Stack{TElement}"/>.
		/// </summary>
		protected sealed class Node : Record<Node> {
			/// <summary>
			/// The element contained in the node.
			/// </summary>
			[AllowNull]
			public readonly TElement Element;

			/// <summary>
			/// The next node in the <see cref="Stack{TElement}"/>.
			/// </summary>
			[AllowNull]
			public Node Next;

			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element contained in the node.</param>
			/// <param name="next">The next node in the <see cref="Stack{TElement}"/>.</param>
			public Node([AllowNull] TElement element, [AllowNull] Node next) {
				Element = element;
				Next = next;
			}

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) => other?.Element?.Equals(Element) ?? false;

			/// <inheritdoc/>
			public override String ToString() => Element.ToString();
		}
	}
}
