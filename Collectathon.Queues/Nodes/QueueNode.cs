using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Queues;

namespace Collectathon.Nodes {
	/// <summary>
	/// Represents a node of a <see cref="Queue{TElement}"/>.
	/// </summary>
	public sealed class QueueNode<TElement> : IContains<TElement>, IElement<TElement>, INext<QueueNode<TElement>>, IUnlink {
		/// <summary>
		/// Initializes a new <see cref="QueueNode{TElement}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		public QueueNode([AllowNull] TElement element) : this(element, null) { }

		/// <summary>
		/// Initializes a new <see cref="QueueNode{TElement}"/>.
		/// </summary>
		/// <param name="element">The element contained in this node.</param>
		/// <param name="next">The next node of the queue.</param>
		public QueueNode([AllowNull] TElement element, [AllowNull] QueueNode<TElement> next) {
			Element = element;
			Next = next;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement Element { get; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public QueueNode<TElement> Next { get; set; }

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Equals(Element, element);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Element?.ToString() ?? "null";

		/// <inheritdoc/>
		public void Unlink() => Next = null;
	}
}
