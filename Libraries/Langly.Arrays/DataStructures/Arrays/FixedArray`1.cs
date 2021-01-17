using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents a fixed array, a type of array whos size is always its initial capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class FixedArray<TElement> : Array<TElement, FixedArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="FixedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		public FixedArray(nint capacity) : base(capacity, DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="FixedArray{TElement}"/> with the given <paramref name="capacity"/> and <paramref name="filter"/>.
		/// </summary>
		/// <param name="capacity">The capacity.</param>
		/// <param name="filter">Flags designating which filters to set up.</param>
		public FixedArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">Flags designated which filters to set up.</param>
		public FixedArray(ReadOnlyMemory<TElement> elements, Filter filter) : base(elements, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The elements to use.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		private FixedArray(ReadOnlyMemory<TElement> elements, Filter<nint, TElement> filter) : base(elements, filter) { }

		/// <summary>
		/// An empty <see cref="FixedArray{TElement}"/> singleton.
		/// </summary>
		public static FixedArray<TElement> Empty => Singleton.Instance;

		public static implicit operator FixedArray<TElement>(TElement[] elements) => elements is not null ? new FixedArray<TElement>(elements, DataStructures.Filter.None) : Empty;

		public static implicit operator FixedArray<TElement>(Memory<TElement> elements) => new FixedArray<TElement>(elements, DataStructures.Filter.None);

		public static implicit operator FixedArray<TElement>(ReadOnlyMemory<TElement> elements) => new FixedArray<TElement>(elements, DataStructures.Filter.None);

		/// <inheritdoc/>
		[return: NotNull]
		protected override FixedArray<TElement> Slice(nint start, nint length) => new FixedArray<TElement>(Elements.Slice((Int32)start, (Int32)length), Filter);

		private static class Singleton {
			internal static readonly FixedArray<TElement> Instance = new FixedArray<TElement>(0);

			static Singleton() { }
		}
	}
}
