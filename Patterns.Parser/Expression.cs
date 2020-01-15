using System;
using System.Collections.Generic;
using System.Linq;
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

		#region Evaluate

		/// <summary>
		/// Evaluate the <see cref="Expression"/>, creating the <see cref="Pattern"/> it represents.
		/// </summary>
		/// <returns>The <see cref="Pattern"/> represented by this <see cref="Expression"/>.</returns>
		public Pattern Evaluate() {
			//The pattern will have to be mutated as the expression is interpreted.
			Pattern pattern = Mutable();
			Int32 t = 0;
			//The first token has to be handled specially.
			EvaluateStartingLiteral(ref t, pattern);
			//Now iterate through the tokens, interpreting them.

			//Once that's done, seal the pattern from further mutations, and return it.
			pattern.Seal();
			return pattern;
		}

		private void EvaluateModifiers(ref Int32 t, Pattern pattern) {
		Next:
			if (t == Tokens.Count) {
				return;
			}
			switch (Tokens[t++]) {
			case KleenesClosure kleene:
				_ = Maybe(Many(pattern));
				goto Next;
			case Many many:
				_ = Many(pattern);
				goto Next;
			case Maybe maybe:
				_ = Maybe(pattern);
				goto Next;
			case Not not:
				_ = Not(pattern);
				goto Next;
			default:
				t--;
				break;
			}
		}

		private void EvaluateStartingLiteral(ref Int32 t, Pattern pattern) {
			Pattern intermediate = Mutable();
			if (t == Tokens.Count) {
				goto Invalid;
			}
			switch (Tokens[t++]) {
			case Literal literal:
				_ = intermediate.Then(literal.ToString());
				break;
			default:
				goto Invalid;
			}
			EvaluateModifiers(ref t, intermediate);
			intermediate.Seal();
			_ = pattern.Then(intermediate);
			return;
		Invalid:
			throw new ExpressionEvaluationException("Expression must begin with a literal");
		}

		#endregion

		#region Parse

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to parse.</param>
		/// <returns>An <see cref="Expression"/> representing as much of the <paramref name="source"/> as possible.</returns>
		public static Expression Parse(ref Source source) {
			Expression expression = new Expression();
			SkipWhitespace(ref source);
			ParseStartingLiteral(ref source, expression);
			ParseModifiers(ref source, expression);
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

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="span"/>.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to parse.</param>
		/// <returns>An <see cref="Expression"/> representing as much of the <paramref name="span"/> as possible.</returns>
		public static Expression Parse(ReadOnlySpan<Char> span) {
			Source source = new Source(span);
			return Parse(ref source);
		}

		private static void ParseModifiers(ref Source source, Expression expression) {
			Token? token = Modifier.Consume(ref source);
			while (token is Object) {
				expression.Tokens.Add(token);
				token = Modifier.Consume(ref source);
			}
		}

		private static void ParseStartingLiteral(ref Source source, Expression expression) {
			Token? token = Literal.Consume(ref source);
			if (token is null) {
				throw new ExpressionParseException("Expression must begin with a literal");
			} else {
				expression.Tokens.Add(token);
			}
		}

		#endregion

		#region TryParse

		/// <summary>
		/// Attempt to parse an <see cref="Expression"/> from the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to parse.</param>
		/// <param name="expression">An <see cref="Expression"/> representing as much of the <paramref name="source"/> as possible.</param>
		/// <returns><see langword="true"/> if parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryParse(ref Source source, out Expression expression) {
			expression = new Expression();
			Boolean success = true;
			SkipWhitespace(ref source);
			if (success = TryParseStartingLiteral(ref source, expression)) {
				ParseModifiers(ref source, expression);
			} else {
				goto Done;
			}
		Done:
			return success;
		}

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to parse.</param>
		/// <param name="expression">An <see cref="Expression"/> representing as much of the <paramref name="string"/> as possible.</param>
		/// <returns><see langword="true"/> if parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean Parse(String @string, out Expression expression) {
			Source source = new Source(@string);
			return TryParse(ref source, out expression);
		}

		/// <summary>
		/// Parse an <see cref="Expression"/> from the <paramref name="span"/>.
		/// </summary>
		/// <param name="span">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to parse.</param>
		/// <param name="expression">An <see cref="Expression"/> representing as much of the <paramref name="span"/> as possible.</param>
		/// <returns><see langword="true"/> if parsing was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean Parse(ReadOnlySpan<Char> span, out Expression expression) {
			Source source = new Source(span);
			return TryParse(ref source, out expression);
		}

		private static Boolean TryParseStartingLiteral(ref Source source, Expression expression) {
			Token? token = Literal.Consume(ref source);
			if (token is null) {
				return false;
			} else {
				expression.Tokens.Add(token);
				return true;
			}
		}

		#endregion

		#region Skip

		private static void SkipWhitespace(ref Source source) => SpaceSeparator.Consume(ref source);

		#endregion

	}
}
