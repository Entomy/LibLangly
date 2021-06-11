using System.Diagnostics.CodeAnalysis;
using Collectathon.Nodes;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents a singly-linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	public sealed class SinglyLinkedList<TIndex, TElement> : StandardList<TIndex, TElement, SinglyLinkedListNode<TIndex, TElement>, SinglyLinkedList<TIndex, TElement>> {
		/// <summary>
		/// initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		public SinglyLinkedList() : base(Filters.None) { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/> witht he given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		public SinglyLinkedList([DisallowNull] (TIndex Index, TElement Element)[] entries) : base(entries, Filters.None) { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/> witht he given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		/// <param name="filter">The type of filter to use.</param>
		public SinglyLinkedList([DisallowNull] (TIndex Index, TElement Element)[] entries, Filters filter) : base(entries, filter) { }

		/// <summary>
		/// Initializes a new <see cref="SinglyLinkedList{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="filter">The type of filter to use.</param>
		public SinglyLinkedList(Filters filter) : base(filter) { }

		/// <summary>
		/// Converts the <paramref name="entries"/> to a <see cref="SinglyLinkedList{TElement}"/>.
		/// </summary>
		/// <param name="entries">The entries to convert to a list.</param>
		[return: MaybeNull, NotNullIfNotNull("elements")]

		public static implicit operator SinglyLinkedList<TIndex, TElement>([AllowNull] (TIndex Index, TElement Element)[] entries) => entries is not null ? new(entries) : null;

		/// <inheritdoc/>
		[return: NotNull]
		protected override SinglyLinkedListNode<TIndex, TElement> NewUnlinkedNode([DisallowNull] TIndex index, [AllowNull] TElement element) => new SinglyLinkedListNode<TIndex, TElement>(index, element, next: null);
	}
}
