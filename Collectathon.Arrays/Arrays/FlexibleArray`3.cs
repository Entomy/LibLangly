using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

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
		IClear<TSelf>,
		IIndex<TIndex, TElement>,
		IInsert<TIndex, TElement, TSelf>,
		ISequence<(TIndex Index, TElement Element), FlexibleArray<TIndex, TElement, TSelf>.Enumerator>
		where TSelf : FlexibleArray<TIndex, TElement, TSelf> {
		/// <summary>
		/// The backing array of this <see cref="FlexibleArray{TIndex, TElement, TSelf}"/>.
		/// </summary>
		protected (TIndex Index, TElement Element)[] Memory;

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The initial capacity.</param>
		/// <param name="count">The amount of elements in the array.</param>
		protected FlexibleArray(nint capacity, nint count) {
			Memory = new (TIndex, TElement)[capacity];
			Count = count;
		}

		/// <summary>
		/// Initializes a new <see cref="FlexibleArray{TElement, TSelf}"/> with the given <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Array"/> of (<typeparamref name="TIndex"/>, <typeparamref name="TElement"/>) to reuse.</param>
		/// <param name="count">The amount of elements in the array.</param>
		protected FlexibleArray([DisallowNull] (TIndex, TElement)[] memory, nint count) {
			Memory = memory;
			Count = count;
		}

		/// <inheritdoc/>
		public nint Capacity => Memory.Length;

		/// <inheritdoc/>
		public nint Count { get; protected set; }

		/// <inheritdoc/>
		[AllowNull, MaybeNull]
		public TElement this[[DisallowNull] TIndex index] {
			get {
				foreach ((TIndex Index, TElement Element) in Memory) {
					if (Equals(Index, index)) {
						return Element;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set {
				for (nint i = 0; i < Count; i++) {
					if (Equals(Memory[i].Index, index)) {
						Memory[i].Element = value;
						return;
					}
				}
				if (Add(index, value) is not null) {
					throw new InvalidOperationException();
				}
			}
		}

		/// <inheritdoc/>
		TSelf IClear<TSelf>.Clear() {
			Count = 0;
			return (TSelf)this;
		}

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(Memory, Count);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "I'm literally enforcing correct behavior by ensuring downstream doesn't violate what this analyzer is trying to enforce...")]
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		[return: NotNull]
		TSelf IInsert<TIndex, TElement, TSelf>.Insert([DisallowNull] TIndex index, [AllowNull] TElement element) {
			foreach ((TIndex Index, TElement Element) in Memory) {
				if (Equals(Index, index)) {
					return null;
				}
			}
			return Add(index, element);
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => ToString(Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => ISequence<(TIndex, TElement), Enumerator>.ToString(this, amount);

		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="index">The index of the element to add.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TSelf"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		protected virtual TSelf Add([DisallowNull] TIndex index, [AllowNull] TElement element) {
			Memory[Count++] = (index, element);
			return (TSelf)this;
		}
	}
}
