using System;
using Langly;

namespace Collectathon.DataStructures.Counters {
	/// <summary>
	/// Represents a counter, a collection of elements with an associated count of that elements current occurrences.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	/// <remarks>
	/// This is recommended for counting in more complicated situations than <see cref="IEnumerable{TElement, TEnumerator}.Occurrences(TElement)"/> and related methods can handle.
	/// </remarks>
	public sealed class Counter<TElement> : IAddable<TElement>, ICountable {
		/// <summary>
		/// The counts of the elements.
		/// </summary>
		protected readonly nint[] Counts;

		/// <summary>
		/// The elements being counted.
		/// </summary>
		protected readonly TElement[] Elements;

		/// <summary>
		/// Initializes a new <see cref="Counter{TElement}"/> for counting the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <typeparamref name="TElement"/> to count.</param>
		public Counter(params TElement[] elements) {
			Elements = elements ?? Array.Empty<TElement>();
			Counts = new nint[elements?.Length ?? 0];
		}

		/// <inheritdoc/>
		public nint Count {
			get {
				nint count = 0;
				foreach (nint c in Counts) {
					count += c;
				}
				return count;
			}
		}

		/// <summary>
		/// Gets or sets the count of the specified element.
		/// </summary>
		/// <param name="element">The element to get the count of.</param>
		/// <returns>The count of the specified element.</returns>
		public nint this[TElement element] {
			get {
				for (nint i = 0; i < Count; i++) {
					if (Elements[i]?.Equals(element) ?? false) {
						return Counts[i];
					}
				}
				return 0;
			}
			set {
				for (nint i = 0; i < Count; i++) {
					if (Elements[i]?.Equals(element) ?? false) {
						Counts[i] = value;
					}
				}
			}
		}

		/// <inheritdoc/>
		void IAddable<TElement>.Add(TElement element) {
			for (nint i = 0; i < Elements.Length; i++) {
				if (Elements[i]?.Equals(element) ?? false) {
					Counts[i]++;
				}
			}
		}

		/// <summary>
		/// Count all occurrences of <paramref name="element"/> in the collection.
		/// </summary>
		/// <param name="element">The element to count.</param>
		/// <returns>The amount of occurrences found.</returns>
		public nint Occurrences(TElement element) => this[element];
	}
}
