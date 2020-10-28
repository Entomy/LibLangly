using System;
using Philosoft;

namespace Collectathon.Lists {
	public partial class LinkedList<TElement, TSelf, TNode> : IEnumerable<TElement, LinkedList<TElement, TSelf, TNode>.Enumerator> {
		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(this);

		public struct Enumerator : IEnumerator<TElement> {
			private readonly LinkedList<TElement, TSelf, TNode> Collection;

			private TNode Node;

			public Enumerator(LinkedList<TElement, TSelf, TNode> collection) {
				Collection = collection;
				Node = null;
			}

			/// <inheritdoc/>
			public TElement Current => Node!.Element;

			/// <inheritdoc/>
			public Boolean MoveNext() {
				// If the node is currently null, it's assumed we just started, and need to move to the actual head. Otherwise, move to the next node.
				Node = Node is null ? Collection.Head : Node.Next;
				// If the head was null (empty collection), or moving to the next node was null (end of collection), return false, otherwise true.
				return Node is not null;
			}

			/// <inheritdoc/>
			public void Reset() => Node = null;
		}
	}
}
