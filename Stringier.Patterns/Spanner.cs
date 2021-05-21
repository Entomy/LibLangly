using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	/// <summary>
	/// Represents a <see cref="Stringier.Pattern"/> who's content can span. That is, as long as it is present once, can repeat multiple times past that point.
	/// </summary>
	internal sealed class Spanner : Modifier {
		/// <summary>
		/// The <see cref="Stringier.Pattern"/> to be parsed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Pattern Pattern;

		/// <summary>
		/// Initialize a new <see cref="Spanner"/> from the given <paramref name="pattern"/>.
		/// </summary>
		/// <param name="pattern">The <see cref="Stringier.Pattern"/> to be parsed.</param>
		internal Spanner([DisallowNull] Pattern pattern) => Pattern = pattern;

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Maybe() => new KleenesClosure(Pattern);

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Many() => this;
	}
}
