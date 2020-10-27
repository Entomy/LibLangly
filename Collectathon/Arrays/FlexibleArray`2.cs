using System;
using Collectathon.Filters;
using Philosoft;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any associative array type which has a flexible size.
	/// </summary>
	/// <typeparam name="TIndex">The type of indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1 of <see cref="Tuple{T1, T2}"/>.
	/// </remarks>
	[Serializable]
	public abstract class FlexibleArray<TIndex, TElement, TSelf> : Array<TIndex, TElement, TSelf>, IAddable<TIndex, TElement>, IClearable, IRemovable<TIndex, TElement> where TIndex : IEquatable<TIndex> where TSelf : FlexibleArray<TIndex, TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="members">The set of members.</param>
		/// <param name="length">The length of the array.</param>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		protected FlexibleArray(Memory<Association<TIndex, TElement>> members, nint length, Filter<TElement> filterer) : base(members, length, filterer) { }

		/// <inheritdoc/>
		protected virtual void Add(TIndex index, TElement element) {
			if (Indicies.Contains(index)) {
				return;
			}
			Members.Span[(Int32)Length++] = new Association<TIndex, TElement>(index, element);
		}

		/// <inheritdoc/>
		void IAddable<TIndex, TElement>.Add(TIndex index, TElement element) => Add(index, element);

		/// <inheritdoc/>
		void IClearable.Clear() {
			Members = null;
			GC.Collect();
			Members = Memory<Association<TIndex, TElement>>.Empty;
			Length = 0;
		}

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(TElement element) {
			for (Int32 i = 0; i < Length; i++) {
				if (Members.Span[i].Element?.Equals(element) ?? false) {
					Members.Slice(i).ShiftLeft();
					Length--;
					i--;
				}
			}
		}

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(Predicate<TElement> match) {
			if (match is null) {
				return;
			}
			for (Int32 i = 0; i < Length; i++) {
				if (match(Members.Span[i].Element)) {
					Members.Slice(i).ShiftLeft();
					Length--;
					i--;
				}
			}
		}

		/// <inheritdoc/>
		void IRemovable<TIndex, TElement>.RemoveAt(TIndex index) {
			for (Int32 i = 0; i < Length; i++) {
				if (Members.Span[i].Index?.Equals(index) ?? false) {
					Members.Slice(i).ShiftLeft();
					Length--;
					return;
				}
			}
		}
	}
}
