using System;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns.Bindings {
	/// <summary>
	/// Holds useful definitions for creating bindings to <see cref="Pattern"/>.
	/// </summary>
	/// <remarks>
	/// The entire point of this is to make it easy to declare bindings to this library from another language which does not map directly, such as F#.
	/// </remarks>
	public static class PatternBindings {
		/// <summary>
		/// Create a <see cref="Pattern"/> from the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> literal.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="char"/>.</returns>
		public static Pattern Literal(Char @char) => new Pattern(new CharLiteral(@char));

		/// <summary>
		/// Create a <see cref="Pattern"/> from the given <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> literal.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="string"/>.</returns>
		public static Pattern Literal(String @string) {
			if (@string is null) {
				throw new ArgumentNullException(nameof(@string));
			}
			return new Pattern(new StringLiteral(@string));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Pattern left, Pattern right) => new Pattern(left.Head.Alternate(right.Head));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="String"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Pattern left, String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(left.Head.Alternate(new StringLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="String"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(String left, Pattern right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new StringLiteral(left).Alternate(right.Head));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Char"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns
		public static Pattern Alternator(Pattern left, Char right) => new Pattern(left.Head.Alternate(new CharLiteral(right)));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Char"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Char left, Pattern right) => new Pattern(new CharLiteral(left).Alternate(right.Head));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="String"/> to check first</param>
		/// <param name="right">The <see cref="String"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns
		public static Pattern Alternator(String left, String right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			} else if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new StringLiteral(left).Alternate(new StringLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="String"/> to check first</param>
		/// <param name="right">The <see cref="Char"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns
		public static Pattern Alternator(String left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new StringLiteral(left).Alternate(new CharLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Char"/> to check first</param>
		/// <param name="right">The <see cref="String"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Char left, String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new CharLiteral(left).Alternate(new StringLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Char"/> to check first</param>
		/// <param name="right">The <see cref="Char"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Char left, Char right) => new Pattern(new CharLiteral(left).Alternate(new CharLiteral(right)));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Capture"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Pattern left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(left.Head.Alternate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Capture"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Capture left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new CaptureLiteral(left).Alternate(right.Head));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="String"/> to check first</param>
		/// <param name="right">The <see cref="Capture"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(String left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new StringLiteral(left).Alternate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Capture"/> to check first</param>
		/// <param name="right">The <see cref="String"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Capture left, String right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new CaptureLiteral(left).Alternate(new StringLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Char"/> to check first</param>
		/// <param name="right">The <see cref="Capture"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Char left, Capture right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new CharLiteral(left).Alternate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Capture"/> to check first</param>
		/// <param name="right">The <see cref="Char"/> to check if <paramref name="right"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Capture left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new CaptureLiteral(left).Alternate(new CharLiteral(right)));
		}

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to capture.</param>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <paramref name="pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		public static Pattern Capturer(Pattern pattern, out Capture capture) => pattern.Capture(out capture);

		//public static Pattern Checker(String Name, Func<Char, Boolean> Check) => new Pattern(new CharChecker(Name, Check));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Pattern left, Pattern right) => new Pattern(left.Head.Concatenate(right.Head));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Pattern left, String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(left.Head.Concatenate(new StringLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="String"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(String left, Pattern right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new StringLiteral(left).Concatenate(right.Head));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Pattern left, Char right) => new Pattern(left.Head.Concatenate(new CharLiteral(right)));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Char"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Char left, Pattern right) => new Pattern(new CharLiteral(left).Concatenate(right.Head));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="String"/></param>
		/// <param name="right">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(String left, String right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			} else if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new StringLiteral(left).Concatenate(new StringLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="String"/></param>
		/// <param name="right">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(String left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new StringLiteral(left).Concatenate(new CharLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Char"/></param>
		/// <param name="right">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Char left, String right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new CharLiteral(left).Concatenate(new StringLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Char"/></param>
		/// <param name="right">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Char left, Char right) => new Pattern(new CharLiteral(left).Concatenate(new CharLiteral(right)));

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Capture"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Pattern left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(left.Head.Concatenate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Capture"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Capture left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new CaptureLiteral(left).Concatenate(right.Head));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="String"/></param>
		/// <param name="right">The succeeding <see cref="Capture"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(String left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new StringLiteral(left).Concatenate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Capture"/></param>
		/// <param name="right">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Capture left, String right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(new CaptureLiteral(left).Concatenate(new StringLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Char"/></param>
		/// <param name="right">The succeeding <see cref="Capture"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Char left, Capture right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return new Pattern(new CharLiteral(left).Concatenate(new CaptureLiteral(right)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Capture"/></param>
		/// <param name="right">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Capture left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return new Pattern(new CaptureLiteral(left).Concatenate(new CharLiteral(right)));
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Negator(Pattern pattern) => new Pattern(pattern.Head.Negate());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Negator(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Negate());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns
		public static Pattern Negator(Char pattern) => new Pattern(new CharLiteral(pattern).Negate());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Capture"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns
		public static Pattern Negator(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Negate());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Optor(Pattern pattern) => new Pattern(pattern.Head.Optional());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Optor(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Optional());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns
		public static Pattern Optor(Char pattern) => new Pattern(new CharLiteral(pattern).Optional());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Capture"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns
		public static Pattern Optor(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Optional());
		}

		//public static Pattern Ranger(Pattern From, Pattern To) => new Pattern(new Ranger(From.Head, To.Head));

		//public static Pattern Ranger(Pattern From, String To) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new Ranger(From.Head, new StringLiteral(To)));
		//}

		//public static Pattern Ranger(String From, Pattern To) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new Ranger(new StringLiteral(From), To.Head));
		//}

		//public static Pattern Ranger(Pattern From, Char To) => new Pattern(new Ranger(From.Head, new CharLiteral(To)));

		//public static Pattern Ranger(Char From, Pattern To) => new Pattern(new Ranger(new CharLiteral(From), To.Head));

		//public static Pattern Ranger(String From, String To) {
		//	if (From is null || To is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(To));
		//	}
		//	return new Pattern(new Ranger(new StringLiteral(From), new StringLiteral(To)));
		//}

		//public static Pattern Ranger(String From, Char To) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new Ranger(new StringLiteral(From), new CharLiteral(To)));
		//}

		//public static Pattern Ranger(Char From, String To) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new Ranger(new CharLiteral(From), new StringLiteral(To)));
		//}

		//public static Pattern Ranger(Char From, Char To) => new Pattern(new Ranger(new CharLiteral(From), new CharLiteral(To)));

		//public static Pattern Ranger(Pattern From, Pattern To, Pattern Escape) => new Pattern(new EscapedRanger(From.Head, To.Head, Escape.Head));

		//public static Pattern Ranger(Pattern From, Pattern To, String Escape) {
		//	if (Escape is null) {
		//		throw new ArgumentNullException(nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(From.Head, To.Head, new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Pattern From, Pattern To, Char Escape) => new Pattern(new EscapedRanger(From.Head, To.Head, new CharLiteral(Escape)));

		//public static Pattern Ranger(Pattern From, String To, Pattern Escape) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(From.Head, new StringLiteral(To), Escape.Head));
		//}

		//public static Pattern Ranger(Pattern From, String To, String Escape) {
		//	if (To is null || Escape is null) {
		//		throw new ArgumentNullException(To is null ? nameof(To) : nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(From.Head, new StringLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Pattern From, String To, Char Escape) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(From.Head, new StringLiteral(To), new CharLiteral(Escape)));
		//}

		//public static Pattern Ranger(String From, Pattern To, Pattern Escape) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), To.Head, Escape.Head));
		//}

		//public static Pattern Ranger(String From, Pattern To, String Escape) {
		//	if (From is null || Escape is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), To.Head, new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(String From, Pattern To, Char Escape) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), To.Head, new CharLiteral(Escape)));
		//}

		//public static Pattern Ranger(Pattern From, Char To, Pattern Escape) => new Pattern(new EscapedRanger(From.Head, new CharLiteral(To), Escape.Head));

		//public static Pattern Ranger(Pattern From, Char To, String Escape) {
		//	if (Escape is null) {
		//		throw new ArgumentNullException(nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(From.Head, new CharLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Pattern From, Char To, Char Escape) => new Pattern(new EscapedRanger(From.Head, new CharLiteral(To), new CharLiteral(Escape)));

		//public static Pattern Ranger(Char From, Pattern To, Pattern Escape) => new Pattern(new EscapedRanger(new CharLiteral(From), To.Head, Escape.Head));

		//public static Pattern Ranger(Char From, Pattern To, String Escape) {
		//	if (Escape is null) {
		//		throw new ArgumentNullException(nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(new CharLiteral(From), To.Head, new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Char From, Pattern To, Char Escape) => new Pattern(new EscapedRanger(new CharLiteral(From), To.Head, new CharLiteral(Escape)));

		//public static Pattern Ranger(String From, String To, Pattern Escape) {
		//	if (From is null || To is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new StringLiteral(To), Escape.Head));
		//}

		//public static Pattern Ranger(String From, String To, String Escape) {
		//	if (From is null || To is null || Escape is null) {
		//		if (From is null) {
		//			throw new ArgumentNullException(nameof(From));
		//		} else {
		//			throw new ArgumentNullException(To is null ? nameof(To) : nameof(Escape));
		//		}
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new StringLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(String From, String To, Char Escape) {
		//	if (From is null || To is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new StringLiteral(To), new CharLiteral(Escape)));
		//}

		//public static Pattern Ranger(String From, Char To, Pattern Escape) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new CharLiteral(To), Escape.Head));
		//}

		//public static Pattern Ranger(String From, Char To, String Escape) {
		//	if (From is null || Escape is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new CharLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(String From, Char To, Char Escape) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new EscapedRanger(new StringLiteral(From), new CharLiteral(To), new CharLiteral(Escape)));
		//}

		//public static Pattern Ranger(Char From, String To, Pattern Escape) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(new CharLiteral(From), new StringLiteral(To), Escape.Head));
		//}

		//public static Pattern Ranger(Char From, String To, String Escape) {
		//	if (To is null || Escape is null) {
		//		throw new ArgumentNullException(To is null ? nameof(To) : nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(new CharLiteral(From), new StringLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Char From, String To, Char Escape) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new EscapedRanger(new CharLiteral(From), new StringLiteral(To), new CharLiteral(Escape)));
		//}

		//public static Pattern Ranger(Char From, Char To, Pattern Escape) => new Pattern(new EscapedRanger(new CharLiteral(From), new CharLiteral(To), Escape.Head));

		//public static Pattern Ranger(Char From, Char To, String Escape) {
		//	if (Escape is null) {
		//		throw new ArgumentNullException(nameof(Escape));
		//	}
		//	return new Pattern(new EscapedRanger(new CharLiteral(From), new CharLiteral(To), new StringLiteral(Escape)));
		//}

		//public static Pattern Ranger(Char From, Char To, Char Escape) => new Pattern(new EscapedRanger(new CharLiteral(From), new CharLiteral(To), new CharLiteral(Escape)));

		//public static Pattern NestedRanger(Pattern From, Pattern To) => new Pattern(new NestedRanger(From.Head, To.Head));

		//public static Pattern NestedRanger(Pattern From, String To) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new NestedRanger(From.Head, new StringLiteral(To)));
		//}

		//public static Pattern NestedRanger(String From, Pattern To) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new NestedRanger(new StringLiteral(From), To.Head));
		//}

		//public static Pattern NestedRanger(Pattern From, Char To) => new Pattern(new NestedRanger(From.Head, new CharLiteral(To)));

		//public static Pattern NestedRanger(Char From, Pattern To) => new Pattern(new NestedRanger(new CharLiteral(From), To.Head));

		//public static Pattern NestedRanger(String From, String To) {
		//	if (From is null || To is null) {
		//		throw new ArgumentNullException(From is null ? nameof(From) : nameof(To));
		//	}
		//	return new Pattern(new NestedRanger(new StringLiteral(From), new StringLiteral(To)));
		//}

		//public static Pattern NestedRanger(String From, Char To) {
		//	if (From is null) {
		//		throw new ArgumentNullException(nameof(From));
		//	}
		//	return new Pattern(new NestedRanger(new StringLiteral(From), new CharLiteral(To)));
		//}

		//public static Pattern NestedRanger(Char From, String To) {
		//	if (To is null) {
		//		throw new ArgumentNullException(nameof(To));
		//	}
		//	return new Pattern(new NestedRanger(new CharLiteral(From), new StringLiteral(To)));
		//}

		//public static Pattern NestedRanger(Char From, Char To) => new Pattern(new NestedRanger(new CharLiteral(From), new CharLiteral(To)));

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeater(Pattern pattern, Int32 count) => new Pattern(pattern.Head.Repeat(count));

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeater(String pattern, Int32 count) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Repeat(count));
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeater(Char pattern, Int32 count) => new Pattern(new CharLiteral(pattern).Repeat(count));

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Capture"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeater(Capture pattern, Int32 count) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Repeat(count));
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Spanner(Pattern pattern) => new Pattern(pattern.Head.Span());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Spanner(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Span());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns
		public static Pattern Spanner(Char pattern) => new Pattern(new CharLiteral(pattern).Span());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Capture"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Spanner(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Span());
		}
	}
}
