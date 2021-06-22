using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Trees;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="Tree{TElement, TNode, TSelf}"/> node.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class TreeNode<TElement, TSelf> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		ICount,
		IParent<TSelf>,
		IRemove<TElement>,
		IReplace<TElement>,
		IUnlink
		where TSelf : TreeNode<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="TreeNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="parent">The parent node in the tree.</param>
		protected TreeNode([AllowNull] TSelf parent) => Parent = parent;

		/// <inheritdoc/>
		public Int32 Count { get; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TSelf Parent { get; set; }

		/// <inheritdoc/>
		public abstract void Add([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void Clear();

		/// <inheritdoc/>
		public abstract Boolean Contains([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void Remove([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void RemoveFirst([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void RemoveLast([AllowNull] TElement element);

		/// <inheritdoc/>
		public abstract void Replace([AllowNull] TElement search, [AllowNull] TElement replace);

		/// <inheritdoc/>
		public abstract void Unlink();
	}
}
