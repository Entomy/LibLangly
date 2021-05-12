using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	public sealed class BoundedArray<TElement> : FlexibleArray<TElement, BoundedArray<TElement>> {
		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(nint capacity) : this(capacity, Filters.None) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		public BoundedArray(nint capacity, Filters filter) : base(capacity, 0, filter) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/>
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public BoundedArray([DisallowNull] TElement[] memory) : base(memory, memory.Length, Filters.None) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator BoundedArray<TElement>([AllowNull] TElement[] array) => array is not null ? new(array) : null;

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Insert(nint index, [AllowNull] TElement element) {
			if (Count < Capacity) {
				base.Insert(index, element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Insert(nint index, ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length <= Capacity) {
				base.Insert(index, elements);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Postpend([AllowNull] TElement element) {
			if (Count < Capacity) {
				base.Postpend(element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Postpend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length <= Capacity) {
				base.Postpend(elements);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Prepend([AllowNull] TElement element) {
			if (Count < Capacity) {
				base.Prepend(element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public override void Prepend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length <= Capacity) {
				base.Prepend(elements);
			} else {
				throw new InvalidOperationException();
			}
		}
	}
}
