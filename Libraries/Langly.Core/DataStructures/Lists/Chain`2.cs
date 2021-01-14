using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public sealed partial class Chain<TIndex, TElement> : DataStructure<TIndex, TElement, Chain<TIndex, TElement>, Chain<TIndex, TElement>.Enumerator>,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement, Chain<TIndex, TElement>> {
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
		public Chain() {
			Head = null;
			Tail = null;
		}

		/// <inheritdoc/>
		public TElement this[TIndex index] {
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TIndex, TElement> IInsert<TIndex, TElement, Chain<TIndex, TElement>>.Insert(TIndex index, [AllowNull] TElement element) => throw new NotImplementedException();
	}
}
