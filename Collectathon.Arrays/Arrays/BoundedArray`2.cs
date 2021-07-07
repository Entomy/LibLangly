using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Enumerators;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents an associative bounded array, a type of flexible array who's size can not grow above its capacity, but can freely resize below that capacity.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class BoundedArray<TIndex, TElement> :
		IArray<TIndex, TElement>,
		IClear,
		IInsert<TIndex, TElement>,
		IList<TIndex, TElement>,
		ISequence<(TIndex Index, TElement? Element), ArrayEnumerator<TIndex, TElement?>> {
		/// <summary>
		/// The indicies of this <see cref="BoundedArray{TIndex, TElement}"/>.
		/// </summary>
		private readonly TIndex[] Indicies;

		/// <summary>
		/// The elements of this <see cref="BoundedArray{TIndex, TElement}"/>.
		/// </summary>
		private readonly TElement?[] Elements;

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(Int32 capacity) {
			Indicies = new TIndex[capacity];
			Elements = new TElement?[capacity];
		}

		/// <inheritdoc/>
		public Int32 Capacity => Indicies.Length;

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				for (Int32 i = 0; i < Count; i++) {
					if (Equals(Indicies[i], index)) {
						return Elements[i];
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				for (Int32 i = 0; i < Count; i++) {
					if (Equals(Indicies[i], index)) {
						Elements[i] = value;
						return;
					}
				}
				Add(index, value);
			}
		}

		/// <inheritdoc/>
		public void Clear() => Count = 0;

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Elements, Count, element);

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] Predicate<TElement> predicate) => Collection.Contains(Elements, Count, predicate);

		/// <inheritdoc/>
		public ArrayEnumerator<TIndex, TElement?> GetEnumerator() => new ArrayEnumerator<TIndex, TElement?>(Indicies, Elements, Count);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public void Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			for (Int32 i = 0; i < Count; i++) {
				if (Equals(Indicies[i], index)) {
					return;
				}
			}
			Add(index, element);
		}

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => Collection.Replace(Elements, Count, search, replace);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Indicies, Elements);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Indicies, Elements, amount);

		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="index">The index of the element to add.</param>
		/// <param name="element">The element to add.</param>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		private void Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count < Capacity) {
				Indicies[Count] = index;
				Elements[Count] = element;
				Count++;
			} else {
				throw new InvalidOperationException();
			}
		}
	}
}
