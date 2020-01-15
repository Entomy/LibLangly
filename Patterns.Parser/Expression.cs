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
			while (EvaluateCombinator(ref t)) {
				EvaluateLiteral(ref t, pattern);
			}
			//Once that's done, seal the pattern from further mutations, and return it.
			pattern.Seal();
			return pattern;
		}

		private Boolean EvaluateCombinator(ref Int32 t) {
			if (t == Tokens.Count) {
				return false;
			}
			switch (Tokens[t++]) {
			case Combinator combinator:
				return true;
			default:
				throw new ExpressionEvaluationException("Expected a combinator");
			}
		}

		private void EvaluateLiteral(ref Int32 t, Pattern pattern) {
			if (t == Tokens.Count) {
				goto Invalid;
			}
			switch (Tokens[t++]) {
			case Literal literal:
				Pattern intermediate = Mutable();
				switch (Tokens[t - 2]) {
				case Then then:
					_ = intermediate.Then(literal.Text);
					break;
				case Or or:
					_ = intermediate.Or(literal.Text);
					break;
				default:
					throw new ExpressionEvaluationException("Found a literal after a non combinator");
				}
				EvaluateModifiers(ref t, intermediate);
				intermediate.Seal();
				_ = pattern.Then(intermediate);
				return;
			case Number number:
				switch (Tokens[t - 2]) {
				case Repeat repeat:
					_ = pattern.Repeat(number.Value);
					return;
				default:
					throw new ExpressionEvaluationException("Found a number after a non repeater");
				}
			default:
				goto Invalid;
			}
		Invalid:
			throw new ExpressionEvaluationException("Expected a literal");
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
				_ = intermediate.Then(literal.Text);
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
			ParseStartingLiteral(ref source, expression);
			ParseModifiers(ref source, expression);
			if (TryParseCombinator(ref source, expression)) {
				ParseModifiers(ref source, expression);
			} else {
				goto Done;
			}
			ParseLiteral(ref source, expression);
			ParseModifiers(ref source, expression);
		Done:
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

		private static void ParseLiteral(ref Source source, Expression expression) {
			if (!TryParseLiteral(ref source, expression)) {
				throw new ExpressionParseException("Expected a literal");
			}
		}

		private static void ParseModifiers(ref Source source, Expression expression) {
			Token? token = Modifier.Consume(ref source);
			while (token is Object) {
				expression.Tokens.Add(token);
				token = Modifier.Consume(ref source);
			}
		}

		private static void ParseStartingLiteral(ref Source source, Expression expression) {
			if (!TryParseStartingLiteral(ref source, expression)) {
				throw new ExpressionParseException("Expression must begin with a literal");
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
			if (success = TryParseStartingLiteral(ref source, expression)) {
				ParseModifiers(ref source, expression);
			} else {
				goto Done;
			}
			if (TryParseCombinator(ref source, expression)) {
				ParseModifiers(ref source, expression);
			} else {
				return false;
			}
			if (success = TryParseLiteral(ref source, expression)) {
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

		private static Boolean TryParseCombinator(ref Source source, Expression expression) {
			SkipWhitespace(ref source);
			Token? token = Combinator.Consume(ref source);
			if (token is null) {
				return false;
			} else {
				expression.Tokens.Add(token);
				return true;
			}
		}

		private static Boolean TryParseLiteral(ref Source source, Expression expression) {
			SkipWhitespace(ref source);
			Token? token = Literal.Consume(ref source);
			token ??= Number.Consume(ref source);
			if (token is null) {
				return false;
			} else {
				expression.Tokens.Add(token);
				return true;
			}
		}

		private static Boolean TryParseStartingLiteral(ref Source source, Expression expression) {
			SkipWhitespace(ref source);
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
