using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Enumerators;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class DynamicArray<TElement> :
		IAddSpan<TElement>,
		ICapacity,
		IClear,
		IContains<TElement>,
		IEquatable<DynamicArray<TElement>>,
		IIndex<Int32, TElement>,
		IInsertSpan<Int32, TElement>,
		IPostpendSpan<TElement>,
		IPrependSpan<TElement>,
		IRemove<TElement>,
		IReplace<TElement>,
		IResize,
		ISequence<TElement, ArrayEnumerator<TElement>>,
		IShift,
		ISlice<Memory<TElement?>> {
		/// <summary>
		/// The backing array of this <see cref="FlexibleArray{TElement, TSelf}"/>.
		/// </summary>
		[DisallowNull, NotNull]
		protected TElement?[] Elements;

		/// <summary>
		/// The amount of elements contained in this collection.
		/// </summary>
		private Int32 count;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		public DynamicArray() => Elements = Array.Empty<TElement>();

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(Int32 capacity) => Elements = new TElement?[capacity];

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public DynamicArray([DisallowNull] TElement[] elements) {
			Elements = elements;
			count = elements.Length;
		}

		/// <inheritdoc/>
		public Int32 Capacity {
			get => Elements.Length;
			set => Resize(value);
		}

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public Int32 Count {
			get => count;
			private set => count = value;
		}

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		[AllowNull, MaybeNull]
		public TElement this[Int32 index] {
			get => Elements[index];
			set => Elements[index] = value;
		}

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public Memory<TElement> this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Count);
				return ((ISlice<Memory<TElement>>)this).Slice(offset, length);
			}
		}
#endif

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator DynamicArray<TElement?>([AllowNull] TElement?[] array) => array is not null ? new(array) : null;

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="DynamicArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static DynamicArray<TElement> operator <<([AllowNull] DynamicArray<TElement> array, Int32 amount) {
			array?.ShiftLeft(amount);
			return array;
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="DynamicArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static DynamicArray<TElement> operator >>([AllowNull] DynamicArray<TElement> array, Int32 amount) {
			array?.ShiftRight(amount);
			return array;
		}
		/// <inheritdoc/>
		public void Add([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Add([AllowNull] params TElement?[] elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(ArraySegment<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(Memory<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(ReadOnlyMemory<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(Span<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Add(ReadOnlySpan<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		[O(Complexity.n), Ω(Complexity.n), Θ(Complexity.n)]
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Elements, Count, element);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case DynamicArray<TElement?> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] DynamicArray<TElement?> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] System.Collections.Generic.IEnumerable<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public ArrayEnumerator<TElement> GetEnumerator() => new ArrayEnumerator<TElement>(Elements, Count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public void Insert(Int32 index, [AllowNull] TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Insert(Elements, ref count, index, element);
		}

		/// <inheritdoc/>
		public void Insert(Int32 index, [AllowNull] params TElement?[] elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		public void Insert(Int32 index, ArraySegment<TElement?> elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		public void Insert(Int32 index, Memory<TElement?> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		public void Insert(Int32 index, ReadOnlyMemory<TElement?> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		public void Insert(Int32 index, Span<TElement?> elements) => Insert(index, (ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		public void Insert(Int32 index, ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Insert(Elements, ref count, index, elements);
		}

		/// <inheritdoc/>
		public void Postpend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Postpend(Elements, ref count, element);
		}

		/// <inheritdoc/>
		public void Postpend([AllowNull] params TElement?[] elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		public void Postpend(ArraySegment<TElement?> elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		public void Postpend(Memory<TElement?> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		public void Postpend(ReadOnlyMemory<TElement?> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		public void Postpend(Span<TElement?> elements) => Postpend((ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		public void Postpend(ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Postpend(Elements, ref count, elements);
		}

		/// <inheritdoc/>
		public void Prepend([AllowNull] TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Prepend(Elements, ref count, element);
		}

		/// <inheritdoc/>
		public void Prepend([AllowNull] params TElement?[] elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		public void Prepend(ArraySegment<TElement?> elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		public void Prepend(Memory<TElement?> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		public void Prepend(ReadOnlyMemory<TElement?> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		public void Prepend(Span<TElement?> elements) => Prepend((ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		public void Prepend(ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Prepend(Elements, ref count, elements);
		}

		/// <inheritdoc/>
		[O(Complexity.n_plus_k), Ω(Complexity.n_plus_k)]
		public void Remove([AllowNull] TElement element) => Collection.Remove(Elements, ref count, element);

		/// <inheritdoc/>
		[O(Complexity.n_plus_k), Ω(Complexity.n_plus_k)]
		public void RemoveFirst([AllowNull] TElement element) => Collection.RemoveFirst(Elements, ref count, element);

		/// <inheritdoc/>
		[O(Complexity.n_plus_k), Ω(Complexity.n_plus_k)]
		public void RemoveLast([AllowNull] TElement element) => Collection.RemoveLast(Elements, ref count, element);

		/// <inheritdoc/>
		[O(Complexity.n), Ω(Complexity.n), Θ(Complexity.n)]
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Collection.Replace(Elements, Count, search, replace);

		/// <inheritdoc/>
		public void Resize(Int32 capacity) => Elements = Collection.Resize(Elements, capacity);

		/// <inheritdoc/>
		public void ShiftLeft() => Collection.ShiftLeft(Elements, Count, 1);

		/// <inheritdoc/>
		public void ShiftLeft(Int32 amount) => Collection.ShiftLeft(Elements, Count, amount);

		/// <inheritdoc/>
		public void ShiftRight() => Collection.ShiftRight(Elements, Count, 1);

		/// <inheritdoc/>
		public void ShiftRight(Int32 amount) => Collection.ShiftRight(Elements, Count, amount);

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public Memory<TElement?> Slice() => Elements.AsMemory();

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public Memory<TElement?> Slice(Int32 start) => Elements.AsMemory(start);

		/// <inheritdoc/>
		[O(1), Ω(1), Θ(1)]
		public Memory<TElement?> Slice(Int32 start, Int32 length) => Elements.AsMemory(start, length);

		/// <inheritdoc/>
		[O(Complexity.n), Ω(Complexity.n), Θ(Complexity.n)]
		[return: NotNull]
		public sealed override String ToString() => Collection.ToString(Elements);

		/// <inheritdoc/>
		[O(Complexity.n), Ω(Complexity.n), Θ(Complexity.n)]
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Elements, amount);
	}
}
