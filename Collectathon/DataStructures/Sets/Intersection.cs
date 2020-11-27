using System;

namespace Langly.DataStructures.Sets {
	/// <summary>
	/// Represents the intersection between two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Intersection<TElement> : Combinator<TElement> where TElement : IEquatable<TElement> {
		/// <inheritdoc/>
		internal Intersection(Set<TElement> first, Set<TElement> second) : base(first, second) { }

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => First.Contains(element) && Second.Contains(element);
	}
}
