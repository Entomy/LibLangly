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
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

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
				Grow();
			}
			base.Add(index, element);
		}

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		private void Grow() {
			if (Capacity >= 8) {
				Resize((nint)(Capacity * φ));
			} else {
				Resize(13);
			}
		}

		/// <summary>
		/// Grows this collection by a computed factor, to at least a specified <paramref name="minimum"/>.
		/// </summary>
		/// <param name="minimum">The minimum allowed size.</param>
		private void Grow(nint minimum) {
			Double size = Capacity;
			while (size < minimum) {
				size += 4.0;
				size *= φ;
			}
			Resize((nint)size);
		}
	}
}
