using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents any possible literal, a <see cref="Pattern"/> <see cref="Node"/> representing exactly itself.
	/// </summary>
	internal abstract class Literal : Node {
		/// <summary>
		/// The <see cref="StringComparison"/> to use when parsing.
		/// </summary>
		internal readonly StringComparison ComparisonType = StringComparison.Ordinal;

		/// <summary>
		/// Initialize a new <see cref="Literal"/> with the default <see cref="StringComparison"/>.
		/// </summary>
		protected Literal() => ComparisonType = StringComparison.Ordinal;

		/// <summary>
		/// Intialize a new <see cref="Literal"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use when parsing.</param>
		protected Literal(StringComparison comparisonType) => ComparisonType = comparisonType;
	}
}
