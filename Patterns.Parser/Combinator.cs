using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents any combinator
	/// </summary>
	internal abstract class Combinator : Token {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new internal static readonly Pattern Pattern = OneOf(Or.Pattern, Then.Pattern, Repeat.Pattern);

		/// <summary>
		/// Initialize a new <see cref="Combinator"/> with the given <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The literal text of the token; how it was parsed.</param>
		protected Combinator(String text) : base(text) { }

		/// <summary>
		/// Attempt to consume a <see cref="Combinator"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Combinator"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Combinator? Consume(ref Source source) {
			Combinator? result = null;
			result ??= Or.Consume(ref source);
			result ??= Then.Consume(ref source);
			result ??= Repeat.Consume(ref source);
			return result;
		}
	}
}
