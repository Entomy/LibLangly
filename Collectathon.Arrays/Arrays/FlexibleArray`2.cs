using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Langly;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any dynamically sized array.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public abstract partial class FlexibleArray<TElement, TSelf> :
		IAdd<TElement, TSelf>,
		ICapacity,
		IClear<TSelf>,
		IConcat<TElement, TSelf>,
		IEquatable<TSelf>, IEquatable<FlexibleArray<TElement, TSelf>>,
		IIndex<TElement>,
		IInsert<TElement, TSelf>,
		IRemove<TElement, TSelf>,
		IReplace<TElement, TSelf>,
		ISequence<TElement, FlexibleArray<TElement, TSelf>.Enumerator>,
		IShift<TSelf>,
		ISlice<Memory<TElement>>
		where TSelf : FlexibleArray<TElement, TSelf> {
		/// <summary>
		/// The <see cref="Filter{TIndex, TElement}"/> being used.
		/// </summary>
		/// <remarks>
		/// This is never <see langword="null"/>; a sentinel is used by default.
		/// </remarks>
		[NotNull, DisallowNull]
		protected readonly Filter<nint, TElement> Filter;

		/// <summary>
		/// The backing array of this <see cref="FlexibleArray{TElement, TSelf}"/>.
		/// </summary>
		[DisallowNull, NotNull]
		protected TElement[] Memory;

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="count">The amount of elements in the array.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray(nint capacity, nint count, Filters filter) {
			Memory = new TElement[capacity];
			Count = count;
			Filter = Filter<nint, TElement>.Create(filter);
		}

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		/// <param name="count">The amount of elements in the array.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray([DisallowNull] TElement[] memory, nint count, Filters filter) {
			Memory = memory;
			Count = count;
			Filter = Filter<nint, TElement>.Create(filter);
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		/// <param name="count">The amount of elements in the array.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected FlexibleArray([DisallowNull] TElement[] memory, nint count, [DisallowNull] Filter<nint, TElement> filter) {
			Memory = memory;
			Count = count;
			Filter = filter;
		}

		/// <inheritdoc/>
		public nint Capacity => Memory.Length;

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[nint index] {
			get => Memory[(Int32)index];
			set => Memory[(Int32)index] = value;
		}

		/// <inheritdoc/>
		public Memory<TElement> this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Count);
				return ((ISlice<Memory<TElement>>)this).Slice(offset, length);
			}
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="FlexibleArray{TElement, TSelf}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static TSelf operator <<([AllowNull] FlexibleArray<TElement, TSelf> array, Int32 amount) => array?.ShiftLeft(amount);

		/// <summary>
		/// Shifts the <paramref name="array"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The <see cref="FlexibleArray{TElement, TSelf}"/> to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static TSelf operator >>([AllowNull] FlexibleArray<TElement, TSelf> array, Int32 amount) => array?.ShiftRight(amount);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IAdd<TElement, TSelf>.Add([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IClear<TSelf>.Clear() {
			Count = 0;
			return (TSelf)this;
		}

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public sealed override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case TSelf other:
				return Equals(other);
			case FlexibleArray<TElement, TSelf> other:
				return Equals(other);
			case System.Collections.Generic.IEnumerable<TElement> other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] TSelf other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] FlexibleArray<TElement, TSelf> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] System.Collections.Generic.IEnumerable<TElement> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(Memory, Count);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IInsert<nint, TElement, TSelf>.Insert(nint index, [AllowNull] TElement element) => Insert(index, element);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IInsert<TElement, TSelf>.Insert(nint index, ReadOnlyMemory<TElement> elements) => Insert(index, elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPostpend<TElement, TSelf>.Postpend([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPostpend<TElement, TSelf>.Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPrepend<TElement, TSelf>.Prepend([AllowNull] TElement element) => Prepend(element);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPrepend<TElement, TSelf>.Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements);

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IRemove<TElement, TSelf>.Remove([AllowNull] TElement element) {
			for (nint i = 0; i < Count; i++) {
				if (Equals(Memory[i], element)) {
					Memory[i] = Memory[i + 1];
					i--;
					Count--;
				}
			}
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IRemove<TElement, TSelf>.RemoveFirst([AllowNull] TElement element) {
			for (nint i = 0; i < Count; i++) {
				if (Equals(Memory[i], element)) {
					Memory.Slice(i).CopyTo(Memory.Slice(--i));
					Count--;
					return (TSelf)this;
				}
			}
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IRemove<TElement, TSelf>.RemoveLast([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IReplace<TElement, TElement, TSelf>.Replace([AllowNull] TElement search, [AllowNull] TElement replace) {
			for (Int32 i = 0; i < Count; i++) {
				if (Equals(Memory[i], search)) {
					Memory[i] = replace;
				}
			}
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IShift<TSelf>.ShiftLeft(nint amount) {
			if (amount == 0 || Count == 0) {
				return (TSelf)this;
			}
			Memory.Slice(amount).CopyTo(Memory);
			Memory.Slice(Capacity - amount).Span.Clear();
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IShift<TSelf>.ShiftRight(nint amount) {
			if (amount == 0 || Count == 0) {
				return (TSelf)this;
			}
			Memory.Slice(0, Capacity - amount).CopyTo(Memory.Slice(amount));
			Memory.Slice(0, amount).Span.Clear();
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Memory<TElement> ISlice<Memory<TElement>>.Slice(nint start, nint length) => Memory.Slice((Int32)start, (Int32)length);

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override String ToString() => ISequence<TElement, Enumerator>.ToString(this, Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => ISequence<TElement, Enumerator>.ToString(this, amount);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Insert(nint index, [AllowNull] TElement element) {
			Memory.Slice(index, Count - index).CopyTo(Memory.Slice(index + 1));
			Memory[(Int32)index] = element;
			Count++;
			return (TSelf)this;
		}

		/// <summary>
		/// Insert the elements into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Insert(nint index, ReadOnlyMemory<TElement> elements) {
			Memory.Slice(index, Count - index).CopyTo(Memory.Slice(index + elements.Length));
			elements.CopyTo(Memory.Slice(index));
			Count += elements.Length;
			return (TSelf)this;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Postpend([AllowNull] TElement element) {
			Memory[Count++] = element;
			return (TSelf)this;
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Postpend(ReadOnlyMemory<TElement> elements) {
			elements.CopyTo(Memory.Slice(Count));
			Count += elements.Length;
			return (TSelf)this;
		}

		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <param name="element">The element to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Prepend([AllowNull] TElement element) {
			((IShift<TSelf>)this).ShiftRight(1);
			Memory[0] = element;
			Count++;
			return (TSelf)this;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Prepend(ReadOnlyMemory<TElement> elements) {
			((IShift<TSelf>)this).ShiftRight(elements.Length);
			elements.CopyTo(Memory);
			Count += elements.Length;
			return (TSelf)this;
		}
	}
}
