using Collectathon.Nodes;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Lists {
	public partial class SinglyLinkedList<TIndex, TElement> {
		/// <summary>
		/// Represents a node of a <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public sealed class Node : StandardListNode<TIndex, TElement, Node> {
			/// <summary>
			/// Initializes a new <see cref="Node"/>.
			/// </summary>
			/// <param name="index">The index of the <paramref name="element"/>.</param>
			/// <param name="element">The element contained in this node.</param>
			/// <param name="next">The next node in the list.</param>
			public Node([DisallowNull] TIndex index, [AllowNull] TElement element, [AllowNull] Node next) : base(index, element, next) { }

			/// <inheritdoc/>
			public override void Clear() => Next = null;

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Postpend([DisallowNull] TIndex index, [AllowNull] TElement element) {
				Next = new Node(index, element, next: null);
				return Next;
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override Node Prepend([DisallowNull] TIndex index, [AllowNull] TElement element) => new Node(index, element, next: this);
		}
	}
}
