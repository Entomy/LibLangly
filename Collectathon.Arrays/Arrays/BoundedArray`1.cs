using System;
using System.Diagnostics.CodeAnalysis;
using Langly;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class BoundedArray<TElement> : FlexibleArray<TElement, BoundedArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		public BoundedArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(nint capacity) : this(capacity, FilterType.None) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public BoundedArray(nint capacity, FilterType filter) : base(capacity, 0, filter) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/>
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public BoundedArray([DisallowNull] TElement[] memory) : base(memory, memory.Length, FilterType.None) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator BoundedArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Insert(nint index, [AllowNull] TElement element) => Count < Capacity ? base.Insert(index, element) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Postpend([AllowNull] TElement element) => Count < Capacity ? base.Postpend(element) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Postpend(ReadOnlyMemory<TElement> elements) => Count + elements.Length < Capacity ? base.Postpend(elements) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Prepend([AllowNull] TElement element) => Count < Capacity ? base.Prepend(element) : null;

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override BoundedArray<TElement> Prepend(ReadOnlyMemory<TElement> elements) => Count + elements.Length < Capacity ? base.Prepend(elements) : null;
	}
}
