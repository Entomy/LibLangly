using Langly;
using System;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents the complement of a <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Complement<TElement> : Set<TElement> where TElement : IEquatable<TElement> {
		/// <summary>
		/// The set being complemented.
		/// </summary>
		private readonly Set<TElement> Set;

		/// <inheritdoc/>
		internal Complement(Set<TElement> set) => Set = set;

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => !Set.Contains(element);
	}
}
