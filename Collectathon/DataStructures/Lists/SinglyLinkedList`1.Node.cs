namespace Langly.DataStructures.Lists {
	public partial class SinglyLinkedList<TElement> {
		/// <summary>
		/// Represents a node of a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		public sealed class Node : LinkedNode<TElement, Node> {
			/// <inheritdoc/>
			public Node(TElement element, Node next) : base(element, next) { }

			/// <inheritdoc/>
			public override void Clear() => Next = null;
		}
	}
}
