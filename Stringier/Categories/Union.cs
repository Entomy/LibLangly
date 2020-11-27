using System;
using System.Text;

namespace Langly {
	/// <summary>
	/// Represents the union of two <see cref="Category"/>.
	/// </summary>
	internal sealed class Union : Category {
		/// <summary>
		/// The first collection of the union.
		/// </summary>
		private readonly Category First;

		/// <summary>
		/// The second collection of the union.
		/// </summary>
		private readonly Category Second;

		/// <inheritdoc/>
		internal Union(Category first, Category second) {
			First = first;
			Second = second;
		}

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => First.Contains(element) || Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => First.Contains(element) || Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => First.Contains(element) || Second.Contains(element);
	}
}
