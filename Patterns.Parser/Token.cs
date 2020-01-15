using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents any possible token; a lexical element.
	/// </summary>
	internal abstract class Token {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		public static readonly Pattern Pattern = OneOf(Combinator.Pattern, Modifier.Pattern, Number.Pattern, Literal.Pattern);

		/// <summary>
		/// The literal text of the token; how it was parsed.
		/// </summary>
		protected readonly String Text;

		/// <summary>
		/// Initialize a new <see cref="Token"/> with the given <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The literal text of the token; how it was parsed.</param>
		protected Token(String text) => Text = text;

		/// <summary>
		/// Attempt to consume a <see cref="Token"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Token"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Token? Consume(ref Source source) {
			Token? result = null;
			result ??= Combinator.Consume(ref source);
			result ??= Modifier.Consume(ref source);
			result ??= Number.Consume(ref source);
			result ??= Literal.Consume(ref source);
			return result;
		}

		/// <summary>
		/// Converts this token to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public sealed override String ToString() => Text;
	}
}
