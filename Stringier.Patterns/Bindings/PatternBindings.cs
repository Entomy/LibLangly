namespace System.Text.Patterns.Bindings {
	/// <summary>
	/// Holds useful definitions for creating bindings to <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// The entire point of this is to make it easy to declare bindings to this library from another language which does not map directly, such as F#.
	/// </remarks>
	public static class PatternBindings {
		public static Pattern Literal(String String) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return new StringLiteral(String);
		}

		public static Pattern Literal(String String, StringComparison ComparisonType) {
			if (String is null) {
				throw new ArgumentNullException(nameof(String));
			}
			return new StringLiteral(String, ComparisonType);
		}

		public static Pattern Literal(Char Char) => new CharLiteral(Char);

		public static Pattern Literal(Char Char, StringComparison ComparisonType) => new CharLiteral(Char, ComparisonType);

		public static Pattern Alternator(Pattern Left, Pattern Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(Pattern Left, String Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(String Left, Pattern Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(Pattern Left, Char Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(Char Left, Pattern Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(String Left, String Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(String Left, Char Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(Char Left, String Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Alternate(Right);
		}

		public static Pattern Alternator(Char Left, Char Right) => Left.Alternate(Right);

		public static Pattern Capturer(Pattern Pattern, out Capture Capture) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return Pattern.Capture(out Capture);
		}

		public static Pattern Checker(String Name, Func<Char, Boolean> Check) {
			if (Name is null) {
				throw new ArgumentNullException(nameof(Name));
			}
			return new CharChecker(Name, Check);
		}

		public static Pattern Concatenator(Pattern Left, Pattern Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(Pattern Left, String Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(String Left, Pattern Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(Pattern Left, Char Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(Char Left, Pattern Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(String Left, String Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			} else if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(String Left, Char Right) {
			if (Left is null) {
				throw new ArgumentNullException(nameof(Left));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(Char Left, String Right) {
			if (Right is null) {
				throw new ArgumentNullException(nameof(Right));
			}
			return Left.Concatenate(Right);
		}

		public static Pattern Concatenator(Char Left, Char Right) => Left.Concatenate(Right);

		public static Pattern Negator(Pattern Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return Pattern.Negate();
		}

		public static Pattern Negator(String Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return new StringLiteral(Pattern).Negate();
		}

		public static Pattern Negator(Char Pattern) => new CharLiteral(Pattern).Negate();

		public static Pattern Optor(Pattern Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return Pattern.Optional();
		}

		public static Pattern Optor(String Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return new StringLiteral(Pattern).Optional();
		}

		public static Pattern Optor(Char Pattern) => new CharLiteral(Pattern).Optional();

		public static Pattern Ranger(Pattern From, Pattern To) => new Ranger(From, To);

		public static Pattern Ranger(Pattern From, String To) => new Ranger(From, new StringLiteral(To));

		public static Pattern Ranger(String From, Pattern To) => new Ranger(new StringLiteral(From), To);

		public static Pattern Ranger(Pattern From, Char To) => new Ranger(From, new CharLiteral(To));

		public static Pattern Ranger(Char From, Pattern To) => new Ranger(new CharLiteral(From), To);

		public static Pattern Ranger(String From, String To) => new Ranger(new StringLiteral(From), new StringLiteral(To));

		public static Pattern Ranger(String From, Char To) => new Ranger(new StringLiteral(From), new CharLiteral(To));

		public static Pattern Ranger(Char From, String To) => new Ranger(new CharLiteral(From), new StringLiteral(To));

		public static Pattern Ranger(Char From, Char To) => new Ranger(new CharLiteral(From), new CharLiteral(To));

		public static Pattern Ranger(Pattern From, Pattern To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Pattern To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Pattern To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, String To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, String To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, String To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Pattern To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Pattern To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Pattern To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Char To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Char To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Char To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Pattern To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Pattern To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Pattern To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, String To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, String To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, String To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Char To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Char To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(String From, Char To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, String To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, String To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, String To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Char To, Pattern Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Char To, String Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Char From, Char To, Char Escape) => new EscapedRanger(From, To, Escape);

		public static Pattern Ranger(Pattern From, Pattern To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(Pattern From, String To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(String From, Pattern To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(Pattern From, Char To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(Char From, Pattern To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(String From, String To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(String From, Char To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(Char From, String To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Ranger(Char From, Char To, Boolean Nested) => Nested ? new NestedRanger(From, To) : new Ranger(From, To);

		public static Pattern Repeater(Pattern Pattern, Int32 Count) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return Pattern.Repeat(Count);
		}

		public static Pattern Repeater(String Pattern, Int32 Count) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return new StringLiteral(Pattern).Repeat(Count);
		}

		public static Pattern Repeater(Char Pattern, Int32 Count) => new CharLiteral(Pattern).Repeat(Count);

		public static Pattern Spanner(Pattern Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return Pattern.Span();
		}

		public static Pattern Spanner(String Pattern) {
			if (Pattern is null) {
				throw new ArgumentNullException(nameof(Pattern));
			}
			return new StringLiteral(Pattern).Span();
		}

		public static Pattern Spanner(Char Pattern) => new CharLiteral(Pattern).Span();
	}
}
