namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents any possible literal, a <see cref="Pattern"/> <see cref="Node"/> representing exactly itself.
	/// </summary>
	internal abstract class Literal : Primative {
		/// <summary>
		/// The <see cref="Compare"/> to use when parsing.
		/// </summary>
		internal readonly Compare ComparisonType;

		/// <summary>
		/// Initialize a new <see cref="Literal"/> with the default <see cref="Compare"/> (<see cref="Compare.CaseSensitive"/>).
		/// </summary>
		protected Literal() => ComparisonType = Compare.CaseSensitive;

		/// <summary>
		/// Intialize a new <see cref="Literal"/> with the given <paramref name="comparisonType"/>.
		/// </summary>
		/// <param name="comparisonType">The <see cref="Compare"/> to use when parsing.</param>
		protected Literal(Compare comparisonType) => ComparisonType = comparisonType;
	}
}
