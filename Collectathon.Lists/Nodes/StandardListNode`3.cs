using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="StandardList{TIndex, TElement, TNode, TSelf}"/> node.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the nodes.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class StandardListNode<TIndex, TElement, TSelf> : ListNode<TIndex, TElement, TSelf>,
		IReplace<TElement>
		where TSelf : StandardListNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="StandardListNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		protected StandardListNode([DisallowNull] TIndex index, [AllowNull] TElement element, [AllowNull] TSelf next) : base(next) {
			Index = index;
			Element = element;
		}

		/// <inheritdoc/>
		public override nint Count => 1;

		/// <summary>
		/// The index of the <see	cref="Element"/>.
		/// </summary>
		[AllowNull, MaybeNull]
		public TIndex Index { get; set; }

		/// <summary>
		/// The element contained in this node.
		/// </summary>
		[AllowNull, MaybeNull]
		public TElement Element { get; set; }

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Element?.ToString() ?? "";
	}
}
