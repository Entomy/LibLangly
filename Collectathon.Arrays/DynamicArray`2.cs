using System;
using System.Diagnostics;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;
using Collectathon.Enumerators;

namespace Collectathon {
	/// <summary>
	/// Represents an associative dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class DynamicArray<TIndex, TElement> :
		IArray<TIndex, TElement>,
		IClear,
		IInsert<TIndex, TElement>,
		IResize,
		ISequence<(TIndex Index, TElement Element), ArrayEnumerator<TIndex, TElement>>
		where TIndex : notnull {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The indicies of this <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		private TIndex[] Indicies;

		/// <summary>
		/// The elements of this <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		private TElement[] Elements;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		public DynamicArray() {
			Indicies = Array.Empty<TIndex>();
			Elements = Array.Empty<TElement>();
		}

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(Int32 capacity) {
			Indicies = new TIndex[capacity];
			Elements = new TElement[capacity];
		}

		/// <inheritdoc/>
		public Int32 Capacity {
			get => Indicies.Length;
			set => Resize(value);
		}

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		public TElement this[TIndex index] {
			get {
				for (Int32 i = 0; i < Count; i++) {
					if (Equals(Indicies[i], index)) {
						return Elements[i];
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				for (Int32 i = 0; i < Count; i++) {
					if (Equals(Indicies[i], index)) {
						Elements[i] = value;
						return;
					}
				}
				Add(index, value);
			}
		}

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Collection.Contains(Elements, Count, element);

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => Collection.Contains(Elements, Count, predicate);

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case DynamicArray<TIndex, TElement> array:
				return Equals(array);
			case (TIndex, TElement)[] array:
				return Equals(array);
			case ArraySegment<(TIndex, TElement)> segment:
				return Equals(segment);
			case Memory<(TIndex, TElement)> memory:
				return Equals(memory);
			case ReadOnlyMemory<(TIndex, TElement)> memory:
				return Equals(memory);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(DynamicArray<TIndex, TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(params (TIndex Index, TElement Element)[]? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ArraySegment<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Memory<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlyMemory<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Span<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlySpan<(TIndex Index, TElement Element)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public ArrayEnumerator<TIndex, TElement> GetEnumerator() => new ArrayEnumerator<TIndex, TElement>(Indicies, Elements, Count);

		/// <inheritdoc/>
		public void Insert(TIndex index, TElement element) {
			for (Int32 i = 0; i < Count; i++) {
				if (Equals(Indicies[i], index)) {
					return;
				}
			}
			Add(index, element);
		}

		/// <inheritdoc/>
		public void Replace(TElement search, TElement replace) => Collection.Replace(Elements, Count, search, replace);

		/// <inheritdoc/>
		public void Resize(Int32 capacity) {
			Indicies = Collection.Resize(Indicies, capacity);
			Elements = Collection.Resize(Elements, capacity);
		}

		/// <inheritdoc/>
		public override String ToString() => Collection.ToString(Indicies, Elements);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(Indicies, Elements, amount);

		/// <inheritdoc/>
		private void Add(TIndex index, TElement element) {
			if (Count == Capacity) {
				Grow();
			}
			Indicies[Count] = index;
			Elements[Count] = element;
			Count++;
		}

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		private void Grow() {
			if (Capacity >= 8) {
				Resize((Int32)(Capacity * φ));
			} else {
				Resize(13);
			}
		}
	}
}
