using System;
using System.Diagnostics.CodeAnalysis;
using Philosoft;
using Collectathon.Filters;
using Defender;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <seealso cref="DynamicArray{TIndex, TElement}"/>.
	[Serializable]
	public sealed class DynamicArray<TElement> : FlexibleArray<TElement, DynamicArray<TElement>>, IResizable {
		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		public DynamicArray(nint capacity) : base(capacity, Filter.None) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The filter type to use.</param>
		public DynamicArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The set of elements.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filter">The filter type to use.</param>
		private DynamicArray(Memory<TElement> elements, nint length, Filter<TElement> filter) : base(elements, length, filter) { }

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator DynamicArray<TElement>(TElement[] array) => !(array is null) ? new DynamicArray<TElement>(array, array.Length, NullFilter<TElement>.Instance) : new DynamicArray<TElement>(0);

		/// <summary>
		/// Converts the <paramref name="memory"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> to convert.</param>
		[SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "There is an alternative: one of the constructors.")]
		public static implicit operator DynamicArray<TElement>(Memory<TElement> memory
			) => new DynamicArray<TElement>(memory, memory.Length, NullFilter<TElement>.Instance);

		/// <inheritdoc/>
		protected override void Add(TElement element) {
			if (Length == Capacity) {
				this.Grow();
			}
			base.Add(element);
		}

		/// <inheritdoc/>
		protected override DynamicArray<TElement> Clone() => new DynamicArray<TElement>(Elements.Clone(), Length, Filterer.Clone());

		/// <inheritdoc/>
		protected override void Insert(nint index, TElement element) {
			Guard.GreaterThanOrEqual(index, nameof(index), 0);
			if (Length + 1 >= Capacity) {
				this.Grow();
			}
			base.Insert(index, element);
		}

		/// <inheritdoc/>
		private void Resize(nint capacity) {
			Guard.GreaterThanOrEqual(capacity, nameof(capacity), Length);
			TElement[] newBuffer = new TElement[capacity];
			Elements.CopyTo(newBuffer);
			Elements = newBuffer;
		}

		/// <inheritdoc/>
		void IResizable.Resize(nint capacity) => Resize(capacity);
	}
}
