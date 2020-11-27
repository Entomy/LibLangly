namespace Langly.DataStructures.Lists {
	public partial class SinglyLinkedList<TIndex, TElement> {
		/// <summary>
		/// Represents a node of a <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public sealed class Node : LinkedNode<TIndex, TElement, Node> {
			/// <inheritdoc/>
			public Node(TIndex index, TElement element, Node next) : base(index, element, next) { }

			/// <inheritdoc/>
			public override void Clear() => Next = null;
		}
	}
}
