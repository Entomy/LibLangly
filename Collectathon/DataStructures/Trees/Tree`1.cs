using System;

namespace Langly.DataStructures.Trees {
	/// <summary>
	/// Represents any kind of tree structure.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TNode">The type of nodes making up the tree.</typeparam>
	public abstract class Tree<TElement, TSelf, TNode> : IAddable<TElement>, IClearable, IContainable<TElement>, ICountable, IRemovable<TElement>, IReplaceable<TElement> where TSelf : Tree<TElement, TSelf, TNode> where TNode : TreeNode<TElement, TNode> {
		/// <summary>
		/// The root node.
		/// </summary>
		protected TNode Root;

		/// <inheritdoc/>
		protected Tree() { }

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		void IAddable<TElement>.Add(TElement element) => Add(element);

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
		void IReplaceable<TElement, TElement>.Replace(TElement oldElement, TElement newElement) => Root?.Replace(oldElement, newElement);

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(Predicate<TElement> match, TElement newElement) => Root?.Replace(match, newElement);

		protected abstract void Add(TElement element);

		protected abstract void Remove(TElement element);

		protected abstract void Remove(Predicate<TElement> match);
	}
}
