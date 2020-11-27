using System;
using Langly.DataStructures.Sets;

namespace Langly {
	/// <summary>
	/// A helper class for creation of categories which are based on algorithmic existance.
	/// </summary>
	internal sealed class SetCategory : Category {
		/// <summary>
		/// The algorithm used to determine existance within the category.
		/// </summary>
		private readonly Set<UInt32> Set;

		/// <summary>
		/// Initialize a new <see cref="Category"/> with the given <paramref name="set"/>.
		/// </summary>
		/// <param name="set">The <see cref="Set{TElement}"/> defining this category.</param>
		internal SetCategory(Set<UInt32> set) => Set = set;

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => Set.Contains(element.Code);
	}
}
