using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;
using Console = Consolator.Console;

namespace ptndbg {
	public static partial class Program {
		private static readonly Pattern Kleene = "*";
		private static readonly Pattern Many = "+";
		private static readonly Pattern Maybe = "?";
		private static readonly Pattern Not = "-";
		private static readonly Pattern Number = Many(DecimalDigitNumber);
		private static readonly Pattern Or = "or";
		private static readonly Pattern Repeat = '×'.Or('x');
		private static readonly Pattern Then = "then";
		private static readonly Pattern Token = StringLiteral("\"", "\\\"");

		private enum Combinator { Or, Repeat, Then }

		private enum Modifier { None, Many, Maybe, Not }

		[SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "This is a complex method which makes use of goto's. The 'redundant' gotos actually improve readability, as weird as that sounds, in the context of this method.")]
		public static Pattern GetPattern() {
			//The the pattern expression text
			Source patternText = new Source(Console.ReadLine(" Pattern: ", ConsoleColor.Yellow, ConsoleColor.White));
			//Initialize a mutable pattern, since we'll be building it up as the expression is parsed
			Pattern pattern = Mutable();
			//Initialize another mutable pattern, which will be used as an intermediary for modifying before combining
			Pattern intermediate;
			//These will be used throughout parsing
			Result result;
			Combinator combinator;
			//Skip any leading whitespace
			_ = SpaceSeparator.Consume(ref patternText);
			//Get the very first token
			if (result = Token.Consume(ref patternText)) {
				//TODO: #26 and #27 will make this syntax better, fix this when those are implemented
				_ = pattern.Then(result.AsSpan().Slice(1, result.Length - 2).ToString());
			} else {
				throw new PatternConstructionException("Pattern expression must begin with token");
			}
		ReadInitialModifiers:
			//There may be modifiers, so read those
			if (Kleene.Consume(ref patternText)) {
				_ = Maybe(Many(pattern));
			} else if (Many.Consume(ref patternText)) {
				_ = Many(pattern);
			} else if (Maybe.Consume(ref patternText)) {
				_ = Maybe(pattern);
			} else if (Not.Consume(ref patternText)) {
				_ = Not(pattern);
			} else {
				//We're done with the modifiers, so move along.
				goto ReadCombinator;
			}
			goto ReadInitialModifiers;
		ReadCombinator:
			//Now we can check for a combinator and then another token, until the eventual end
			//Skip any in-between whitespace
			_ = SpaceSeparator.Consume(ref patternText);
			//Check for the combinator
			//Not all combinators are combinators in the most pedantic sense, so handle them appropriately
			if (Or.Consume(ref patternText)) {
				combinator = Combinator.Or;
			} else if (Repeat.Consume(ref patternText)) {
				combinator = Combinator.Repeat;
			} else if (Then.Consume(ref patternText)) {
				combinator = Combinator.Then;
			} else {
				throw new PatternConstructionException("Could not find a combinator between tokens");
			}
		ReadToken:
			//Skip any in-between whitespace
			_ = SpaceSeparator.Consume(ref patternText);
			//Reset the intermediate
			intermediate = Mutable();
			//What the combinator was determines what we try to parse
			if (combinator == Combinator.Repeat) {
				if (!(result = Number.Consume(ref patternText))) {
					throw new PatternConstructionException("Repeaters must provide a count");
				}
				//Repeat counts can't have modifiers, so skip that part
				goto ReadExpressionTail;
			} else {
				if (result = Token.Consume(ref patternText)) {
					//TODO: #26 and #27 will make this syntax better, fix this when those are implemented
					_ = intermediate.Then(result.AsSpan().Slice(1, result.Length - 2).ToString());
				} else { 
					throw new PatternConstructionException("Combinators must provide a token");
				}
			}
		ReadModifiers:
			//There may be modifiers, so read those
			if (Kleene.Consume(ref patternText)) {
				_ = Maybe(Many(pattern));
			} else if (Many.Consume(ref patternText)) {
				_ = Many(pattern);
			} else if (Maybe.Consume(ref patternText)) {
				_ = Maybe(pattern);
			} else if (Not.Consume(ref patternText)) {
				_ = Not(pattern);
			} else {
				//We're done with the modifiers, so move along.
				goto ReadExpressionTail;
			}
			goto ReadModifiers;
		ReadExpressionTail:
			//Seal the intermediate
			intermediate.Seal();
			//Combine the intermediate the with pattern
			switch (combinator) {
			case Combinator.Or:
				_ = pattern.Or(intermediate);
				break;
			case Combinator.Then:
				_ = pattern.Then(intermediate);
				break;
			case Combinator.Repeat:
				//Repeaters expect a number, not a token
				_ = pattern.Repeat(Int32.Parse(result));
				break;
			default:
				throw new PatternConstructionException($"The combinator '{combinator}' wasn't handled");
			}
			//Skip any in-between whitespace
			_ = SpaceSeparator.Consume(ref patternText);
			//If we're at the end of the patternText, we're done, otherwise keep parsing the expression
			if (EndOfSource.Consume(ref patternText)) {
				goto Done;
			} else {
				goto ReadCombinator;
			}
		Done:
			//Seal the pattern so it's no longer mutable
			pattern.Seal();
			//And return the parsed pattern
			return pattern;
		}
	}
}
