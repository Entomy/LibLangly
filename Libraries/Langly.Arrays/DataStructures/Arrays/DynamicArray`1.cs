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
		/// An empty <see cref="DynamicArray{TElement}"/> singleton.
		/// </summary>
		[NotNull]
		public static DynamicArray<TElement> Empty => Singleton.Instance;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(nint capacity) : base(capacity, 0, DataStructures.Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public DynamicArray(nint capacity, Filter filter) : base(capacity, 0, filter) { }

		/// <summary>
		/// Conversion constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to reuse.</param>
		private DynamicArray(Memory<TElement> memory) : base(memory, memory.Length, DataStructures.Filter.None) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to reuse.</param>
		/// <param name="count">The amount of elements in this array.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		private DynamicArray(Memory<TElement> memory, nint count, [DisallowNull] Filter<nint, TElement> filter) : base(memory, count, filter) { }

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
		public static implicit operator DynamicArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : Empty;

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to convert.</param>
		[return: NotNull]
		public static implicit operator DynamicArray<TElement>(Memory<TElement> memory) => new(memory);

		/// <inheritdoc/>
		[return: NotNull]
		DynamicArray<TElement> IResize<DynamicArray<TElement>>.Resize(nint capacity) {
			TElement[] newBuffer = new TElement[capacity];
			Memory.CopyTo(newBuffer);
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

		private static class Singleton {
			static Singleton() { }

			[DisallowNull, NotNull]
			internal static readonly DynamicArray<TElement> Instance = new DynamicArray<TElement>(0);
		}
	}
}
