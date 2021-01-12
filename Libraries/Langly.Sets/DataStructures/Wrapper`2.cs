using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a literal set defined by the instance of <typeparamref name="TContainer"/> wrapped into a <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <typeparam name="TContainer">The type of the backing collection.</typeparam>
	internal sealed class Wrapper<TElement, TContainer> : Set<TElement>
		where TContainer : IContains<TElement> {
		/// <summary>
		/// The backing container of the set.
		/// </summary>
		private readonly TContainer Container;

		/// <summary>
		/// Intializes a new <see cref="Wrapper{TElement, TContainer}"/>.
		/// </summary>
		/// <param name="container">The backing container of the set.</param>
		internal Wrapper(TContainer container) => Container = container;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => Container.Contains(element);
	}
}
