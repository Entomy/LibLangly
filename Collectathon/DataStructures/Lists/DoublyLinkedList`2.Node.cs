namespace Langly.DataStructures.Lists {
	public partial class DoublyLinkedList<TIndex, TElement> {
		/// <summary>
		/// Represents a node of a <see cref="DoublyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public sealed class Node : LinkedNode<TIndex, TElement, Node> {
			/// <summary>
			/// The previous <see cref="Node"/>.
			/// </summary>
			public Node Previous;

			/// <inheritdoc/>
			public Node(TIndex index, TElement element, Node next, Node previous) : base(index, element, next) => Previous = previous;

			/// <inheritdoc/>
			public override void Clear() {
				Next = null;
				Previous = null;
			}
		}
	}
}
