using System;
using Philosoft;

namespace Collectathon.Trees {
	/// <summary>
	/// Represents any kind of associative tree structure.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
	public abstract class Tree<TIndex, TElement, TSelf, TNode> : IAddable<TIndex, TElement>, IClearable, IContainable<TElement>, ICountable, IRemovable<TIndex, TElement>, IReplaceable<TElement> where TIndex : IEquatable<TIndex> where TSelf : Tree<TIndex, TElement, TSelf, TNode> where TNode : TreeNode<TIndex, TElement, TNode> {
		/// <summary>
		/// The root node.
		/// </summary>
		protected TNode Root;

		/// <inheritdoc/>
		protected Tree() { }

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		void IAddable<TIndex, TElement>.Add(TIndex index, TElement element) => Add(index, element);

		/// <inheritdoc/>
		void IClearable.Clear() {
			Root?.Clear();
			Count = 0;
		}

		/// <inheritdoc/>
		Boolean IContainable<TElement>.Contains(TElement element) => Root?.Contains(element) ?? false;

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(TElement element) => Remove(element);

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(Predicate<TElement> match) => Remove(match);

		/// <inheritdoc/>
		void IRemovable<TIndex, TElement>.RemoveAt(TIndex index) => RemoveAt(index);

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(TElement oldElement, TElement newElement) => Root?.Replace(oldElement, newElement);

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(Predicate<TElement> match, TElement newElement) => Root?.Replace(match, newElement);

		protected abstract void Add(TIndex index, TElement element);

		protected abstract void Remove(TElement element);

		protected abstract void Remove(Predicate<TElement> match);

		protected abstract void RemoveAt(TIndex index);
	}
}
