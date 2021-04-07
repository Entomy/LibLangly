using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;
using Langly.Traits;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class DynamicArray<TElement> : FlexibleArray<TElement, DynamicArray<TElement>>, IResize<DynamicArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		public DynamicArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(nint capacity) : this(capacity, DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public DynamicArray(nint capacity, Filter filter) : base(capacity, 0, filter) { }

		/// <summary>
		/// Conversion constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		private DynamicArray([DisallowNull] TElement[] memory) : base(memory, memory.Length, DataStructures.Filter.None) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		/// <param name="count">The amount of elements in this array.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		private DynamicArray([DisallowNull] TElement[] memory, nint count, [DisallowNull] Filter<nint, TElement> filter) : base(memory, count, filter) { }

		/// <inheritdoc/>
		new public nint Capacity {
			get => base.Capacity;
			set => ((IResize<DynamicArray<TElement>>)this).Resize(value);
		}

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: NotNull]
		public static implicit operator DynamicArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : new();

		/// <inheritdoc/>
		[return: NotNull]
		DynamicArray<TElement> IResize<DynamicArray<TElement>>.Resize(nint capacity) {
			TElement[] newBuffer = new TElement[capacity];
			Array.Copy(Memory, newBuffer, (Int32)Count);
			Memory = newBuffer;
			return this;
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override DynamicArray<TElement> Insert(nint index, [AllowNull] TElement element) => base.Insert(index, element);

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override DynamicArray<TElement> Postpend([AllowNull] TElement element) {
			if (Count == Capacity) {
				((IResize<DynamicArray<TElement>>)this).Grow();
			}
			return base.Postpend(element);
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		protected override DynamicArray<TElement> Prepend([AllowNull] TElement element) {
			if (Count == Capacity) {
				((IResize<DynamicArray<TElement>>)this).Grow();
			}
			return base.Prepend(element);
		}
	}
}
