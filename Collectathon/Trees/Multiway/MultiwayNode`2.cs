using System;
using Collectathon.Arrays;
using Philosoft;

namespace Collectathon.Trees.Multiway {
	/// <summary>
	/// Represents the base node type of any multiway tree.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class MultiwayNode<TIndex, TElement, TSelf> : TreeNode<TIndex, TElement, TSelf> where TIndex : IEquatable<TIndex> where TSelf : MultiwayNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// The parent node.
		/// </summary>
		public readonly TSelf Parent;

		/// <summary>
		/// Holds all of the child nodes.
		/// </summary>
		public readonly DynamicArray<TSelf> Children;

		/// <inheritdoc/>
		protected MultiwayNode(TIndex index, TElement element) : base(index, element) => Children = new DynamicArray<TSelf>(0);

		/// <inheritdoc/>
		protected MultiwayNode(TIndex index, TElement element, params TSelf[] children) : base(index, element) => Children = children;

		/// <inheritdoc/>
		public override void Clear() => Children.Clear();

		/// <inheritdoc/>
		public override Boolean Contains(TElement element) {
			foreach (TSelf child in Children) {
				if (child.Contains(element)) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public override void Replace(TElement oldElement, TElement newElement) {
			foreach (TSelf child in Children) {
				child.Replace(oldElement, newElement);
			}
		}

		/// <inheritdoc/>
		public override void Replace(Predicate<TElement> match, TElement newElement) {
			foreach (TSelf child in Children) {
				child.Replace(match, newElement);
			}
		}
	}
}
