using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	public partial class Pattern {
		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public virtual Pattern To([DisallowNull] Pattern to) => new Ranger(this, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		/// <param name="escape">The escape <see cref="Pattern"/>./</param>
		/// <remarks>
		/// If <paramref name="escape"/> is <see langword="null"/> this does the same as <see cref="To(Pattern)"/>.
		/// </remarks>
		[return: NotNull]
		public virtual Pattern To([DisallowNull] Pattern to, [AllowNull] Pattern escape) => escape is not null ? new EscapedRanger(this, to, escape) : new Ranger(this, to);

		/// <summary>
		/// Create a pattern representing the range from this <see cref="Pattern"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="to">The ending <see cref="Pattern"/>.</param>
		[return: NotNull]
		public virtual Pattern ToNested([DisallowNull] Pattern to) => new NestedRanger(this, to);
	}
}
