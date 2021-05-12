using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents an associative bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	public sealed class BoundedArray<TIndex, TElement> : FlexibleArray<TIndex, TElement, BoundedArray<TIndex, TElement>> {
		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/>.
		/// </summary>
		public BoundedArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity"></param>
		public BoundedArray(nint capacity) : base(capacity, 0) { }

		/// <summary>
		/// Conversion constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of (<typeparamref name="TIndex"/>, <typeparamref name="TElement"/>) to reuse.</param>
		public BoundedArray([DisallowNull] (TIndex, TElement)[] memory) : base(memory, memory.Length) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator BoundedArray<TIndex, TElement>([AllowNull] (TIndex, TElement)[] array) => array is not null ? new(array) : null;

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		protected override void Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count < Capacity) {
				base.Add(index, element);
			} else {
				throw new InvalidOperationException();
			}
		}
	}
}
