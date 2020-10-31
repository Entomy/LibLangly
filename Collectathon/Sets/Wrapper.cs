using Philosoft;
using System;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents a literal set defined by the instance of <typeparamref name="TCollection"/> this wraps into a <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <typeparam name="TCollection">The type of the backing collection.</typeparam>
	internal sealed class Wrapper<TElement, TCollection> : Set<TElement> where TElement : IEquatable<TElement> where TCollection : IContainable<TElement> {
		/// <summary>
		/// The backing collection of the set.
		/// </summary>
		private readonly TCollection Collection;

		/// <inheritdoc/>
		internal Wrapper(TCollection collection) => Collection = collection;

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => Collection.Contains(element);
	}
}
