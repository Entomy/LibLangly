using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Trees {
	/// <summary>
	/// Represents the base node type of any tree.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the nodes.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class TreeNode<TIndex, TElement, TSelf> : Record<TSelf>,
		IContains<TElement>,
		IReplace<TElement, TSelf>
		where TSelf : TreeNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// The parent node.
		/// </summary>
		public TSelf Parent { get; }

		/// <summary>
		/// Initializes a new <see cref="TreeNode{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="parent">The parent node of this node.</param>
		protected TreeNode([DisallowNull] TSelf parent) { }

		/// <inheritdoc/>
		public abstract Boolean Contains([AllowNull] TElement element);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract TSelf Replace([AllowNull] TElement search, [AllowNull] TElement replace);
	}
}
