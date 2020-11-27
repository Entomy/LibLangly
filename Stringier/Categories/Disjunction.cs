using System;
using System.Text;

namespace Langly {
	/// <summary>
	/// Represents the difference between two <see cref="Category"/>.
	/// </summary>
	internal sealed class Disjunction : Category {
		/// <summary>
		/// The first collection of the disjunction.
		/// </summary>
		private readonly Category First;

		/// <summary>
		/// The second collection of the disjunction.
		/// </summary>
		private readonly Category Second;

		/// <inheritdoc/>
		internal Disjunction(Category first, Category second) {
			First = first;
			Second = second;
		}

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => First.Contains(element) ^ Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => First.Contains(element) ^ Second.Contains(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => First.Contains(element) ^ Second.Contains(element);
	}
}
