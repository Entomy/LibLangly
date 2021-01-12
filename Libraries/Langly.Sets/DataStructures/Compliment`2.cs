using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents the compliment of a <see cref="Set{TElement}"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the set.</typeparam>
	/// <typeparam name="TSet">The type of the set being complimented.</typeparam>
	internal sealed class Compliment<TElement, TSet> : Set<TElement>
		where TSet : Set<TElement> {
		/// <summary>
		/// The set being complimented.
		/// </summary>
		private readonly TSet Set;

		/// <inheritdoc/>
		internal Compliment(TSet set) => Set = set;

		/// <inheritdoc/>
		protected override Boolean Contains([AllowNull] TElement element) => !((IContains<TElement>)Set).Contains(element);
	}
}
