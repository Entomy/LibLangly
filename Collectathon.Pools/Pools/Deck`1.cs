using System;
using System.Traits;
using System.Traits.Concepts;
using System.Traits.Providers;
using Collectathon.Enumerators;

namespace Collectathon.Pools {
	/// <summary>
	/// Represents a deck, a type of retention pool in which the objects can be shuffled and randomly accessed like a deck of cards.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the deck.</typeparam>
	public sealed class Deck<TElement> :
		IClear,
		IContainsAll<TElement>, IContainsAny<TElement>,
		IPeek<TElement>,
		IRemove<TElement>,
		ISequence<TElement, DeckEnumerator<TElement>> {
		/// <summary>
		/// The elements of this deck.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="dealt"/>.
		/// </remarks>
		private readonly TElement[] cards;

		/// <summary>
		/// The random number generator used for shuffling.
		/// </summary>
		private readonly Numbersome.Random Random = new();

		/// <summary>
		/// Whether each corresponding card was dealt.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="cards"/>.
		/// </remarks>
		private readonly Boolean[] dealt;

		/// <summary>
		/// The "card" index; the current top of the deck.
		/// </summary>
		private nint i;

		/// <summary>
		/// Initializes a new <see cref="Deck{TElement}"/>.
		/// </summary>
		/// <param name="elements">The elements in the deck.</param>
		public Deck(params TElement[] elements) {
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
		public Boolean Contains(TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					if (!dealt[i]) { return true; }
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public Boolean Contains(Predicate<TElement>? predicate) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (predicate?.Invoke(cards[i]) ?? cards[i] is null) {
					if (!dealt[i]) { return true; }
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public Boolean ContainsAll(params TElement[]? elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					if (!Contains(element)) { return false; }
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public Boolean ContainsAny(params TElement[]? elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					if (Contains(element)) { return true; }
				}
			}
			return false;
		}

		/// <summary>
		/// Deals the next element from the deck.
		/// </summary>
		/// <returns>The next <typeparamref name="TElement"/>.</returns>
		public TElement Deal() {
			Peek(out TElement element);
			dealt[i] = true;
			return element;
		}

		/// <summary>
		/// Deals <paramref name="amount"/> of elements from the deck.
		/// </summary>
		/// <param name="amount">The amount of elements to deal.</param>
		/// <returns>An <see cref="System.Collections.Generic.IEnumerable{T}"/> of <typeparamref name="TElement"/>.</returns>
		public System.Collections.Generic.IEnumerable<TElement> Deal(nint amount) {
			for (Int32 i = 0; i < amount; i++) {
				yield return Deal();
			}
		}

		/// <inheritdoc/>
		public DeckEnumerator<TElement> GetEnumerator() => new DeckEnumerator<TElement>(cards, dealt, listDealt: true, listRemaining: true);

		/// <inheritdoc/>
		public void Peek(out TElement element) {
			while (dealt[i]) {
				Shuffle();
			}
			element = cards[i];
		}

		/// <inheritdoc/>
		public TElement Peek() {
			while (dealt[i]) {
				Shuffle();
			}
			return cards[i];
		}

		/// <inheritdoc/>
		public void Remove(TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					dealt[i] = true;
				}
			}
		}

		/// <inheritdoc/>
		public void RemoveFirst(TElement element) {
			for (Int32 i = 0; i < cards.Length; i++) {
				if (Equals(cards[i], element)) {
					dealt[i] = true;
					return;
				}
			}
		}

		/// <inheritdoc/>
		public void RemoveLast(TElement element) {
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
		public override String ToString() => Collection.ToString(cards);

		/// <inheritdoc/>
		public String ToString(Int32 amount) => Collection.ToString(cards, amount);
	}
}
