using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Represents the base node type of any associative data structure.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the nodes.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class Node<TIndex, TElement, TSelf> : Record<TSelf>,
		IContains<TElement>,
		IReplace<TElement, TSelf>
		where TSelf : Node<TIndex, TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="Node{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="index">The index of this node.</param>
		/// <param name="element">The element of this node.</param>
		protected Node([AllowNull] TIndex index, [AllowNull] TElement element) {
			Index = index;
			Element = element;
		}

		/// <summary>
		/// The element of this node.
		/// </summary>
		[AllowNull, MaybeNull]
		public TElement Element { get; set; }

		/// <summary>
		/// The index of this node.
		/// </summary>
		[AllowNull, MaybeNull]
		public TIndex Index { get; set; }

		/// <inheritdoc/>
		public abstract Boolean Contains([AllowNull] TElement element);

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] TSelf other) =>
			other is not null
			&& ((Index is null && other.Index is null) || (Index?.Equals(other.Index) ?? false))
			&& ((Element is null && other.Element is null) || (Element?.Equals(other.Element) ?? false));

		/// <inheritdoc/>
		[return: NotNull]
		public abstract TSelf Replace([AllowNull] TElement search, [AllowNull] TElement replace);

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => $"{Index}:{Element}";
	}
}
