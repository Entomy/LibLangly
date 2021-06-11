using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Stacks;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="Stack{TElement}"/>.
	/// </summary>
	public sealed class StackNode<TElement> : IContains<TElement>, IElement<TElement>, INext<StackNode<TElement>>, IUnlink {
		/// <summary>
		/// Initializes a new <see cref="StackNode{TElement}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node of the stack.</param>
		public StackNode([AllowNull] TElement element, [AllowNull] StackNode<TElement> next) {
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement Element { get; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public StackNode<TElement> Next { get; private set; }

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Equals(Element, element);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Element?.ToString() ?? "null";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
