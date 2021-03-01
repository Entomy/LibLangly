using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Represents an associative Chain, a type of highly sophisticated List.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index of the elements.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the chain.</typeparam>
	/// <remarks>
	/// A chain is a hybrid list, employing various optimizations from partial-unrolling to skip-linkage, to reference slicing.
	/// </remarks>
	public sealed partial class Chain<TIndex, TElement> : DataStructure<TIndex, TElement, Chain<TIndex, TElement>, Chain<TIndex, TElement>.Enumerator>,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement, Chain<TIndex, TElement>>,
		IReplace<TElement, Chain<TIndex, TElement>> {
		/// <summary>
		/// The head node of the chain.
		/// </summary>
		[MaybeNull, AllowNull]
		private Node Head;

		/// <summary>
		/// The tail node of the chain.
		/// </summary>
		[MaybeNull, AllowNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Chain{TIndex, TElement}"/>.
		/// </summary>
		public Chain() : this(DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="Chain{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="filter">Flags designating which filters to set up.</param>
		public Chain(Filter filter) : base(filter) {
			Head = null;
			Tail = null;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				foreach ((TIndex Index, TElement Element) member in this) {
					if (member.Index!.Equals(index)) {
						return member.Element;
					}
				}
				return Filter.IndexOutOfBounds(this, index);
			}
			set => throw new NotImplementedException();
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TIndex, TElement> IInsert<TIndex, TElement, Chain<TIndex, TElement>>.Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			Boolean inserted = false;
			Node N = Head;
			Node head = null;
			Node tail = null;
			// Go through the existing members
			while (N is not null) {
				// Try inserting the element into an existing index
				(inserted, head, tail) = N.Insert(index, element);
				// If an insertion did happen, we need to do some node relinking
				if (inserted) {
					break;
				}
				N = N.Next;
			}
			// If the index was not already present
			if (!inserted) {
				// Add it through a postpend
				Tail = new ElementNode(index, element, previous: Tail, next: null);
				if (Head is null) {
					Head = Tail;
				} else {
					Tail.Previous.Next = Tail;
				}
			}
			// Increment the count
			Count++;
			// We're done
			return this;
		}

		/// <inheritdoc/>
		Chain<TIndex, TElement> IReplace<TElement, TElement, Chain<TIndex, TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			Node N = Head;
			while (N is not null) {
				_ = N.Replace(search, replace);
			}
			return this;
		}
	}
}
