using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Trees.Multiway {
	/// <summary>
	/// Represents the base node type of any multiway tree.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the nodes.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class MultiwayNode<TIndex, TElement, TSelf> : TreeNode<TIndex, TElement, TSelf>,
		ICount,
		IInsert<TIndex, TElement, TSelf>,
		IResizable<TSelf>
		where TSelf : MultiwayNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// Holds all of the child nodes.
		/// </summary>
		[DisallowNull, NotNull]
		protected TSelf[] Children;

		/// <summary>
		/// Initializes a new <see cref="MultiwayNode{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="parent">The parent node of this node.</param>
		/// <param name="children">The child nodes of this node.</param>
		protected MultiwayNode([DisallowNull] TSelf parent, [DisallowNull] params TSelf[] children) : base(parent) => Children = children;

		/// <inheritdoc/>
		public nint Capacity {
			get => Children.Length;
			set => Resize(value);
		}

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		public sealed override Boolean Contains([AllowNull] TElement element) {
			foreach (TSelf child in Children) {
				if (child.Contains(element)) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public abstract TSelf Insert([DisallowNull] TIndex index, [AllowNull] TElement element);

		/// <inheritdoc/>
		public TSelf Resize(nint capacity) {
			TSelf[] newChildren = new TSelf[capacity];
			Array.Copy(Children, newChildren, Count);
			Children = newChildren;
			return (TSelf)this;
		}
	}
}
