using System;
using Collectathon.Filters;
using Langly;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents an associative fixed array, a type of array whos size is always its initial capacity.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the array.</typeparam>
	/// <seealso cref="FixedArray{TElement}"/>
	[Serializable]
	public sealed class FixedArray<TIndex, TElement> : Array<TIndex, TElement, FixedArray<TIndex, TElement>> where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// Initializes a new <see cref="FixedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public FixedArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Intializes a new <see cref="FixedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public FixedArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="members">The set of members.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		private FixedArray(Memory<Association<TIndex, TElement>> members, nint length, Filter<TElement> filterer) : base(members, length, filterer) { }

		/// <inheritdoc/>
		protected override FixedArray<TIndex, TElement> Clone() => new FixedArray<TIndex, TElement>(Members.Clone(), Length, Filterer.Clone());
	}
}
