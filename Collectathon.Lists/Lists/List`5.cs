using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Nodes;
using Langly;

namespace Collectathon.Lists {
	/// <summary>
	/// Represents any associative linked list.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the list.</typeparam>
	/// <typeparam name="TNode">The type of the nodes of the list.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for the list.</typeparam>
	[DebuggerDisplay("{ToString(5), nq}")]
	public abstract class List<TIndex, TElement, TNode, TSelf, TEnumerator> :
		IClear,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement>,
		ISequence<(TIndex Index, TElement Element), TEnumerator>
		where TNode : ListNode<TIndex, TElement, TNode>
		where TSelf : List<TIndex, TElement, TNode, TSelf, TEnumerator>
		where TEnumerator : struct, IEnumerator<(TIndex Index, TElement Element)> {
		/// <summary>
		/// The <see cref="Filter{TIndex, TElement}"/> being used.
		/// </summary>
		/// <remarks>
		/// This is never <see langword="null"/>; a sentinel is used by default.
		/// </remarks>
		[NotNull, DisallowNull]
		protected readonly Filter<TIndex, TElement> Filter;

		/// <summary>
		/// The head node of the list; the first element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected TNode Head;

		/// <summary>
		/// The tail node of the list; the second element.
		/// </summary>
		[AllowNull, MaybeNull]
		protected TNode Tail;

		/// <summary>
		/// Initializes a new <see cref="List{TIndex, TElement, TNode, TSelf, TEnumerator}"/>.
		/// </summary>
		/// <param name="filter">The type of filter to use.</param>
		protected List(Filters filter) => Filter = Filter<TIndex, TElement>.Create(filter);

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected List([DisallowNull] Filter<TIndex, TElement> filter) => Filter = filter;

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public abstract TElement this[[DisallowNull] TIndex index] { get; set; }

		/// <inheritdoc/>
		public void Clear() {
			TNode P = null!;
			TNode? N = Head;
			while (N is not null) {
				P = N;
				N = N.Next;
				P.Clear();
			}
			Head = null;
			Tail = null;
			Count = 0;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public abstract TEnumerator GetEnumerator();

		/// <inheritdoc/>
		System.Collections.Generic.IEnumerator<(TIndex Index, TElement Element)> System.Collections.Generic.IEnumerable<(TIndex Index, TElement Element)>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		public void Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count > 0) {
				Tail!.Next = Tail!.Postpend(index, element);
				Tail = Tail.Next;
			} else {
				Head = NewUnlinkedNode(index, element);
				Tail = Head;
			}
			Count++;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => Collection.ToString(this);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(this, amount);

		/// <summary>
		/// Creates a new, unlinked, node.
		/// </summary>
		/// <param name="index">The index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to put into the node.</param>
		/// <returns>A node containing the <paramref name="element"/> with no links to other nodes.</returns>
		[return: NotNull]
		protected abstract TNode NewUnlinkedNode([DisallowNull] TIndex index, [AllowNull] TElement element);
	}
}
