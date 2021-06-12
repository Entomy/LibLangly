using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Enumerators;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents any dynamically sized associated array.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies in the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public abstract partial class FlexibleArray<TIndex, TElement, TSelf> :
		ICapacity,
		IClear,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement>,
		ISequence<(TIndex Index, TElement Element), ArrayEnumerator<(TIndex Index, TElement Element)>>
		where TSelf : FlexibleArray<TIndex, TElement, TSelf> {
		/// <summary>
		/// The backing array of this <see cref="FlexibleArray{TIndex, TElement, TSelf}"/>.
		/// </summary>
		protected (TIndex Index, TElement Element)[] Entries;

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="count">The amount of elements in the array.</param>
		protected FlexibleArray(nint capacity, nint count) {
			Entries = new (TIndex, TElement)[capacity];
			Count = count;
		}

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="entries"/>.
		/// </summary>
		/// <param name="entries">The initial entries of the list.</param>
		/// <param name="count">The amount of elements in the array.</param>
		protected FlexibleArray([DisallowNull] (TIndex, TElement)[] entries, nint count) {
			Entries = entries;
			Count = count;
		}

		/// <inheritdoc/>
		public nint Capacity => Entries.Length;

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				foreach ((TIndex Index, TElement Element) in Entries) {
					if (Equals(Index, index)) {
						return Element;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				for (nint i = 0; i < Count; i++) {
					if (Equals(Entries[i].Index, index)) {
						Entries[i].Element = value;
						return;
					}
				}
				Add(index, value);
			}
		}

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public ArrayEnumerator<(TIndex Index, TElement Element)> GetEnumerator() => new ArrayEnumerator<(TIndex Index, TElement Element)>(Entries, Count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<(TIndex Index, TElement Element)> System.Collections.Generic.IEnumerable<(TIndex Index, TElement Element)>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public void Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			foreach ((TIndex Index, TElement Element) in Entries) {
				if (Equals(Index, index)) {
					return;
				}
			}
			Add(index, element);
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Entries);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => Collection.ToString(Entries, amount);

		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="index">The index of the element to add.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual void Add([DisallowNull] TIndex index, [AllowNull] TElement element) => Entries[Count++] = (index, element);
	}
}
