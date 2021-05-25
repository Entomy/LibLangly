using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <see cref="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		[return: NotNull]
		public virtual Pattern Capture([DisallowNull, NotNull] out Capture capture) => new Capturer(this, out capture);

		/// <summary>
		/// Declares the <paramref name="pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to capture.</param>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <see cref="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		[return: NotNull]
		public static Pattern Capture([DisallowNull] Pattern pattern, [DisallowNull, NotNull] out Capture capture) => pattern.Capture(out capture);
	}
}
