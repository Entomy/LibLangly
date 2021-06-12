namespace Collectathon.Trees {
	/// <summary>
	/// Indicates the traversal order when enumerated a <see cref="Tree{TElement, TNode, TSelf, TEnumerator}"/>.
	/// </summary>
	public enum Traversal {
		/// <summary>
		/// Traverses in-order, if the tree sorting has been maintained.
		/// </summary>
		InOrder = 0,
	}
}
