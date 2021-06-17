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
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		public DynamicArray() : this(0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(nint capacity) : base(capacity, 0) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public DynamicArray([DisallowNull] TElement[] memory) : base(memory, memory.Length) { }

		/// <inheritdoc/>
		new public nint Capacity {
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
		public override void Insert(nint index, [AllowNull] TElement element) {
			if (Count == Capacity) {
				Grow();
			}
			base.Insert(index, element);
		}

		/// <inheritdoc/>
		public override void Insert(nint index, ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Grow(Capacity + elements.Length);
			}
			base.Insert(index, elements);
		}

		/// <inheritdoc/>
		public override void Postpend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Grow();
			}
			base.Postpend(element);
		}

		/// <inheritdoc/>
		public override void Postpend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Grow(Capacity + elements.Length);
			}
			base.Postpend(elements);
		}

		/// <inheritdoc/>
		public override void Prepend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Grow();
			}
			base.Prepend(element);
		}

		/// <inheritdoc/>
		public override void Prepend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Grow(Capacity + elements.Length);
			}
			base.Prepend(elements);
		}

		/// <inheritdoc/>
		public void Resize(nint capacity) {
			TElement[] newBuffer = new TElement[capacity];
			Memory.AsMemory(0, (Int32)(capacity > Capacity ? Capacity : capacity)).CopyTo(newBuffer);
			Count = Count < capacity ? Count : capacity;
			Memory = newBuffer;
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
