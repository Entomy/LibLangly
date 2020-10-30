using System;

namespace Collectathon.Trees.Multiway {
	/// <summary>
	/// Represents any kind of multiway tree structure.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
	public abstract class MultiwayTree<TElement, TSelf, TNode> : Tree<TElement, TSelf, TNode> where TSelf : MultiwayTree<TElement, TSelf, TNode> where TNode : MultiwayNode<TElement, TNode> {
	}
}
