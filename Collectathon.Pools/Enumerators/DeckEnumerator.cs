using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using System.Traits.Concepts;
using Collectathon.Pools;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over a <see cref="Deck{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct DeckEnumerator<TElement> : ICount, ICurrent<TElement?>, IMoveNext, IReset {
		/// <summary>
		/// The elements of this deck.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Dealt"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private readonly TElement?[] Cards;

		/// <summary>
		/// Whether each corresponding card was dealt.
		/// </summary>
		/// <remarks>
		/// This uses array parallelism together with <see cref="Cards"/>.
		/// </remarks>
		[DisallowNull, NotNull]
		private readonly Boolean[] Dealt;

		/// <summary>
		/// Whether to list cards that have been dealt?
		/// </summary>
		private readonly Boolean ListDealt;

		/// <summary>
		/// Whether to list cards that still remain in the deck?
		/// </summary>
		private readonly Boolean ListRemaining;

		/// <summary>
		/// The current index into the <see cref="Deck{TElement}"/>.
		/// </summary>
		private Int32 i;

		/// <summary>
		/// Initializes a new <see cref="DeckEnumerator{TElement}"/>.
		/// </summary>
		public DeckEnumerator([DisallowNull] TElement?[] cards, [DisallowNull] Boolean[] dealt, Boolean listDealt, Boolean listRemaining) {
			Cards = cards;
			Dealt = dealt;
			ListDealt = listDealt;
			ListRemaining = listRemaining;
			i = -1;
		}

		/// <inheritdoc/>
		public TElement? Current => Cards[i];

		/// <inheritdoc/>
		public Int32 Count {
			get {
				Int32 c = 0;
				foreach (Boolean dlt in Dealt) {
					c += dlt ? (ListDealt ? 1 : 0) : (ListRemaining ? 1 : 0);
				}
				return c;
			}
		}

		/// <inheritdoc/>
		public Boolean MoveNext() {
			++i;
			while ((ListDealt && Dealt[i]) || (ListRemaining && !Dealt[i])) {
				i++;
			}
			return i < Count;
		}

		/// <inheritdoc/>
		public void Reset() => i = -1;
	}
}
