using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents an array of contiguous elements.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public readonly partial struct Array<TElement> :
		IAdd<TElement, Array<TElement>>,
		ICapacity,
		IConcat<TElement, Array<TElement>>,
		IContains<TElement>,
		ICount,
		IEquals<Array<TElement>>,
		IIndexRefReadOnly<TElement>,
		IInsert<TElement, Array<TElement>>,
		IRemove<TElement, Array<TElement>>,
		IReplace<TElement, Array<TElement>>,
		IResize<Array<TElement>>,
		IShift<Array<TElement>>,
		ISlice<Array<TElement>> {
		/// <summary>
		/// The memory of the <see cref="Array{TElement}"/>.
		/// </summary>
		private readonly ReadOnlyMemory<TElement> Memory;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements of the array.</param>
		public Array([AllowNull] params TElement[] elements) => Memory = elements;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement}"/>.
		/// </summary>
		/// <param name="memory">The memory of the array.</param>
		private Array(ReadOnlyMemory<TElement> memory) => Memory = memory;

		/// <summary>
		/// Returns an empty <see cref="Array{TElement}"/>
		/// </summary>
		public static Array<TElement> Empty => default;

		/// <inheritdoc/>
		public nint Capacity {
			get => Memory.Length;
			set => Resize(value);
		}

		/// <inheritdoc/>
		public nint Count => Memory.Length;

		/// <inheritdoc/>
		public ref readonly TElement this[nint index] => ref Memory.Span[(Int32)index];

		/// <inheritdoc/>
		public Array<TElement> this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Count);
				return Slice(offset, length);
			}
		}

		/// <summary>
		/// Converts the <paramref name="elements"/> to an <see cref="Array{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements of the array.</param>
		public static implicit operator Array<TElement>([AllowNull] TElement[] elements) => new(elements);

		/// <summary>
		/// Determines if the two sequences aren't equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=(Array<TElement> left, Array<TElement> right) => !left.Equals(right);

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static Array<TElement> operator <<(Array<TElement> array, Int32 amount) => array.ShiftLeft(amount);

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==(Array<TElement> left, Array<TElement> right) => left.Equals(right);

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array{TElement}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		public static Array<TElement> operator >>(Array<TElement> array, Int32 amount) => array.ShiftRight(amount);

		/// <inheritdoc/>
		public Array<TElement> Add([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		public Array<TElement> Add([AllowNull] params TElement[] elements) => Postpend(elements);

		/// <inheritdoc/>
		public Array<TElement> Add(Memory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public Array<TElement> Add(ReadOnlyMemory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public Array<TElement> Add(Span<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public Array<TElement> Add(ReadOnlySpan<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		public Array<TElement> Add<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => Postpend(elements);

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) {
			foreach (TElement item in Memory.Span) {
				if (Equals(item, element)) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] System.Object obj) {
			switch (obj) {
			case Array<TElement> array:
				return Equals(array);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Array<TElement> other) {
			if (Count != other.Count) {
				return false;
			}
			for (nint i = 0; i < Count; i++) {
				if (!Equals(this[i], other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Memory.GetHashCode();

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, [AllowNull] TElement element) {
			if (element is null) {
				return this;
			}
			TElement[] Array = new TElement[Count + 1];
			Memory.Span.Slice(0, (Int32)index).CopyTo(Array);
			Array[index] = element;
			Memory.Span.Slice((Int32)index).CopyTo(Array.AsSpan().Slice((Int32)index + 1));
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, [AllowNull] params TElement[] elements) => elements is not null ? Insert(index, elements.AsMemory()) : this;

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, Memory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, Span<TElement> elements) => Insert(index, (ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		public Array<TElement> Insert(nint index, ReadOnlySpan<TElement> elements) {
			TElement[] Array = new TElement[Count + elements.Length];
			Memory.Span.Slice(0, (Int32)index).CopyTo(Array);
			elements.CopyTo(Array.AsSpan().Slice((Int32)index));
			Memory.Span.Slice((Int32)index).CopyTo(Array.AsSpan().Slice((Int32)index + elements.Length));
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Insert<TEnumerator>(nint index, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => throw new NotImplementedException();

		/// <inheritdoc/>
		public Array<TElement> Postpend([AllowNull] TElement element) {
			if (element is null) {
				return this;
			}
			TElement[] Array = new TElement[Count + 1];
			Memory.CopyTo(Array);
			Array[Count] = element;
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Postpend([AllowNull] params TElement[] elements) => elements is not null ? Postpend(elements.AsMemory()) : this;

		/// <inheritdoc/>
		public Array<TElement> Postpend(Memory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Postpend(Span<TElement> elements) => Postpend((ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		public Array<TElement> Postpend(ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return this;
			}
			TElement[] Array = new TElement[Count + elements.Length];
			Memory.CopyTo(Array);
			elements.CopyTo(Array.AsSpan().Slice((Int32)Count));
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Postpend<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null || elements.Count == 0) {
				return this;
			}
			TElement[] Array = new TElement[Count + elements.Count];
			Memory.CopyTo(Array);
			nint i = Count;
			foreach (TElement element in elements) {
				Array[i++] = element;
			}
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Prepend([AllowNull] TElement element) {
			if (element is null) {
				return this;
			}
			TElement[] Array = new TElement[Count + 1];
			Memory.Span.CopyTo(Array.AsSpan().Slice(1));
			Array[0] = element;
			return new(Array);
		}

		/// <inheritdoc />
		public Array<TElement> Prepend([AllowNull] params TElement[] elements) => elements is not null ? Prepend(elements.AsMemory()) : this;

		/// <inheritdoc/>
		public Array<TElement> Prepend(Memory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		public Array<TElement> Prepend(Span<TElement> elements) => Prepend((ReadOnlySpan<TElement>)elements);

		/// <inheritdoc/>
		public Array<TElement> Prepend(ReadOnlySpan<TElement> elements) {
			if (elements.Length == 0) {
				return this;
			}
			TElement[] Array = new TElement[Count + elements.Length];
			Memory.Span.CopyTo(Array.AsSpan().Slice(elements.Length));
			elements.CopyTo(Array);
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Prepend<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null || elements.Count == 0) {
				return this;
			}
			TElement[] Array = new TElement[Count + elements.Count];
			Memory.Span.CopyTo(Array.AsSpan().Slice((Int32)elements.Count));
			nint i = 0;
			foreach (TElement element in elements) {
				Array[i++] = element;
			}
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Remove([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Array<TElement> RemoveFirst([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Array<TElement> RemoveLast([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public Array<TElement> Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			TElement?[] Array = new TElement[Count];
			for (nint i = 0; i < Count; i++) {
				Array[i] = Equals(this[i], search) ? replace : this[i];
			}
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Resize(nint capacity) {
			TElement[] Array = new TElement[capacity];
			Memory.CopyTo(Array);
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> ShiftLeft() => ShiftLeft(1);

		/// <inheritdoc/>
		public Array<TElement> ShiftLeft(nint amount) {
			if (amount == 0) {
				return this;
			}
			TElement?[] Array = new TElement[Count];
			nint i = 0;
			for (nint j = amount; i < Count - amount; j++) {
				Array[i++] = Memory.Span[(Int32)j];
			}
			for (; i < Count; i++) {
				Array[i] = default;
			}
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> ShiftRight() => ShiftRight(1);

		/// <inheritdoc/>
		public Array<TElement> ShiftRight(nint amount) {
			if (amount == 0) {
				return this;
			}
			TElement?[] Array = new TElement[Count];
			nint i = 0;
			for (; i < amount; i++) {
				Array[i] = default;
			}
			for (Int32 j = 0; i < Count; j++) {
				Array[i++] = Memory.Span[j];
			}
			return new(Array);
		}

		/// <inheritdoc/>
		public Array<TElement> Slice() => this;

		///<inheritdoc/>
		public Array<TElement> Slice(nint start) => new(Memory.Slice((Int32)start));

		/// <inheritdoc/>
		public Array<TElement> Slice(nint start, nint length) => new(Memory.Slice((Int32)start, (Int32)length));

		/// <inheritdoc/>
		public override String ToString() => ToString(Count);

		/// <summary>
		/// Returns a string that represents the current object, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		public String ToString(nint amount) {
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TElement element in this) {
				if (++i == Count) {
					_ = builder.Append(element);
					break;
				} else if (i == amount) {
					_ = builder.Append(element).Append("...");
					break;
				} else {
					_ = builder.Append(element).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
