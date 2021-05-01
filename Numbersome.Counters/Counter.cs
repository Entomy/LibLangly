using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using Collectathon.Arrays;

namespace Numbersome {
	/// <summary>
	/// Represents a counter, a structure to assist with sophisticated counting operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being counted.</typeparam>
	/// <remarks>
	/// <para>This isn't intended for counting a single thing over and over. Rather, it's meant for counting collections of things all at once, and then doing things with those counts.</para>
	/// </remarks>
	public sealed class Counter<TElement> :
		IAdd<TElement, Counter<TElement>>,
		IClear<Counter<TElement>>,
		IContains<TElement>,
		IIndexReadOnly<TElement, nint>,
		ISequence<(TElement Element, nint Count), DynamicArray<TElement, nint>.Enumerator> {
		/// <summary>
		/// The backing association of this <see cref="Counter{TElement}"/>.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly DynamicArray<TElement, nint> Elements;

		/// <summary>
		/// Initializes a new <see cref="Counter{TElement}"/>.
		/// </summary>
		public Counter() => Elements = new DynamicArray<TElement, nint>();

		/// <inheritdoc/>
		public nint Count => Elements.Count;

		/// <summary>
		/// Get the element with the highest count.
		/// </summary>
		[MaybeNull]
		public TElement Highest {
			get {
				(TElement Element, nint Count) high = (default, nint.MinValue);
				foreach ((TElement Element, nint Count) in Elements) {
					if (high.Count < Count) {
						high.Element = Element;
						high.Count = Count;
					}
				}
				return high.Element;
			}
		}

		/// <summary>
		/// Get the element with the lowest count.
		/// </summary>
		[MaybeNull]
		public TElement Lowest {
			get {
				(TElement Element, nint Count) low = (default, nint.MaxValue);
				foreach ((TElement Element, nint Count) in Elements) {
					if (low.Count > Count) {
						low.Element = Element;
						low.Count = Count;
					}
				}
				return low.Element;
			}
		}

		/// <inheritdoc/>
		public nint this[[AllowNull] TElement index] => Elements[index];

		/// <inheritdoc/>
		[return: MaybeNull]
		public Counter<TElement> Add([AllowNull] TElement element) {
			if (Contains(element)) {
				Elements[element]++;
				return this;
			} else {
				return Elements.Insert(element, 1) is not null ? this : null;
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public Counter<TElement> Clear() {
			_ = Elements.Clear();
			return this;
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) {
			foreach ((TElement Element, nint Count) in Elements) {
				if (Equals(Element, element)) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public DynamicArray<TElement, nint>.Enumerator GetEnumerator() => new DynamicArray<TElement, nint>.Enumerator(Elements);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => ToString(Count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(nint amount) => ISequence<(TElement, nint), DynamicArray<TElement, nint>.Enumerator>.ToString(this, amount);
	}
}
