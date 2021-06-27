using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Enumerators;

namespace Collectathon.Arrays {
	/// <summary>
	/// Represents an associative dynamic array, a type of flexible array who's capacity can freely grow and shrink.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the array.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the array.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public sealed class DynamicArray<TIndex, TElement> :
		IArray<TIndex, TElement>,
		IClear,
		IInsert<TIndex, TElement>,
		IResize,
		ISequence<(TIndex Index, TElement Element), ArrayEnumerator<(TIndex Index, TElement Element)>> {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The backing array of this <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		private (TIndex Index, TElement? Element)[] Entries;

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/>.
		/// </summary>
		public DynamicArray() => Entries = Array.Empty<(TIndex, TElement?)>();

		/// <summary>
		/// Initializes a new <see cref="DynamicArray{TIndex, TElement}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The maximum capacity.</param>
		public DynamicArray(Int32 capacity) => Entries = new (TIndex, TElement?)[capacity];

		/// <inheritdoc/>
		public Int32 Capacity {
			get => Entries.Length;
			set => Resize(value);
		}

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
			foreach ((TIndex Index, _) in Entries) {
				if (Equals(Index, index)) {
					return;
				}
			}
			Add(index, element);
		}

		/// <inheritdoc/>
		public void Replace([AllowNull] TElement search, [AllowNull] TElement replace) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Resize(Int32 capacity) {
			(TIndex, TElement)[] newBuffer = new (TIndex, TElement)[capacity];
			Entries.AsMemory(0, capacity > Capacity ? Capacity : capacity).CopyTo(newBuffer);
			Count = Count < capacity ? Count : capacity;
			Entries = newBuffer;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Entries);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Entries, amount);

		/// <inheritdoc/>
		private void Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			if (Count == Capacity) {
				Grow();
			}
			Entries[Count++] = (index, element);
		}

		/// <summary>
		/// Grows this collection by a computed factor.
		/// </summary>
		private void Grow() {
			if (Capacity >= 8) {
				Resize((Int32)(Capacity * φ));
			} else {
				Resize(13);
			}
		}
	}
}
