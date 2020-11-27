using System;

namespace Langly.DataStructures.Filters {
	/// <summary>
	/// Represents a filter, a component of a collection that helps its functioning, but does not change its function.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	public abstract class Filter<TElement> : ICloneable<Filter<TElement>> {
		/// <inheritdoc/>
		/// <param name="adds">Does this filter on <see cref="IAddable{TElement}"/>?</param>
		/// <param name="contains">Does this filter on <see cref="IContainable{TElement}"/>?</param>
		protected Filter(Boolean adds, Boolean contains) {
			FiltersAdds = adds;
			FiltersContains = contains;
		}

		/// <summary>
		/// Whether this filter effects <see cref="IAddable{TElement}"/> operations.
		/// </summary>
		public Boolean FiltersAdds { get; }

		/// <summary>
		/// Whether this filter effects <see cref="IContainable{TElement}"/> operations.
		/// </summary>
		public Boolean FiltersContains { get; }

		/// <summary>
		/// Gets the type of this filter.
		/// </summary>
		public abstract Filter Type { get; }

		/// <inheritdoc/>
		public abstract Filter<TElement> Clone();

		/// <inheritdoc/>
		Object ICloneable.Clone() => Clone();

		/// <summary>
		/// Determines whether the filtered collection contains a specific <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The object to locate in the collection.</param>
		/// <returns><see cref="Ł3.True"/> if <paramref name="element"/> is found in the collection; <see cref="Ł3.False"/> if <paramref name="element"/> is known to not be in the collection; otherwise, <see cref="Ł3.Unknown"/>.</returns>
		public abstract Ł3 Contains(TElement element);
	}
}
