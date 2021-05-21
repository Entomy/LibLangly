using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier {
	public partial class Pattern {
		/// <summary>
		/// Declares <paramref name="right"/> to come after <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="Pattern"/>; placed first.</param>
		/// <param name="right">The righthand <see cref="Pattern"/>; placed last.</param>
		/// <returns>A new <see cref="Pattern"/> matching <paramref name="left"/> then <paramref name="right"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Pattern operator &([AllowNull] Pattern left, [AllowNull] Pattern right) => left?.Then(right) ?? right;

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Then([AllowNull] Pattern other) => other is not null ? new Concatenator(this, other) : this;

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Then(Char other) => new Concatenator(this, new CharLiteral(other));

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="Rune"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="Rune"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Then(Rune other) => new Concatenator(this, new RuneLiteral(other));

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="other"/> <see cref="String"/>.
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> then <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Then([AllowNull] String other) => other is not null ? new Concatenator(this, new StringLiteral(other)) : this;
	}
}
