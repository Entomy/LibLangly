using System;
using Collectathon.Sets;
using Philosoft;

namespace Stringier.Categories {
	/// <summary>
	/// A helper class for creation of categories which are based on existance within a contiguous range.
	/// </summary>
	/// <remarks>
	/// This offers a very small performance improvement over <see cref="SetCategory"/> even though <see cref="Set{TElement}"/> can also handle ranges. This is because, since we know specifically how <see cref="Category"/> is being used, we know we can reasonably precompute the margin and use that for existence checks.
	/// </remarks>
	internal sealed class RangeCategory : Category {
		/// <summary>
		/// The lower bound, inclusive.
		/// </summary>
		private readonly UInt32 Lower;

		/// <summary>
		/// The range margin. This is a precalculation of part of the optimal range check, and is essentially the "length" of the range.
		/// </summary>
		private readonly UInt32 Margin;

		/// <summary>
		/// Initializes a new <see cref="Category"/> with the given <paramref name="lower"/>..<paramref name="upper"/> range.
		/// </summary>
		/// <param name="lower">The lower bound, inclusive.</param>
		/// <param name="upper">The upper bound, inclusive.</param>
		internal RangeCategory(UInt32 lower, UInt32 upper) {
			Lower = lower;
			Margin = upper - lower;
		}

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => element - Lower <= Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => element.Code - Lower <= Margin;
	}
}
