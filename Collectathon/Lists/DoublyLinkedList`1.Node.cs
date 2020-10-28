namespace Collectathon.Lists {
	public partial class DoublyLinkedList<TElement> {
		/// <summary>
		/// Represents a node of a <see cref="DoublyLinkedList{TElement}"/>.
		/// </summary>
		public sealed class Node : LinkedNode<TElement, Node> {
			/// <summary>
			/// The previous <see cref="Node"/>.
			/// </summary>
			public Node Previous;

			/// <inheritdoc/>
			public Node(TElement element, Node next, Node previous) : base(element, next) => Previous = previous;

			/// <inheritdoc/>
			public override void Clear() {
				Next = null;
				Previous = null;
			}
		}
	}
}
