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
		ISequence<(TIndex Index, TElement Element), ArrayEnumerator<(TIndex Index, TElement Element)>> {
		/// <summary>
		/// The backing array of this <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		private readonly (TIndex Index, TElement? Element)[] Entries;

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/>.
		/// </summary>
		public BoundedArray() => Entries = Array.Empty<(TIndex, TElement?)>();

		/// <summary>
		/// Initializes a new <see cref="BoundedArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public BoundedArray(Int32 capacity) => Entries = new (TIndex, TElement?)[capacity];

		/// <inheritdoc/>
		public Int32 Capacity => Entries.Length;

		/// <inheritdoc/>
		public Int32 Count { get; private set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				foreach ((TIndex Index, TElement? Element) in Entries) {
					if (Equals(Index, index)) {
						return Element;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				for (Int32 i = 0; i < Count; i++) {
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
		public Boolean Contains([AllowNull] TElement element) => throw new NotImplementedException();

		/// <inheritdoc/>
		public ArrayEnumerator<(TIndex Index, TElement? Element)> GetEnumerator() => new ArrayEnumerator<(TIndex Index, TElement Element)>(Entries, Count);

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
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => throw new NotImplementedException();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Entries);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Entries, amount);

		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="index">The index of the element to add.</param>
		/// <param name="element">The element to add.</param>
		/// <exception cref="InvalidOperationException">Thrown if the array is at maximum capacity.</exception>
		private void Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count < Capacity) {
				Entries[Count++] = (index, element);
			} else {
				throw new InvalidOperationException();
			}
		}
	}
}
