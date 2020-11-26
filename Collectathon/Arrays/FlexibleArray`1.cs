using System;
using Langly;
using Collectathon.Filters;
using Defender.Exceptions;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any array type which has a flexible size.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing behaviors on top of <see cref="Array"/>s of rank 1.
	/// </remarks>
	[Serializable]
	public abstract class FlexibleArray<TElement, TSelf> : Array<TElement, TSelf>, IAddable<TElement>, IClearable, IDequeueable<TElement>, IEnqueueable<TElement>, IInsertable<TElement>, IPoppable<TElement>, IPushable<TElement>, IRemovable<TElement> where TSelf : FlexibleArray<TElement, TSelf> {
		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray(nint capacity, Filter filter) : base(capacity, filter) { }

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="elements">The set of elements.</param>
		/// <param name="length">The length of this array.</param>
		/// <param name="filter">The type of filter to use.</param>
		protected FlexibleArray(Memory<TElement> elements, nint length, Filter<TElement> filter) : base(elements, length, filter) { }

		/// <inheritdoc/>
		protected virtual void Add(TElement element) {
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			this[Length++] = element;
		}

		/// <inheritdoc/>
		void IAddable<TElement>.Add(TElement element) => Add(element);

		/// <inheritdoc/>
		protected virtual void Clear() {
			Elements = Memory<TElement>.Empty;
			Length = 0;
		}

		/// <inheritdoc/>
		void IClearable.Clear() => Clear();

		/// <inheritdoc/>
		TElement IDequeueable<TElement>.Dequeue() {
			if (Length == 0) {
				throw CollectionEmptyException.With();
			}
			TElement result = this[0];
			this.ShiftLeft();
			Length--;
			return result;
		}

		/// <inheritdoc/>
		void IEnqueueable<TElement>.Enqueue(TElement element) => Add(element);

		/// <inheritdoc/>
		protected virtual void Insert(nint index, TElement element) {
			if (Filterer.FiltersAdds && Filterer.Contains(element).Necessary()) {
				return;
			}
			Elements.Slice((Int32)index).ShiftRight();
			Elements.Span[(Int32)index] = element;
			Length++;
		}

		/// <inheritdoc/>
		void IInsertable<nint, TElement>.Insert(nint index, TElement element) => Insert(index, element);

		/// <inheritdoc/>
		TElement IPoppable<TElement>.Pop() {
			if (Length == 0) {
				throw CollectionEmptyException.With();
			}
			return Elements.Span[(Int32)(--Length)];
		}

		/// <inheritdoc/>
		void IPushable<TElement>.Push(TElement element) => Add(element);

		/// <inheritdoc/>
		void IRemovable<TElement>.Remove(TElement element) {
			for (Int32 i = 0; i < Length; i++) {
				if (this[i].Equals(element)) {
					Elements.Slice(i).ShiftLeft();
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
				if (match(this[i])) {
					Elements.Slice(i).ShiftLeft();
					Length--;
					i--;
				}
			}
		}
	}
}
