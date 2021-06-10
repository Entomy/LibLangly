﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="List{TIndex, TElement, TNode, TSelf, TEnumerator}"/> node.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the nodes.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class ListNode<TIndex, TElement, TSelf> :
		IClear,
		ICount
		where TSelf : ListNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="ListNode{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="next">The next node in the list.</param>
		protected ListNode([AllowNull] TSelf next) => Next = next;

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
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Postpends the <paramref name="element"/> onto this node.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>The node that was postpended.</returns>
		public abstract TSelf Postpend([DisallowNull] TIndex index, [AllowNull] TElement element);

		/// <summary>
		/// Prepends the <paramref name="element"/> onto this node.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>The node that was prepended.</returns>
		public abstract TSelf Prepend([DisallowNull] TIndex index, [AllowNull] TElement element);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();
	}
}