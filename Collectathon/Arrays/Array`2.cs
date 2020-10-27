using Philosoft;
using System;
using System.Diagnostics.CodeAnalysis;
using Collectathon.Views;
using Defender;
using Collectathon.Filters;
using Defender.Exceptions;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any associative array type.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1 of <see cref="Tuple{T1, T2}"/>.
	/// </remarks>
	[Serializable]
	public abstract partial class Array<TIndex, TElement, TSelf> : DataStructure<TIndex, TElement, TSelf, Array<TIndex, TElement, TSelf>.Enumerator>, IAssociator<TIndex, TElement, Array<TIndex, TElement, TSelf>, Array<TIndex, TElement, TSelf>.Enumerator>, IEquatable<Array<TIndex, TElement, TSelf>>, IIndexable<TIndex, TElement>, IReplaceable<TElement> where TIndex : IEquatable<TIndex> where TSelf : Array<TIndex, TElement, TSelf> {
		/// <summary>
		/// The set of members.
		/// </summary>
		protected Memory<Association<TIndex, TElement>> Members;

		/// <summary>
		/// Initializes a new <see cref="Array{TIndex, TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected Array(nint capacity, Filter filter) : base(filter) {
			Guard.GreaterThanOrEqual(capacity, nameof(capacity), 0);
			Members = new Association<TIndex, TElement>[capacity];
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="members">The set of elements.</param>
		/// <param name="length">The length of this array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		protected Array(Memory<Association<TIndex, TElement>> members, nint length, Filter<TElement> filterer) : base(filterer) {
			Members = members;
			Length = length;
		}

		/// <summary>
		/// The current capacity of the array; how many elements it can hold.
		/// </summary>
		public nint Capacity => Members.Length;

		/// <inheritdoc/>
		[SuppressMessage("Design", "CA1033:Interface methods should be callable by child types", Justification = "It is, it's called Length.")]
		nint ICountable.Count => Length;

		/// <inheritdoc/>
		public ElementView<TIndex, TElement, Array<TIndex, TElement, TSelf>, Enumerator> Elements => new ElementView<TIndex, TElement, Array<TIndex, TElement, TSelf>, Enumerator>(this);

		/// <inheritdoc/>
		public IndexView<TIndex, TElement, Array<TIndex, TElement, TSelf>, Enumerator> Indicies => new IndexView<TIndex, TElement, Array<TIndex, TElement, TSelf>, Enumerator>(this);

		/// <summary>
		/// The total amount of elements in this array.
		/// </summary>
		public nint Length { get; protected set; }

		/// <inheritdoc/>
		[SuppressMessage("Design", "CA1065:Do not raise exceptions in unexpected locations", Justification = "Index-out-of-bounds is a valid and accepted exception.")]
		public ref TElement this[TIndex index] {
			get {
				for (Int32 i = 0; i < Length; i++) {
					if (index.Equals(Members.Span[i].Index)) {
						return ref Members.Span[i].Element;
					}
				}
				throw ArgumentIndexNotValidException.With(index, nameof(index), this);
			}
		}

		/// <inheritdoc/>
		ref readonly TElement IReadOnlyIndexable<TIndex, TElement>.this[TIndex index] => ref this[index];

		/// <inheritdoc/>
		public sealed override Boolean Equals(DataStructure<TIndex, TElement, TSelf, Enumerator> other) {
			switch (other) {
			case Array<TIndex, TElement, TSelf> array:
				return Equals(array);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Array<TIndex, TElement, TSelf> other) {
			if (other is null || Length != other.Length) {
				return false;
			}
			Enumerator ths = GetEnumerator();
			Enumerator oth = other.GetEnumerator();
			while (ths.MoveNext() && oth.MoveNext()) {
				if (!ths.Current.Equals(oth.Current)) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public sealed override Boolean Equals(Association<TIndex, TElement>[] other) {
			if (other is null || Length != other.Length) {
				return false;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (!Equals(Members.Span[i].Index, other[i].Index) || !Equals(Members.Span[i].Element, other[i].Element)) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(TElement oldElement, TElement newElement) {
			for (Int32 i = 0; i < Length; i++) {
				if (Members.Span[i].Element?.Equals(oldElement) ?? false) {
					Members.Span[i].Element = newElement;
				}
			}
		}

		/// <inheritdoc/>
		void IReplaceable<TElement, TElement>.Replace(Predicate<TElement> match, TElement newElement) {
			if (match is null) {
				return;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (match(Members.Span[i].Element)) {
					Members.Span[i].Element = newElement;
				}
			}
		}
	}
}
