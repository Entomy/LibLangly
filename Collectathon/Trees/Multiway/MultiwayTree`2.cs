using System;

namespace Collectathon.Trees.Multiway {
	/// <summary>
	/// Represents any kind of associative multiway tree structure.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
	public abstract class MultiwayTree<TIndex, TElement, TSelf, TNode> : Tree<TIndex, TElement, TSelf, TNode> where TIndex : IEquatable<TIndex> where TSelf : MultiwayTree<TIndex, TElement, TSelf, TNode> where TNode : MultiwayNode<TIndex, TElement, TNode> {
	}
}
