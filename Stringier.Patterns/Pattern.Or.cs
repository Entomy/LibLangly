using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="Pattern"/>; checked first.</param>
		/// <param name="right">The righthand <see cref="Pattern"/>; checked last.</param>
		/// <returns>A new <see cref="Pattern"/> matching <paramref name="left"/> or <paramref name="right"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("left"), NotNullIfNotNull("right")]
		public static Pattern operator |([AllowNull] Pattern left, [AllowNull] Pattern right) => left?.Or(right) ?? right;

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Or([AllowNull] Pattern other) {
			switch (other) {
			case ChainAlternator chain:
				return new ChainAlternator(this, chain.Patterns);
			default:
				return other is not null ? new Alternator(this, other) : this;
			}
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Or(Char other) => new Alternator(this, new CharLiteral(other));

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Rune"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Or(Rune other) => new Alternator(this, new RuneLiteral(other));
#endif

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> matching this <see cref="Pattern"/> or <paramref name="other"/>.</returns>
		[return: NotNull]
		public virtual Pattern Or([AllowNull] String other) => other is not null ? new Alternator(this, new MemoryLiteral(other)) : this;
	}
}
