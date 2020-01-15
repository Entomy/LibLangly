using System;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a pattern literal; an exact match to make.
	/// </summary>
	internal sealed class Literal : Token {
		/// <summary>
		/// The <see cref="Patterns.Pattern"/> which represents this type.
		/// </summary>
		new public static readonly Pattern Pattern = StringLiteral("\"", "\\\"");

		/// <summary>
		/// Initialize a new <see cref="Literal"/> with the given <paramref name="text"/>.
		/// </summary>
		/// <param name="text">The literal text of the token; how it was parsed.</param>
		private Literal(String text) : base(text) { }

		/// <summary>
		/// Attempt to consume a <see cref="Literal"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <returns>A new <see cref="Literal"/> instance if parsing succeeded; otherwise <see langword="null"/>.</returns>
		new internal static Literal? Consume(ref Source source) {
			Result result = Pattern.Consume(ref source);
			return result ? new Literal(result.AsSpan().Slice(1, result.Length - 2).ToString()) : null;
		}
	}
}
