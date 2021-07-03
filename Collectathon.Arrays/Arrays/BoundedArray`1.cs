using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Enumerators;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents a bounded array, a type of flexible array whos' size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class BoundedArray<TElement> :
		IAddSpan<TElement>,
		IArray<TElement>,
		IClear,
		IEquatable<BoundedArray<TElement>>,
		IInsertSpan<Int32, TElement>,
		IList<TElement>,
		IPostpendSpan<TElement>,
		IPrependSpan<TElement>,
		IPushSpan<TElement>,
		IRemove<TElement>,
		ISequence<TElement, ArrayEnumerator<TElement>>,
		IStack<TElement> {
		/// <summary>
		/// The backing array of this <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly TElement?[] Elements;

		/// <summary>
		/// The amount of elements contained in this collection.
		/// </summary>
		private Int32 count;

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(Int32 capacity) => Elements = new TElement?[capacity];

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TElement}"/>
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public BoundedArray([DisallowNull] params TElement?[] elements) {
			Elements = elements;
			count = elements.Length;
		}

		/// <inheritdoc/>
		public Int32 Capacity => Elements.Length;

		/// <inheritdoc/>
		public Int32 Count {
			get => count;
			private set => count = value;
		}

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[Int32 index] {
			get => Elements[index];
			set => Elements[index] = value;
		}

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		public Span<TElement?> this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength(Count);
				return Elements.AsSpan(offset, length);
			}
		}

		/// <inheritdoc/>
		Memory<TElement> ISlice<Memory<TElement>>.this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength(Count);
				return Elements.AsMemory(offset, length);
			}
		}

		/// <inheritdoc/>
		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength(Count);
				return Elements.AsMemory(offset, length);
			}
		}
#endif

		/// <summary>
		/// Converts the <paramref name="array"/> to a <see cref="BoundedArray{TElement}"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> to convert.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator BoundedArray<TElement?>([AllowNull] TElement?[] array) => array is not null ? new(array) : null;

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="BoundedArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[Shifts]
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static BoundedArray<TElement?> operator <<([AllowNull] BoundedArray<TElement?> array, Int32 amount) {
			array?.ShiftLeft(amount);
			return array;
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="BoundedArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[Shifts]
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static BoundedArray<TElement?> operator >>([AllowNull] BoundedArray<TElement?> array, Int32 amount) {
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
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Elements, Count, element);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case BoundedArray<TElement?> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement?> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] BoundedArray<TElement?> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] System.Collections.Generic.IEnumerable<TElement?> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public ArrayEnumerator<TElement> GetEnumerator() => new ArrayEnumerator<TElement>(Elements, Count);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert(Int32 index, [AllowNull] TElement element) {
			if (Count < Capacity) {
				Collection.Insert(Elements, ref count, index, element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert([DisallowNull] Int32 index, [AllowNull] params TElement?[] elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert([DisallowNull] Int32 index, ArraySegment<TElement?> elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert([DisallowNull] Int32 index, Memory<TElement?> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert([DisallowNull] Int32 index, ReadOnlyMemory<TElement?> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert([DisallowNull] Int32 index, Span<TElement?> elements) => Insert(index, (ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Insert(Int32 index, ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length <= Capacity) {
				Collection.Insert(Elements, ref count, index, elements);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		public TElement Peek() => Elements[Count - 1];

		/// <inheritdoc/>
		public void Peek([MaybeNull] out TElement element) => element = Elements[Count - 1];

		/// <inheritdoc/>
		[return: MaybeNull]
		public TElement Pop() => Elements[--Count];

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend([AllowNull] TElement element) {
			if (Count < Capacity) {
				Collection.Postpend(Elements, ref count, element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend([AllowNull] params TElement?[] elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend(ArraySegment<TElement?> elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend(Memory<TElement?> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend(ReadOnlyMemory<TElement?> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend(Span<TElement?> elements) => Postpend((ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		public void Postpend(ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length <= Capacity) {
				Collection.Postpend(Elements, ref count, elements);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend([AllowNull] TElement element) {
			if (Count < Capacity) {
				Collection.Prepend(Elements, ref count, element);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend([AllowNull] params TElement?[] elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend(ArraySegment<TElement?> elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend(Memory<TElement?> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend(ReadOnlyMemory<TElement?> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend(Span<TElement?> elements) => Prepend((ReadOnlySpan<TElement?>)elements);

		/// <inheritdoc/>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		[Shifts]
		public void Prepend(ReadOnlySpan<TElement?> elements) {
			if (Count + elements.Length <= Capacity) {
				Collection.Prepend(Elements, ref count, elements);
			} else {
				throw new InvalidOperationException();
			}
		}

		/// <inheritdoc/>
		public void Push([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public void Push([AllowNull] params TElement?[] elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Push(ArraySegment<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Push(Memory<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Push(ReadOnlyMemory<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Push(Span<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Push(ReadOnlySpan<TElement?> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeShifts]
		public void Remove([AllowNull] TElement element) => Collection.Remove(Elements, ref count, element);

		/// <inheritdoc/>
		[MaybeShifts]
		public void RemoveFirst([AllowNull] TElement element) => Collection.RemoveFirst(Elements, ref count, element);

		/// <inheritdoc/>
		[MaybeShifts]
		public void RemoveLast([AllowNull] TElement element) => Collection.RemoveLast(Elements, ref count, element);

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Collection.Replace(Elements, Count, search, replace);

		/// <inheritdoc/>
		[Shifts]
		public void ShiftLeft() => Collection.ShiftLeft(Elements, Count, 1);

		/// <inheritdoc/>
		[Shifts]
		public void ShiftLeft(Int32 amount) => Collection.ShiftLeft(Elements, Count, amount);

		/// <inheritdoc/>
		[Shifts]
		public void ShiftRight() => Collection.ShiftRight(Elements, Count, 1);

		/// <inheritdoc/>
		[Shifts]
		public void ShiftRight(Int32 amount) => Collection.ShiftRight(Elements, Count, amount);

		/// <inheritdoc/>
		public Span<TElement?> Slice() => Elements.AsSpan();

		/// <inheritdoc/>
		public Span<TElement?> Slice(Int32 start) => Elements.AsSpan(start);

		/// <inheritdoc/>
		public Span<TElement?> Slice(Int32 start, Int32 length) => Elements.AsSpan(start, length);

		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice() => Elements.AsSpan();

		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice(Int32 start) => Elements.AsSpan(start);

		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice(Int32 start, Int32 length) => Elements.AsSpan(start, length);

		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice() => Elements.AsMemory();

		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice(Int32 start) => Elements.AsMemory(start);

		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice(Int32 start, Int32 length) => Elements.AsMemory(start, length);

		Memory<TElement> ISlice<Memory<TElement>>.Slice() => Elements.AsMemory();

		Memory<TElement> ISlice<Memory<TElement>>.Slice(Int32 start) => Elements.AsMemory(start);

		Memory<TElement> ISlice<Memory<TElement>>.Slice(Int32 start, Int32 length) => Elements.AsMemory(start, length);

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => Collection.ToString(Elements);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Elements, amount);
	}
}
