using Langly.DataStructures.Filters;
using Langly.DataStructures.Lists;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents an array of contiguous elements.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1.
	/// </remarks>
	public sealed partial class Array<TElement> : DataStructure<TElement, Array<TElement>, Array<TElement>.Enumerator>,
		IAdd<TElement, Chain<TElement>>,
		IConcat<TElement, Chain<TElement>>,
		IIndexReadOnly<TElement>,
		IInsert<TElement, Chain<TElement>>,
		IReplace<TElement, Chain<TElement>>,
		ISlice<Array<TElement>> {
		/// <summary>
		/// The set of elements.
		/// </summary>
		private readonly ReadOnlyMemory<TElement> Elements;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public Array(nint capacity) : this(capacity, DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="capacity"/> and <paramref name="filter"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		/// <param name="filter">Flags designating which filters to set up.</param>
		public Array(nint capacity, Filter filter) : base(filter) => Elements = new TElement[capacity];

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">Flags designated which filters to set up.</param>
		public Array(ReadOnlyMemory<TElement> elements, Filter filter) : base(filter) => Elements = elements;

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		private Array(ReadOnlyMemory<TElement> elements, Filter<nint, TElement> filter) : base(filter) => Elements = elements;

		/// <summary>
		/// An empty <see cref="Array{TElement}"/> singleton.
		/// </summary>
		public static Array<TElement> Empty => Singleton.Instance;

		public static implicit operator Array<TElement>([AllowNull] TElement[] elements) => elements is not null ? new Array<TElement>(elements, DataStructures.Filter.None) : Empty;

		public static implicit operator Array<TElement>(Memory<TElement> elements) => new Array<TElement>(elements, DataStructures.Filter.None);

		public static implicit operator Array<TElement>(ReadOnlyMemory<TElement> elements) => new Array<TElement>(elements, DataStructures.Filter.None);

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
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend(ReadOnlyMemory<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Postpend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPostpend<TElement, Chain<TElement>>.Postpend(ReadOnlySpan<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Postpend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend([AllowNull] TElement element) => new Chain<TElement>(Filter).Add(Elements).Prepend(element);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend(ReadOnlyMemory<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Prepend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IPrepend<TElement, Chain<TElement>>.Prepend(ReadOnlySpan<TElement> elements) => new Chain<TElement>(Filter).Add(Elements).Prepend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		Chain<TElement> IReplace<TElement, TElement, Chain<TElement>>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) => new Chain<TElement>(Filter).Add(Elements).Replace(search, replace);

		/// <inheritdoc/>
		[return: NotNull]
		Array<TElement> ISlice<Array<TElement>>.Slice(nint start, nint length) => new Array<TElement>(Elements.Slice((Int32) start, (Int32) length), Filter);

		private static class Singleton {
			internal static readonly Array<TElement> Instance = new Array<TElement>(0);

			static Singleton() { }
		}
	}
}
