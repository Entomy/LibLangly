using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Trees {
	/// <summary>
	/// Represents the base node type of any associative tree.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the nodes.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class TreeNode<TIndex, TElement, TSelf> : Node<TIndex, TElement, TSelf>
		where TSelf : TreeNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// The parent node.
		/// </summary>
		public TSelf Parent { get; }

		/// <summary>
		/// Initializes a new <see cref="TreeNode{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="index">The index of this node.</param>
		/// <param name="element">The element of this node.</param>
		/// <param name="parent">The parent node of this node.</param>
		protected TreeNode([AllowNull] TIndex index, [AllowNull] TElement element, [DisallowNull] TSelf parent) : base(index, element) => Parent = parent;
	}
}
