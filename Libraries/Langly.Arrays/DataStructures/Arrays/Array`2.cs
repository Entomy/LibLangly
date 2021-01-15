using Langly.DataStructures.Filters;
using Langly.DataStructures.Lists;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents any array type.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1.
	/// </remarks>
	public abstract partial class Array<TElement, TSelf> : DataStructure<TElement, TSelf, Array<TElement, TSelf>.Enumerator>,
		IAdd<TElement, Chain<TElement>>,
		IConcat<TElement, Chain<TElement>>,
		IIndexReadOnly<TElement>,
		IInsert<TElement, Chain<TElement>>,
		IReplace<TElement, Chain<TElement>>,
		ISlice<TSelf>
		where TSelf : Array<TElement, TSelf> {
		/// <summary>
		/// The set of elements.
		/// </summary>
		protected ReadOnlyMemory<TElement> Elements;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">Flags designating which filters to set up.</param>
		protected Array(nint capacity, Filter filter) : base(filter) => Elements = new TElement[capacity];

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">Flags designated which filters to set up.</param>
		protected Array(ReadOnlyMemory<TElement> elements, Filter filter) : base(filter) => Elements = elements;

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected Array(ReadOnlyMemory<TElement> elements, Filter<nint, TElement> filter) : base(filter) => Elements = elements;

		/// <summary>
		/// The current capacity of the array; how many elements it can hold.
		/// </summary>
		public nint Capacity => Elements.Length;

		/// <inheritdoc/>
		public override nint Count => Elements.Length;

		/// <inheritdoc/>
		[MaybeNull]
		public TElement this[nint index] {
			get {
				if (0 > index || index >= Count) {
					return Filter.IndexOutOfBounds(this, index);
				}
				return Elements.Span[(Int32)index];
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add([AllowNull] TElement element) => new Chain<TElement>(Filter).Add(Elements).Add(element);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add(ReadOnlyMemory<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Add(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add(ReadOnlySpan<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Add(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IAdd<TElement, Chain<TElement>>.Add<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) => new Chain<TElement>(Filter).Add(Elements).Add(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<nint, TElement, Chain<TElement>>.Insert(nint index, [AllowNull] TElement element) => new Chain<TElement>(Filter).Add(Elements).Insert(index, element);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<TElement, Chain<TElement>>.Insert(nint index, ReadOnlyMemory<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Insert(index, elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<TElement, Chain<TElement>>.Insert(nint index, ReadOnlySpan<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Insert(index, elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IInsert<TElement, Chain<TElement>>.Insert<TEnumerator>(nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) => new Chain<TElement>(Filter).Add(Elements).Insert(index, elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend([AllowNull] TElement element) => new Chain<TElement>(Filter).Add(Elements).Postpend(element);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend([AllowNull] TElement element) => new Chain<TElement>(Filter).Add(Elements).Prepend(element);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IReplace<TElement, TElement, Chain<TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) => new Chain<TElement>(Filter).Add(Elements).Replace(search, replace);

		/// <inheritdoc/>
		[return: NotNull]
		TSelf ISlice<TSelf>.Slice(nint start, nint length) => Slice(start, length);

		/// <summary>
		/// The actual implementation of <see cref="ISlice{TSlice}.Slice(nint, nint)"/>.
		/// </summary>
		/// <param name="start">The index at which to begin the slice.</param>
		/// <param name="length">The desired length for the slice.</param>
		protected abstract TSelf Slice(nint start, nint length);
	}
}
