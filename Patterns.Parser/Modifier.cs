using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents any possible modifier
	/// </summary>
	public abstract class Modifier : Token {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = OneOf(KleeneClosure.Pattern, Many.Pattern, Maybe.Pattern, Not.Pattern);

		/// <summary>
		/// Initialize a new <see cref="Modifier"/> with the given <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The literal text of the token; how it was parsed.</param>
		protected Modifier(String text) : base(text) { }

		/// <summary>
		/// Attempt to consume a <see cref="Modifier"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Modifier"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		public static Modifier? Consume(ref Source source) {
			Modifier? result = null;
			result ??= KleeneClosure.Consume(ref source);
			result ??= Many.Consume(ref source);
			result ??= Maybe.Consume(ref source);
			result ??= Not.Consume(ref source);
			return result;
		}
	}
}