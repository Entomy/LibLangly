﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;
using Collectathon.Enumerators;

namespace Collectathon {
	/// <summary>
	/// Represents a dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class DynamicArray<TElement> :
		IAddSpan<TElement>,
		IArray<TElement>,
		IClear,
		IEquatable<DynamicArray<TElement>>,
		IInsertSpan<Index, TElement>,
		IList<TElement>,
		IPostpendSpan<TElement>,
		IPrependSpan<TElement>,
		IPushSpan<TElement>,
		IRemove<TElement>,
		IResize,
		ISequence<TElement, ArrayEnumerator<TElement>>,
		IStack<TElement> {
		/// <summary>
		/// The amount of elements contained in this collection.
		/// </summary>
		private Int32 count;

		/// <summary>
		/// The backing array of this <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		private TElement[] Elements;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		public DynamicArray() => Elements = Array.Empty<TElement>();

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(Int32 capacity) => Elements = new TElement[capacity];

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TElement}"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		public DynamicArray(params TElement[] elements) {
			Elements = elements;
			count = elements.Length;
		}

		/// <inheritdoc/>
		[Resizes]
		public Int32 Capacity {
			get => Elements.Length;
			set => Resize(value);
		}

		/// <inheritdoc/>
		public Int32 Count {
			get => count;
			private set => count = value;
		}

		/// <inheritdoc/>
		public TElement this[Index index] {
			get => Elements[index];
			set => Elements[index] = value;
		}

		/// <inheritdoc/>
		public Span<TElement> this[Range range] {
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

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="DynamicArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[Shifts]
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static DynamicArray<TElement> operator <<(DynamicArray<TElement>? array, Int32 amount) {
			array?.ShiftLeft(amount);
			return array;
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="DynamicArray{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[Shifts]
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static DynamicArray<TElement> operator >>(DynamicArray<TElement>? array, Int32 amount) {
			array?.ShiftRight(amount);
			return array;
		}

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(TElement element) => Postpend(element);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(params TElement[]? elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(ArraySegment<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(Memory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(ReadOnlyMemory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(Span<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(ReadOnlySpan<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Collection.Contains(Elements, Count, element);

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => Collection.Contains(Elements, Count, predicate);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case DynamicArray<TElement> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(DynamicArray<TElement>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(System.Collections.Generic.IEnumerable<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public ArrayEnumerator<TElement> GetEnumerator() => new ArrayEnumerator<TElement>(Elements, Count);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Insert(Elements, ref count, index, element);
		}

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, params TElement[]? elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, ArraySegment<TElement> elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, Memory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, Span<TElement> elements) => Insert(index, (ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Insert(Index index, ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Insert(Elements, ref count, index, elements);
		}

		/// <inheritdoc/>
		public TElement Peek() => Elements[Count - 1];

		/// <inheritdoc/>
		public void Peek(out TElement element) => element = Elements[Count - 1];

		/// <inheritdoc/>
		public TElement Pop() => Elements[--Count];

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Postpend(Elements, ref count, element);
		}

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(params TElement[]? elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(ArraySegment<TElement> elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(Memory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(Span<TElement> elements) => Postpend((ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Postpend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Postpend(Elements, ref count, elements);
		}

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(TElement element) {
			if (Count == Capacity) {
				Elements = Collection.Grow(Elements);
			}
			Collection.Prepend(Elements, ref count, element);
		}

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(params TElement[]? elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(ArraySegment<TElement> elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(Memory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(Span<TElement> elements) => Prepend((ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		[MaybeResizes, Shifts]
		public void Prepend(ReadOnlySpan<TElement> elements) {
			if (Count + elements.Length >= Capacity) {
				Elements = Collection.Grow(Elements, Capacity + elements.Length);
			}
			Collection.Prepend(Elements, ref count, elements);
		}

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(TElement element) => Postpend(element);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(params TElement[]? elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(ArraySegment<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(Memory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(ReadOnlyMemory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(Span<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeResizes]
		public void Push(ReadOnlySpan<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[MaybeShifts]
		public void Remove(TElement element) => Collection.Remove(Elements, ref count, element);

		/// <inheritdoc/>
		[MaybeShifts]
		public void RemoveFirst(TElement element) => Collection.RemoveFirst(Elements, ref count, element);

		/// <inheritdoc/>
		[MaybeShifts]
		public void RemoveLast(TElement element) => Collection.RemoveLast(Elements, ref count, element);

		/// <inheritdoc/>
		public void Replace(TElement search, TElement replace) => Collection.Replace(Elements, Count, search, replace);

		/// <inheritdoc/>
		[Resizes]
		public void Resize(Int32 capacity) => Elements = Collection.Resize(Elements, capacity);

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
		public Span<TElement> Slice() => Elements.AsSpan();

		/// <inheritdoc/>
		public Span<TElement> Slice(Index start) => Elements.AsSpan(start.GetOffset(Count));

		/// <inheritdoc/>
		public Span<TElement> Slice(Index start, Int32 length) => Elements.AsSpan(start.GetOffset(Count), length);

		/// <inheritdoc/>
		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice() => Elements.AsSpan();

		/// <inheritdoc/>
		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice(Index start) => Elements.AsSpan(start.GetOffset(Count));

		/// <inheritdoc/>
		ReadOnlySpan<TElement> IReadOnlyArray<TElement>.Slice(Index start, Int32 length) => Elements.AsSpan(start.GetOffset(Count), length);

		/// <inheritdoc/>
		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice() => Elements.AsMemory();

		/// <inheritdoc/>
		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice(Index start) => Elements.AsMemory(start.GetOffset(Count));

		/// <inheritdoc/>
		ReadOnlyMemory<TElement> ISlice<ReadOnlyMemory<TElement>>.Slice(Index start, Int32 length) => Elements.AsMemory(start.GetOffset(Count), length);

		/// <inheritdoc/>
		Memory<TElement> ISlice<Memory<TElement>>.Slice() => Elements.AsMemory();

		/// <inheritdoc/>
		Memory<TElement> ISlice<Memory<TElement>>.Slice(Index start) => Elements.AsMemory(start.GetOffset(Count));

		/// <inheritdoc/>
		Memory<TElement> ISlice<Memory<TElement>>.Slice(Index start, Int32 length) => Elements.AsMemory(start.GetOffset(Count), length);

		/// <inheritdoc/>
		public sealed override String ToString() => Collection.ToString(Elements);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(Elements, amount);
	}
}
