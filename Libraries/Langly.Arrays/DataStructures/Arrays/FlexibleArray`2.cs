using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;
using Langly.Traits;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents any dynamically sized array.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public abstract partial class FlexibleArray<TElement, TSelf> : DataStructure<TElement, TSelf, FlexibleArray<TElement, TSelf>.Enumerator>,
		IAdd<TElement, TSelf>,
		ICapacity,
		IClear<TSelf>,
		IConcat<TElement, TSelf>,
		IIndex<TElement>,
		IInsert<TElement, TSelf>,
		IRemove<TElement, TSelf>,
		IReplace<TElement, TSelf>,
		IShift<TSelf>,
		ISlice<Memory<TElement>>
		where TSelf : FlexibleArray<TElement, TSelf> {
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
		protected FlexibleArray(nint capacity, nint count, Filter filter) : base(filter) {
			Memory = new TElement[capacity];
			Count = count;
		}

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		/// <param name="count">The amount of elements in the array.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray([DisallowNull] TElement[] memory, nint count, Filter filter) : base(filter) {
			Memory = memory;
			Count = count;
		}

		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of <typeparamref name="TElement"/> to reuse.</param>
		/// <param name="count">The amount of elements in the array.</param>
		/// <param name="filter">The <see cref="Filter{TIndex, TElement}"/> to reuse.</param>
		protected FlexibleArray([DisallowNull] TElement[] memory, nint count, [DisallowNull] Filter<nint, TElement> filter) : base(filter) {
			Memory = memory;
			Count = count;
		}

		/// <inheritdoc/>
		public nint Capacity => Memory.Length;

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

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IInsert<nint, TElement, TSelf>.Insert(nint index, [AllowNull] TElement element) => Insert(index, element);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPostpend<TElement, TSelf>.Postpend([AllowNull] TElement element) => Postpend(element);

		/// <inheritdoc/>
		[return: MaybeNull]
		TSelf IPrepend<TElement, TSelf>.Prepend([AllowNull] TElement element) => Prepend(element);

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IRemove<TElement, TSelf>.Remove([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IRemove<TElement, TSelf>.RemoveFirst([AllowNull] TElement element) => throw new NotImplementedException();

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
			if (amount == 0) {
				return (TSelf)this;
			}
			Int32 i = 0;
			for (; i < Memory.Length - amount; i++) {
				Memory[i] = Memory[(Int32)(i + amount)];
			}
			for (; i < Memory.Length; i++) {
				Memory[i] = default;
			}
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IShift<TSelf>.ShiftRight(nint amount) {
			if (amount == 0) {
				return (TSelf)this;
			}
			Int32 i = Memory.Length - 1;
			for (; i >= amount; i--) {
				Memory[i] = Memory[(Int32)(i - amount)];
			}
			for (; i >= 0; i--) {
				Memory[i] = default;
			}
			return (TSelf)this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		Memory<TElement> ISlice<Memory<TElement>>.Slice(nint start, nint length) => Memory.Slice((Int32)start, (Int32)length);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The element to insert.</param>
		/// <returns>If the insert occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and inserted elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Insert(nint index, [AllowNull] TElement element) {
			for (Int32 i = Memory.Length - 1; i >= index;) {
				Memory[i] = Memory[--i];
			}
			Memory[(Int32)index] = element;
			Count++;
			return (TSelf)this;
		}

		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Postpend([AllowNull] TElement element) {
			this[Count++] = element;
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
			this[0] = element;
			Count++;
			return (TSelf)this;
		}
	}
}
