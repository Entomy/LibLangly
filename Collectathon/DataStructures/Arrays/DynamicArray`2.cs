using System;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents an associative dynamic array, a type of flexible array that associates an element with an index, and who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the array.</typeparam>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <seealso cref="DynamicArray{TElement}"/>.
	public sealed class DynamicArray<TIndex, TElement> : FlexibleArray<TIndex, TElement, DynamicArray<TIndex, TElement>>, IResizable where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		public DynamicArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public DynamicArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="members">The set of elements.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private DynamicArray(Memory<Association<TIndex, TElement>> members, nint length, Filter<TElement> filterer) : base(members, length, filterer) { }

		/// <inheritdoc/>
		protected override void Add(TIndex index, TElement element) {
			if (Length == Capacity) {
				this.Grow();
			}
			base.Add(index, element);
		}

		/// <inheritdoc/>
		protected override DynamicArray<TIndex, TElement> Clone() => new DynamicArray<TIndex, TElement>(Members.Clone(), Length, Filterer.Clone());

		/// <inheritdoc/>
		void IResizable.Resize(nint capacity) {
			Guard.GreaterThanOrEqual(capacity, nameof(capacity), Length);
			Memory<Association<TIndex, TElement>> newBuffer = new Association<TIndex, TElement>[capacity];
			Members.CopyTo(newBuffer);
			Members = newBuffer;
		}
	}
}
