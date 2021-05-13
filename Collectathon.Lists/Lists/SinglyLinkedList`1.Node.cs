using Collectathon.Nodes;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Lists {
	public partial class SinglyLinkedList<TElement> {
		/// <summary>
		/// Represents a node of a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public sealed class Node : StandardListNode<TElement, Node> {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="element">The element contained in this node.</param>
			/// <param name="next">The next node in the list.</param>
			public Node([AllowNull] TElement element, [AllowNull] Node next) : base(element, next) { }

			/// <inheritdoc/>
			public override void Clear() => Next = null;

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Postpend([AllowNull] TElement element) {
				Next = new Node(element, next: null);
				return Next;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Prepend([AllowNull] TElement element) => new Node(element, next: this);
		}
	}
}
