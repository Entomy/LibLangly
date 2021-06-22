using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class DynamicArray<TElement> : FlexibleArray<TElement, DynamicArray<TElement>>, IResize {
		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		public DynamicArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(Int32 capacity) : base(capacity, 0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public DynamicArray([DisallowNull] TElement[] memory) : base(memory, memory.Length) { }

		/// <inheritdoc/>
		new public Int32 Capacity {
			get => base.Capacity;
			set => Resize(value);
		}

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator DynamicArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : null;

		/// <inheritdoc/>
		public override void Insert(Int32 index, [AllowNull] TElement element) {
			if (Count == Capacity) {
				Memory = Collection.Grow(Memory);
			}
			base.Insert(index, element);
		}

		/// <inheritdoc/>
		public override void Insert(Int32 index, ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Memory = Collection.Grow(Memory, Capacity + elements.Length);
			}
			base.Insert(index, elements);
		}

		/// <inheritdoc/>
		public override void Postpend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Memory = Collection.Grow(Memory);
			}
			base.Postpend(element);
		}

		/// <inheritdoc/>
		public override void Postpend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Memory = Collection.Grow(Memory, Capacity + elements.Length);
			}
			base.Postpend(elements);
		}

		/// <inheritdoc/>
		public override void Prepend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Memory = Collection.Grow(Memory);
			}
			base.Prepend(element);
		}

		/// <inheritdoc/>
		public override void Prepend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Memory = Collection.Grow(Memory, Capacity + elements.Length);
			}
			base.Prepend(elements);
		}

		/// <inheritdoc/>
		public void Resize(Int32 capacity) => Memory = Collection.Resize(Memory, capacity);
	}
}
