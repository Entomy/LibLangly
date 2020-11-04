using System;
using System.Text;
using Philosoft;

namespace Stringier.Categories {
	/// <summary>
	/// Represents the complement of a <see cref="Category"/>.
	/// </summary>
	internal sealed class Complement : Category {
		/// <summary>
		/// The set being complimented.
		/// </summary>
		private readonly Category Set;

		/// <inheritdoc/>
		internal Complement(Category set) => Set = set;

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => !Set.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => !Set.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => !Set.Contains(element);
	}
}
