using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents any array type.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1.
	/// </remarks>
	public abstract partial class Array<TElement, TSelf> : DataStructure<TElement, TSelf, Array<TElement, TSelf>.Enumerator>, IContainable<TElement>, IEquatable<Array<TElement, TSelf>>, IRefIndexable<TElement>, IPeekable<TElement>, IReplaceable<TElement>, IShiftable, ISliceable<Memory<TElement>> where TSelf : Array<TElement, TSelf> {
		/// <summary>
		/// The set of elements.
		/// </summary>
		protected Memory<TElement> Elements;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected Array(nint capacity, Filter filter) : base(filter) {
			Guard.GreaterThanOrEqual(capacity, nameof(capacity), 0);
			Elements = new TElement[capacity];
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The set of elements.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		protected Array(Memory<TElement> elements, nint length, Filter<TElement> filterer) : base(filterer) {
			Elements = elements;
			Length = length;
		}

		/// <summary>
		/// The current capacity of the array; how many elements it can hold.
		/// </summary>
		public nint Capacity => Elements.Length;

		/// <inheritdoc/>
		[SuppressMessage("Design", "CA1033:Interface methods should be callable by child types", Justification = "It is, it's called Length.")]
		nint ICountable.Count => Length;

		/// <summary>
		/// The total amount of elements in this array.
		/// </summary>
		public nint Length { get; protected set; }

		/// <inheritdoc/>
		public ref TElement this[nint index] {
			get {
				Guard.Index(index, nameof(index), this);
				return ref Elements.Span[(Int32)index];
			}
		}

		/// <inheritdoc/>
		ref readonly TElement IReadOnlyRefIndexable<nint, TElement>.this[nint index] => ref this[index];

		/// <inheritdoc/>
		public Memory<TElement> this[Range range] {
			get {
				(Int32 offset, Int32 length) = range.GetOffsetAndLength((Int32)Length);
				return Elements.Slice(offset, length);
			}
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> leftwards by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The array to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A new array with the shifted elements.</returns>
		public static TSelf operator <<(Array<TElement, TSelf> array, Int32 amount) {
			if (array is null) {
				return null;
			}
			TSelf result = array.Clone();
			result.ShiftLeft(amount);
			return result;
		}

		/// <summary>
		/// Shifts the <paramref name="array"/> rightwards by <paramref name="amount"/>.
		/// </summary>
		/// <param name="array">The array to shift.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A new array with the shifted elements.</returns>
		public static TSelf operator >>(Array<TElement, TSelf> array, Int32 amount) {
			if (array is null) {
				return null;
			}
			TSelf result = array.Clone();
			result.ShiftRight(amount);
			return result;
		}

		/// <inheritdoc/>
		Boolean IContainable<TElement>.Contains(TElement element) {
			if (Filterer.FiltersContains && Filterer.Contains(element).Not().Possible()) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (Elements.Span[i]?.Equals(element) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public sealed override Boolean Equals(DataStructure<TElement, TSelf, Enumerator> other) {
			switch (other) {
			case Array<TElement, TSelf> array:
				return Equals(array);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Array<TElement, TSelf> other) {
			if (other is null || Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Equals(Elements.Span[i], other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public sealed override Boolean Equals(TElement[] other) {
			if (other is null || Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Equals(Elements.Span[i], other[i])) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public ref readonly TElement Peek() => ref this[Length - 1];

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(TElement oldElement, TElement newElement) {
			for (Int32 i = 0; i < Length; i++) {
				if (Elements.Span[i].Equals(oldElement)) {
					Elements.Span[i] = newElement;
				}
			}
		}

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(Predicate<TElement> match, TElement newElement) {
			if (match is null) {
				return;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (match(Elements.Span[i])) {
					this[i] = newElement;
				}
			}
		}

		/// <inheritdoc/>
		void IShiftable.ShiftLeft() => Elements.ShiftLeft();

		/// <inheritdoc/>
		void IShiftable.ShiftLeft(nint amount) => Elements.ShiftLeft(amount);

		/// <inheritdoc/>
		void IShiftable.ShiftRight() => Elements.ShiftRight();

		/// <inheritdoc/>
		void IShiftable.ShiftRight(nint amount) => Elements.ShiftRight(amount);

		/// <inheritdoc/>
		public Memory<TElement> Slice() => Elements;

		/// <inheritdoc/>
		public Memory<TElement> Slice(nint start) => Elements.Slice((Int32)start, (Int32)(Length - start));

		/// <inheritdoc/>
		public Memory<TElement> Slice(nint start, nint length) => Elements.Slice((Int32)start, (Int32)length);
	}
}
