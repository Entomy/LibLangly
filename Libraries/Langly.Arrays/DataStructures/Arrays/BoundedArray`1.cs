using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents a bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class BoundedArray<TElement> : FlexibleArray<TElement, BoundedArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(nint capacity) : base(capacity, 0, DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public BoundedArray(nint capacity, Filter filter) : base(capacity, 0, filter) { }

		/// <summary>
		/// Conversion constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to reuse.</param>
		private BoundedArray(Memory<TElement> memory) : base(memory, memory.Length, DataStructures.Filter.None) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to reuse.</param>
		/// <param name="count">The amount of elements in this array.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		private BoundedArray(Memory<TElement> memory, nint count, [DisallowNull] Filter<nint, TElement> filter) : base(memory, count, filter) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: NotNull]
		public static implicit operator BoundedArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : new(Memory<TElement>.Empty);

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to convert.</param>
		[return: NotNull]
		public static implicit operator BoundedArray<TElement>(Memory<TElement> memory) => new(memory);

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Insert(nint index, [AllowNull] TElement element) => Count < Capacity ? base.Insert(index, element) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Postpend([AllowNull] TElement element) => Count < Capacity ? base.Postpend(element) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Prepend([AllowNull] TElement element) => Count < Capacity ? base.Prepend(element) : null;
	}
}
