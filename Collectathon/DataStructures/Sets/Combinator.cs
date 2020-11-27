using System;

namespace Langly.DataStructures.Sets {
	/// <summary>
	/// Represents the combination of two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal abstract class Combinator<TElement> : Set<TElement> where TElement : IEquatable<TElement> {
		/// <summary>
		/// The first collection.
		/// </summary>
		protected readonly Set<TElement> First;

		/// <summary>
		/// The second collection.
		/// </summary>
		protected readonly Set<TElement> Second;

		/// <inheritdoc/>
		protected Combinator(Set<TElement> first, Set<TElement> second) {
			First = first;
			Second = second;
		}
	}
}
