using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents any possible literal, a <see cref="Pattern"/> representing exactly itself.
	/// </summary>
	internal abstract class Literal : Primative {
		/// <summary>
		/// The <see cref="Case"/> to use when parsing.
		/// </summary>
		internal readonly Case Casing;

		/// <summary>
		/// Intialize a new <see cref="Literal"/> with the given <paramref name="casing"/>.
		/// </summary>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		protected Literal(Case casing) => Casing = casing;

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override Pattern Then([AllowNull] Pattern other) {
			switch (other) {
			case Literal literal:
				if (Casing == literal.Casing) {
					return new StringLiteral($"{this}{literal}", Casing);
				} else {
					goto default;
				}
			default:
				return base.Then(other);
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override Pattern Then(Char other) {
			switch (Casing) {
			case Case.Insensitive:
				return new StringLiteral($"{this}{other}");
			default:
				return new Concatenator(this, new CharLiteral(other));
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override Pattern Then(Rune other) {
			switch (Casing) {
			case Case.Insensitive:
				return new StringLiteral($"{this}{other}");
			default:
				return new Concatenator(this, new RuneLiteral(other));
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public sealed override Pattern Then([AllowNull] String other) {
			switch (Casing) {
			case Case.Insensitive:
				return new StringLiteral($"{this}{other}");
			default:
				return other is not null ? new Concatenator(this, new StringLiteral(other)) : this;
			}
		}

		/// <inheritdoc/>
		[return: NotNull]
		public abstract override String ToString();
	}
}
