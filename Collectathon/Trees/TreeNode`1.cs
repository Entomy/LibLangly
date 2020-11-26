using System;
using Langly;

namespace Collectathon.Trees {
	/// <summary>
	/// Represents the base node type of any tree.
	/// </summary>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class TreeNode<TElement, TSelf> : BaseNode<TElement, TSelf>, IContainable<TElement>, IReplaceable<TElement> where TSelf : TreeNode<TElement, TSelf> {
		/// <inheritdoc/>
		protected TreeNode(TElement element) : base(element) { }

		/// <inheritdoc/>
		public abstract Boolean Contains(TElement element);

		/// <inheritdoc/>
		public abstract void Replace(TElement oldElement, TElement newElement);

		/// <inheritdoc/>
		public abstract void Replace(Predicate<TElement> match, TElement newElement);
	}
}
