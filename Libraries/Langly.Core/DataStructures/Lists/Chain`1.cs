using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	/// <summary>
	/// Represents a Chain, a type of highly sophisticated List.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the chain.</typeparam>
	/// <remarks>
	/// A chain is a hybrid list, employing various optimizations from partial-unrolling to skip-linkage, to reference slicing.
	/// </remarks>
	public sealed partial class Chain<TElement> : DataStructure<TElement, Chain<TElement>, Chain<TElement>.Enumerator>,
		IAdd<TElement> {
		/// <summary>
		/// The head node of the chain.
		/// </summary>
		[AllowNull]
		private Node Head;

		/// <summary>
		/// The tail node of the chain.
		/// </summary>
		[AllowNull]
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Chain{TElement}"/>.
		/// </summary>
		public Chain() {
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Intializes a new <see cref="Chain{TElement}"/> with the initial <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The initial element.</param>
		internal Chain(TElement element) {
			Head = new ElementNode(element, previous: null, next: null);
			Tail = Head;
			Count = 1;
		}

		/// <inheritdoc/>
		void IAdd<TElement>.Add([AllowNull] TElement element) {
			if (element is null) {
				return;
			}
			Tail = new ElementNode(element, previous: Tail, next: null);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Count++;
		}

		/// <inheritdoc/>
		void IAdd<TElement>.Add(ReadOnlyMemory<TElement> elements) {
			Tail = new MemoryNode(elements, previous: Tail, next: null);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Count += elements.Length;
		}
	}
}
