using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="List{TElement, TNode, TSelf, TEnumerator}"/> node.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the nodes.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class ListNode<TElement, TSelf> :
		IClear,
		ICount,
		IReplace<TElement>
		where TSelf : ListNode<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="ListNode{TElement, TSelf}"/>.
		/// </summary>
		protected ListNode() { }

		/// <summary>
		/// The next node in the list.
		/// </summary>
		[AllowNull, MaybeNull]
		public TSelf Next { get; set; }

		/// <inheritdoc/>
		public abstract nint Count { get; }

		/// <inheritdoc/>
		public abstract void Clear();

		/// <inheritdoc/>
		public abstract void Replace([AllowNull] TElement search, [AllowNull] TElement replace);

		/// <summary>
		/// Postpends the <paramref name="element"/> onto this node.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		/// <returns>The node that was postpended.</returns>
		[return: NotNull]
		public abstract TSelf Postpend([AllowNull] TElement element);

		/// <summary>
		/// Prepends the <paramref name="element"/> onto this node.
		/// </summary>
		/// <param name="element">The element to prepend.</param>
		/// <returns>The node that was prepended.</returns>
		[return: NotNull]
		public abstract TSelf Prepend([AllowNull] TElement element);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();
	}
}
