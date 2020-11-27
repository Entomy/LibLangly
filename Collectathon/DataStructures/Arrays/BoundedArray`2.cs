using System;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents an associative bounded array, a type of flexible array that associates an element with an index, and who's size can not grow above it's capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the array.</typeparam>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <see cref="BoundedArray{TElement}"/>
	[Serializable]
	public sealed class BoundedArray<TIndex, TElement> : FlexibleArray<TIndex, TElement, BoundedArray<TIndex, TElement>> where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public BoundedArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="members">The set of elements.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private BoundedArray(Memory<Association<TIndex, TElement>> members, nint length, Filter<TElement> filterer) : base(members, length, filterer) { }

		/// <inheritdoc/>
		protected override void Add(TIndex index, TElement element) {
			if (Length == Capacity) {
				throw CollectionExceededCapacityException.With(Capacity);
			}
			base.Add(index, element);
		}

		/// <inheritdoc/>
		protected override BoundedArray<TIndex, TElement> Clone() => new BoundedArray<TIndex, TElement>(Members.Clone(), Length, Filterer.Clone());
	}
}
