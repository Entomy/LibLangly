using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;

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
		ISequence<(TElement Element, Int32 Count), Counter<TElement>.Enumerator> {
		/// <summary>
		/// The elements of this <see cref="Counter{TElement}"/>.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Counts"/>.
		/// </remarks>
		private TElement[] Elements;

		/// <summary>
		/// The counts of this <see cref="Counter{TElement}"/>.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Elements"/>.
		/// </remarks>
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
		public TElement Highest {
			get {
				if (count > 0) {
					TElement Element = default!; // Since we know the count is greater than 0, we will iterate through the elements, and this will be set to something valid.
					Int32 Count = Int32.MinValue;
					for (Int32 i = 0; i < count; i++) {
						if (Count < Counts[i]) {
							Element = Elements[i];
							Count = Counts[i];
						}
					}
					return Element;
				} else {
					throw new InvalidOperationException("Can not get the highest count element of an empty counter.");
				}
			}
		}

		/// <summary>
		/// Get the element with the lowest count.
		/// </summary>
		public TElement Lowest {
			get {
				if (count > 0) {
					TElement Element = default!; // Since we know the count is greater than 0, we will iterate through the elements, and this will be set to something valid.
					Int32 Count = Int32.MaxValue;
					for (Int32 i = 0; i < count; i++) {
						if (Count > Counts[i]) {
							Element = Elements[i];
							Count = Counts[i];
						}
					}
					return Element;
				} else {
					throw new InvalidOperationException("Can not get the lowest count element of an empty counter.");
				}
			}
		}

		/// <summary>
		/// Gets the count of the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The element to get the count of.</param>
		/// <returns>The count of the <paramref name="element"/>.</returns>
		public Int32 this[TElement element] {
			get {
				for (nint i = 0; i < count; i++) {
					if (Equals(Elements[i], element)) {
						return Counts[i];
					}
				}
				return 0;
			}
		}

		/// <inheritdoc/>
		[MaybeResizes]
		public void Add(TElement element) {
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
			count = 0;
		}

		/// <inheritdoc/>
		public Boolean Contains(TElement element) => Collection.Contains(Elements, Elements.Length, element);

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) => Collection.Contains(Elements, Elements.Length, predicate);

		/// <summary>
		/// Determines if the two values are equal.
		/// </summary>
		/// <param name="obj">The other object.</param>
		/// <returns><see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Counter<(TElement, Int32)> counter:
				return Equals(counter);
			case (TElement, Int32)[] array:
				return Equals(array);
			case ArraySegment<(TElement, Int32)> segment:
				return Equals(segment);
			case Memory<(TElement, Int32)> memory:
				return Equals(memory);
			case ReadOnlyMemory<(TElement, Int32)> memory:
				return Equals(memory);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Counter<(TElement Element, Int32 Count)>? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(params (TElement Element, Int32 Count)[]? other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ArraySegment<(TElement Element, Int32 Count)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Memory<(TElement Element, Int32 Count)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlyMemory<(TElement Element, Int32 Count)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(Span<(TElement Element, Int32 Count)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Boolean Equals(ReadOnlySpan<(TElement Element, Int32 Count)> other) => Collection.Equals(this, other);

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(Elements, Counts, count);

		/// <inheritdoc/>
		public override String ToString() => Collection.ToString(Elements, count);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(Elements, count);
	}
}
