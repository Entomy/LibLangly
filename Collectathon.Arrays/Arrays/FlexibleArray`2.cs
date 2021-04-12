using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Filters;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any dynamically sized array.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
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
		protected FlexibleArray(nint capacity, nint count, FilterType filter) {
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
		protected FlexibleArray([DisallowNull] TElement[] memory, nint count, FilterType filter) {
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
		/// Determines if the two sequences aren't equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] FlexibleArray<TElement, TSelf> left, [AllowNull] TSelf right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two sequences aren't equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences aren't equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator !=([AllowNull] TSelf left, [AllowNull] FlexibleArray<TElement, TSelf> right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
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
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] FlexibleArray<TElement, TSelf> left, [AllowNull] TSelf right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

		/// <summary>
		/// Determines if the two sequences are equal.
		/// </summary>
		/// <param name="left">The lefthand sequence.</param>
		/// <param name="right">The righthand sequence.</param>
		/// <returns><see langword="true"/> if the two sequences are equal; otherwise, <see langword="false"/>.</returns>
		public static Boolean operator ==([AllowNull] TSelf left, [AllowNull] FlexibleArray<TElement, TSelf> right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

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
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] TSelf other) => Equals(other as FlexibleArray<TElement, TSelf>);

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] FlexibleArray<TElement, TSelf> other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			using Enumerator seq = GetEnumerator();
			using Enumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (seq.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!(oth.Current?.Equals(seq.Current) ?? false)) {
					// The sequences aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (seq.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the sequences are the same length, and contain the same elements in the same order, so are therefore equal.
			return true;
		}

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
