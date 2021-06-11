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
		IContains<TElement>,
		ICount,
		INext<TSelf>,
		IReplace<TElement>,
		IUnlink
		where TSelf : ListNode<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="ListNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="next">The next node in the list.</param>
		protected ListNode([AllowNull] TSelf next) => Next = next;

		/// <inheritdoc/>
		public abstract nint Count { get; }

		/// <summary>
		/// The next node in the list.
		/// </summary>
		[AllowNull, MaybeNull]
		public TSelf Next { get; set; }

		/// <inheritdoc/>
		public abstract Boolean Contains([AllowNull] TElement element);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

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
		public abstract void Replace([AllowNull] TElement search, [AllowNull] TElement replace);

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();

		/// <inheritdoc/>
		public abstract void Unlink();
	}
}
