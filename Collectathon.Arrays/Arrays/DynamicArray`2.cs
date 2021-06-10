using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents an associative dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the array.</typeparam>
	public sealed class DynamicArray<TIndex, TElement> : FlexibleArray<TIndex, TElement, DynamicArray<TIndex, TElement>>, IResize {
		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		public DynamicArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(nint capacity) : base(capacity, 0) { }

		/// <summary>
		/// Conversion constructor.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of (<typeparamref name="TIndex"/>, <typeparamref name="TElement"/>) to reuse.</param>
		public DynamicArray([DisallowNull] (TIndex, TElement)[] memory) : base(memory, memory.Length) { }

		/// <inheritdoc/>
		new public nint Capacity {
			get => base.Capacity;
			set => Resize(value);
		}

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator DynamicArray<TIndex, TElement>([AllowNull] (TIndex, TElement)[] array) => array is not null ? new(array) : null;

		/// <inheritdoc/>
		public void Resize(nint capacity) {
			(TIndex, TElement)[] newBuffer = new (TIndex, TElement)[capacity];
			Entries.AsMemory(0, (Int32)(capacity > Capacity ? Capacity : capacity)).CopyTo(newBuffer);
			Count = Count < capacity ? Count : capacity;
			Entries = newBuffer;
		}

		/// <inheritdoc/>
		protected override void Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count == Capacity) {
				this.Grow();
			}
			base.Add(index, element);
		}
	}
}
