using Philosoft;
using System;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents the difference between two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	internal sealed class Difference<TElement> : Combinator<TElement> where TElement : IEquatable<TElement> {
		/// <inheritdoc/>
		internal Difference(Set<TElement> first, Set<TElement> second) : base(first, second) { }

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => First.Contains(element) && !Second.Contains(element);
	}
}
