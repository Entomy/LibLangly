using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Enumerators;

namespace Collectathon.Pools {
	/// <summary>
	/// Represents a deck, a type of retention pool in which the objects can be shuffled and randomly accessed like a deck of cards.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the deck.</typeparam>
	public sealed class Deck<TElement> :
		IClear,
		IContains<TElement>,
		IControlled,
		IPeek<TElement>,
		IRemove<TElement>,
		ISequence<TElement, DeckEnumerator<TElement>> {
		/// <summary>
		/// The elements of this deck.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="dealt"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private readonly TElement[] cards;

		/// <summary>
		/// The random number generator used for shuffling.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Numbersome.Random Random = new();
		/// <summary>
		/// Whether each corresponding card was dealt.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="cards"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private Boolean[] dealt;

		/// <summary>
		/// The "card" index; the current top of the deck.
		/// </summary>
		private nint i;

		/// <summary>
		/// Initializes a new <see cref="Deck{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements in the deck.</param>
		public Deck([DisallowNull] params TElement[] elements) {
			cards = elements;
			dealt = new Boolean[elements.Length];
			Shuffle();
		}

		/// <inheritdoc/>
		public Int32 Count {
			get {
				Int32 c = 0;
				foreach (Boolean dlt in dealt) {
					c += dlt ? 0 : 1;
				}
				return c;
			}
		}

		/// <summary>
		/// Gets the dealt elements from this deck.
		/// </summary>
		public DeckEnumerator<TElement> Dealt => new DeckEnumerator<TElement>(cards, dealt, listDealt: true, listRemaining: false);

		/// <inheritdoc/>
		Boolean IControlled.Disposed { get; set; }

		/// <inheritdoc/>
		public Boolean Readable {
			get {
				foreach (Boolean dlt in dealt) {
					if (!dlt) return true;
				}
				return false;
			}
		}
		/// <summary>
		/// Gets the remaining elements in this deck.
		/// </summary>
		public DeckEnumerator<TElement> Remaining => new DeckEnumerator<TElement>(cards, dealt, listDealt: false, listRemaining: true);

		/// <inheritdoc/>
		public void Clear() {
			for (nint i = 0; i < dealt.Length; i++) {
				dealt[i] = false;
			}
		}

		/// <inheritdoc/>
		public Boolean Contains([AllowNull] TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					if (!dealt[i]) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Deals the next element from the deck.
		/// </summary>
		/// <returns>The next <typeparamref name="TElement"/>.</returns>
		[return: MaybeNull]
		public TElement Deal() {
			Peek(out TElement? element);
			dealt[i] = true;
			return element;
		}

		/// <summary>
		/// Deals <paramref name="amount"/> of elements from the deck.
		/// </summary>
		/// <param name="amount">The amount of elements to deal.</param>
		/// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> of <typeparamref name="TElement"/>.</returns>
		public System.Collections.Generic.IEnumerable<TElement?> Deal(nint amount) {
			for (Int32 i = 0; i < amount; i++) {
				yield return Deal();
			}
		}

		/// <inheritdoc/>
		void IControlled.DisposeManaged() => ((IControlled)Random).Dispose();

		/// <inheritdoc/>
		void IControlled.DisposeUnmanaged() { /* No-op */ }

		/// <inheritdoc/>
		public DeckEnumerator<TElement> GetEnumerator() => new DeckEnumerator<TElement>(cards, dealt, listDealt: true, listRemaining: true);

		/// <inheritdoc/>
		void IControlled.NullLargeFields() => dealt = null!;

		/// <inheritdoc/>
		public void Peek([MaybeNull] out TElement element) {
			while (dealt[i]) {
				Shuffle();
			}
			element = cards[i];
		}

		/// <inheritdoc/>
		[return: MaybeNull]
		public TElement Peek() {
			while (dealt[i]) {
				Shuffle();
			}
			return cards[i];
		}

		/// <inheritdoc/>
		public void Remove([AllowNull] TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					dealt[i] = true;
				}
			}
		}

		/// <inheritdoc/>
		public void RemoveFirst([AllowNull] TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					dealt[i] = true;
					return;
				}
			}
		}

		/// <inheritdoc/>
		public void RemoveLast([AllowNull] TElement element) {
			for (Int32 i = cards.Length - 1; i >= 0; i--) {
				if (Equals(cards[i], element)) {
					dealt[i] = true;
					return;
				}
			}
		}

		/// <summary>
		/// Shuffles the deck, randomizing the objects.
		/// </summary>
		/// <remarks>
		/// This doesn't literally shuffle objects, as that would be an insanely expensive operation. Instead, this creates the appearance of shuffling.
		/// </remarks>
		public void Shuffle() {
			i += Math.Abs(Random.NextInt16());
			while (i > cards.Length) {
				i %= cards.Length;
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Collection.ToString(cards);

		/// <inheritdoc/>
		[return: NotNull]
		public String ToString(Int32 amount) => Collection.ToString(cards, amount);
	}
}
