using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to span.</param>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern operator +([AllowNull] Pattern pattern) => pattern?.Many();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: NotNull]
		public virtual Pattern Many() => new Spanner(this);
	}
}
