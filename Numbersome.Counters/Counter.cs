using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace Numbersome {
	/// <summary>
	/// Represents a counter, a structure to assist with sophisticated counting operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being counted.</typeparam>
	/// <remarks>
	/// <para>This isn't intended for counting a single thing over and over. Rather, it's meant for counting collections of things all at once, and then doing things with those counts.</para>
	/// </remarks>
	public sealed partial class Counter<TElement> :
		IAdd<TElement>,
		IClear,
		IContains<TElement>,
		IIndexReadOnly<TElement, Int32>,
		ISequence<(TElement? Element, Int32 Count), Counter<TElement>.Enumerator> {
		/// <summary>
		/// The elements of this <see cref="Counter{TElement}"/>.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Counts"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private TElement?[] Elements;

		/// <summary>
		/// The counts of this <see cref="Counter{TElement}"/>.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Elements"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private Int32[] Counts;

		/// <summary>
		/// The amount of entries in the <see cref="Counter{TElement}"/>.
		/// </summary>
		private Int32 count;

		/// <summary>
		/// Initializes a new <see cref="Counter{TElement}"/>.
		/// </summary>
		public Counter() {
			Elements = Array.Empty<TElement>();
			Counts = Array.Empty<Int32>();
		}

		/// <inheritdoc/>
		public Int32 Count {
			get {
				Int32 c = 0;
				foreach (Int32 count in Counts) {
					c += count;
				}
				return c;
			}
		}

		/// <summary>
		/// Get the element with the highest count.
		/// </summary>
		[MaybeNull]
		public TElement Highest {
			get {
				TElement? Element = default;
				Int32 Count = Int32.MinValue;
				for (Int32 i = 0; i < count; i++) {
					if (Count < Counts[i]) {
						Element = Elements[i];
						Count = Counts[i];
					}
				}
				return Element;
			}
		}

		/// <summary>
		/// Get the element with the lowest count.
		/// </summary>
		[MaybeNull]
		public TElement Lowest {
			get {
				TElement? Element = default;
				Int32 Count = Int32.MaxValue;
				for (Int32 i = 0; i < count; i++) {
					if (Count > Counts[i]) {
						Element = Elements[i];
						Count = Counts[i];
					}
				}
				return Element;
			}
		}

		/// <inheritdoc/>
		public Int32 this[[AllowNull] TElement index] {
			get {
				for (nint i = 0; i < count; i++) {
					if (Equals(Elements[i], index)) {
						return Counts[i];
					}
				}
				return 0;
			}
		}

		/// <inheritdoc/>
		public void Add([AllowNull] TElement element) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(Elements[i], element)) {
					Counts[i]++;
					return;
				}
			}
			// If we reach this point, the element didn't exist, so we need to add it
			// Do the underlying arrays need resizing?
			if (count >= Elements.Length) {
				Elements = Collection.Grow(Elements);
				Counts = Collection.Grow(Counts);
			}
			// Add the entry
			Elements[count] = element;
			Counts[count] = 1;
			count++;
		}

		/// <inheritdoc/>
		public void Clear() {
			Elements = Array.Empty<TElement>();
			Counts = Array.Empty<Int32>();
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) => Collection.Contains(Elements, Elements.Length, element);

		/// <inheritdoc/>
		[return: NotNull]
		public Enumerator GetEnumerator() => new Enumerator(Elements, Counts, count);

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<(TElement Element, Int32 Count)> System.Collections.Generic.IEnumerable<(TElement Element, Int32 Count)>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(Elements, count);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(Elements, count);
	}
}
