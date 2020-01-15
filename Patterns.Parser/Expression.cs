using System;
using System.Collections.Generic;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Stringier.Patterns.Parser {
	/// <summary>
	/// Represents a <see cref="Pattern"/> expression.
	/// </summary>
	public sealed class Expression {
		/// <summary>
		/// The <see cref="Token"/>s that make up this <see cref="Expression"/>.
		/// </summary>
		private readonly List<Token> Tokens = new List<Token>();

		/// <summary>
		/// Initialize a new <see cref="Expression"/> instance.
		/// </summary>
		private Expression() { }

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to parse.</param>
		/// <returns>An <see cref="Expression"/> representing as much of the <paramref name="source"/> as possible.</returns>
		public static Expression Parse(ref Source source) {
			Expression expression = new Expression();
			SkipWhitespace(ref source);
			ParseStartingLiteral(ref source, expression);
			return expression;
		}

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to parse.</param>
		/// <returns>An <see cref="Expression"/> representing as much of the <paramref name="string"/> as possible.</returns>
		public static Expression Parse(String @string) {
			Source source = new Source(@string);
			return Parse(ref source);
		}

		private static void ParseStartingLiteral(ref Source source, Expression expression) {
			Token? token = Literal.Consume(ref source);
			if (token is null) {
				throw new ExpressionParseException("Expression must begin with a literal");
			} else {
				expression.Tokens.Add(token);
			}
		}

		private static void SkipWhitespace(ref Source source) => SpaceSeparator.Consume(ref source);
	}
}
