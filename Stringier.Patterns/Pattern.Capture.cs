using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="capture">A <see cref="Stringier.Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <see cref="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		[return: NotNull]
		public virtual Pattern Capture([DisallowNull, NotNull] out Capture capture) => new Capturer(this, out capture);
	}
}
