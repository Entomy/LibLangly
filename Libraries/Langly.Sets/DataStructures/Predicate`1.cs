using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a literal set defined by a <see cref="System.Predicate{T}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the set.</typeparam>
	internal sealed class Predicate<TElement> : Set<TElement> {
		/// <summary>
		/// The backing predicate of the set.
		/// </summary>
		private readonly System.Predicate<TElement> Check;

		/// <summary>
		/// Initializes a new <see cref="Predicate{TElement}"/>.
		/// </summary>
		/// <param name="predicate">The backing predicate of the set.</param>
		internal Predicate([DisallowNull] System.Predicate<TElement> predicate) => Check = predicate;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => Check(element);
	}
}
