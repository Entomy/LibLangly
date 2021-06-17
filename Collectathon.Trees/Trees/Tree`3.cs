using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Enumerators;
using Collectathon.Nodes;

namespace Collectathon.Trees {
	/// <summary>
	/// Represents any tree.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the tree.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the tree.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public abstract class Tree<TElement, TNode, TSelf> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		IRemove<TElement>,
		IReplace<TElement>,
		ISequence<TElement, TreeEnumerator<TElement>>
		where TNode : TreeNode<TElement, TNode>
		where TSelf : Tree<TElement, TNode, TSelf> {
		/// <summary>
		/// The root node of the tree; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected readonly TNode Root;

		/// <summary>
		/// Initializes a new <see cref="Tree{TElement, TNode, TSelf}"/>.
		/// </summary>
		protected Tree() { }

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		public void Add([AllowNull] TElement element) => Root?.Add(element);

		/// <inheritdoc/>
		public void Clear() {
			Root?.Clear();
			Count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Root?.Contains(element) ?? false;

		/// <inheritdoc/>
		[return: NotNull]
		public TreeEnumerator<TElement> GetEnumerator() => GetEnumerator(Traversal.InOrder);

		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <param name="traversal">The traversal order to use.</param>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		[return: NotNull]
		public TreeEnumerator<TElement> GetEnumerator(Traversal traversal) {
			switch (traversal) {
			case Traversal.InOrder:
				throw new NotImplementedException();
			default:
				throw new ArgumentException("", nameof(traversal));
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		public void Remove([AllowNull] TElement element) => Root?.Remove(element);

		/// <inheritdoc/>
		public void RemoveFirst([AllowNull] TElement element) => Root?.Remove(element);

		/// <inheritdoc/>
		public void RemoveLast([AllowNull] TElement element) => Root?.Remove(element);

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Root?.Replace(search, replace);

		/// <inheritdoc/>
		public sealed override String ToString() => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => throw new NotImplementedException();
	}
}
