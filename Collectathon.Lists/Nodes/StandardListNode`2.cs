using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Lists;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents any <see cref="StandardList{TElement, TNode, TSelf}"/> node.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the nodes.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract class StandardListNode<TElement, TSelf> : ListNode<TElement, TSelf>
		where TSelf : StandardListNode<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="StandardListNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node in the list.</param>
		protected StandardListNode([AllowNull] TElement element, [AllowNull] TSelf next) {
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		public override nint Count => 1;

		/// <summary>
		/// The element contained in this node.
		/// </summary>
		[AllowNull, MaybeNull]
		public TElement Element { get; set; }

		/// <inheritdoc/>
		public override void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Element = !Equals(Element, search) ? Element : replace;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Element?.ToString() ?? "";
	}
}
