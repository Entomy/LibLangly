using System;
using System.Text;
using Philosoft;

namespace Stringier.Categories {
	/// <summary>
	/// Represents the intersection between two <see cref="Category"/>.
	/// </summary>
	internal sealed class Intersection : Category {
		/// <summary>
		/// The first collection of the intersection.
		/// </summary>
		private readonly Category First;

		/// <summary>
		/// The second collection of the intersection.
		/// </summary>
		private readonly Category Second;

		/// <inheritdoc/>
		internal Intersection(Category first, Category second) {
			First = first;
			Second = second;
		}

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => First.Contains(element) && Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => First.Contains(element) && Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => First.Contains(element) && Second.Contains(element);
	}
}
