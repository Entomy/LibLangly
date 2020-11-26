using System;
using Langly;

namespace Collectathon.Trees {
	/// <summary>
	/// Represents the base node type of any associative tree.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class TreeNode<TIndex, TElement, TSelf> : BaseNode<TIndex, TElement, TSelf>, IContainable<TElement>, IReplaceable<TElement> where TIndex : IEquatable<TIndex> where TSelf : TreeNode<TIndex, TElement, TSelf> {
		/// <inheritdoc/>
		protected TreeNode(TIndex index, TElement element) : base(index, element) { }

		/// <inheritdoc/>
		public abstract Boolean Contains(TElement element);

		/// <inheritdoc/>
		public abstract void Replace(TElement oldElement, TElement newElement);

		/// <inheritdoc/>
		public abstract void Replace(Predicate<TElement> match, TElement newElement);
	}
}
