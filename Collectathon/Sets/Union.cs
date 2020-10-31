using Philosoft;
using System;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents the union of two <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	internal sealed class Union<TElement> : Combinator<TElement> where TElement : IEquatable<TElement> {
		/// <inheritdoc/>
		internal Union(Set<TElement> first, Set<TElement> second) : base(first, second) { }

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => First.Contains(element) || Second.Contains(element);
	}
}
