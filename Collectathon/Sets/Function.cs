using System;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon.Sets {
	/// <summary>
	/// Represents a literal set defined by a <see cref="System.Predicate{T}"/>.
	/// </summary>
	internal sealed class Function<TElement> : Set<TElement> where TElement : IEquatable<TElement> {
		/// <summary>
		/// The backing predicate of the set.
		/// </summary>
		[NotNull] private readonly Predicate<TElement> Predicate;

		/// <inheritdoc/>
		internal Function([NotNull] Predicate<TElement> predicate) => Predicate = predicate;

		/// <inheritdoc/>
		protected override Boolean Contains(TElement element) => Predicate(element);
	}
}
