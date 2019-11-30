using System;
using Stringier.Patterns.Nodes;

namespace Stringier.Patterns {
	public partial class Pattern {
		#region Literals

		public static implicit operator Pattern(Char @char) => new Pattern(new CharLiteral(@char));

		public static implicit operator Pattern(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern));
		}

		#endregion

		#region Alternator

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Pattern other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null || other.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Alternate(other.Head));
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(String other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Alternate(other));
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Char other) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Alternate(other));
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Capture"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Capture other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Alternate(new CaptureLiteral(other)));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Pattern left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Char"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Pattern left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Char"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Char left, Pattern right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="String"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Pattern left, String right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="String"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(String left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Patterns.Capture"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Pattern left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Or(right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Patterns.Capture"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator |(Capture left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Or(right);
		}


		#endregion

		#region Capturer

		public static implicit operator Pattern(Capture capture) {
			if (capture is null) {
				throw new ArgumentNullException(nameof(capture));
			}
			return new Pattern(new CaptureLiteral(capture));
		}

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <paramref name="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		public virtual Pattern Capture(out Capture capture) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Capture(out capture));
		}

		#endregion

		#region Checker

		/// <summary>
		/// Use the <paramref name="check"/> to represent a single character.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> to validate the character.</param>
		/// <returns></returns>
		public static Pattern Check(String name, Func<Char, Boolean> check) {
			if (name is null || check is null) {
				throw new ArgumentNullException(name is null ? nameof(name) : nameof(check));
			}
			return new Pattern(new CharChecker(name, check));
		}

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent a variable length string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(String name, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) {
			if (name is null) {
				throw new ArgumentNullException(nameof(name));
			} else if (headCheck is null) {
				throw new ArgumentNullException(nameof(headCheck));
			} else if (bodyCheck is null) {
				throw new ArgumentNullException(nameof(bodyCheck));
			} else if (tailCheck is null) {
				throw new ArgumentNullException(nameof(tailCheck));
			} else {
				return new Pattern(new StringChecker(name, headCheck, bodyCheck, tailCheck));
			}
		}

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent a variable length string, along with whether each check is required for a valid string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="headRequired">Whether the <paramref name="headCheck"/> is required.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="bodyRequired">Whether the <paramref name="bodyCheck"/> is required.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <param name="tailRequired">Whether the <paramref name="tailRequired"/> is required.</param>
		/// <returns></returns>
		public static Pattern Check(String name, Func<Char, Boolean> headCheck, Boolean headRequired, Func<Char, Boolean> bodyCheck, Boolean bodyRequired, Func<Char, Boolean> tailCheck, Boolean tailRequired) {
			if (name is null) {
				throw new ArgumentNullException(nameof(name));
			} else if (headCheck is null) {
				throw new ArgumentNullException(nameof(headCheck));
			} else if (bodyCheck is null) {
				throw new ArgumentNullException(nameof(bodyCheck));
			} else if (tailCheck is null) {
				throw new ArgumentNullException(nameof(tailCheck));
			} else {
				return new Pattern(new StringChecker(name, headCheck, headRequired, bodyCheck, bodyRequired, tailCheck, tailRequired));
			}
		}

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent the valid form of a word, along with the <paramref name="bias"/>.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="bias">Endian bias of the word. Head bias requires the head if only one letter is present. Tail bias requires the tail if only one letter is present.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(String name, Bias bias, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) {
			if (name is null) {
				throw new ArgumentNullException(nameof(name));
			} else if (headCheck is null) {
				throw new ArgumentNullException(nameof(headCheck));
			} else if (bodyCheck is null) {
				throw new ArgumentNullException(nameof(bodyCheck));
			} else if (tailCheck is null) {
				throw new ArgumentNullException(nameof(tailCheck));
			} else {
				return new Pattern(new WordChecker(name, bias, headCheck, bodyCheck, tailCheck));
			}
		}

		#endregion

		#region Concatenator

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Pattern other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null || other.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Concatenate(other.Head));
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(String other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Concatenate(other));
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Char other) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Concatenate(other));
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Capture other) {
			if (other is null) {
				throw new ArgumentNullException(nameof(other));
			} else if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Concatenate(new CaptureLiteral(other)));
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Pattern left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Pattern left, Char right) {
			if (left is null) {
				throw new ArgumentNullException(nameof(left));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Char"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Char left, Pattern right) {
			if (right is null) {
				throw new ArgumentNullException(nameof(right));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Pattern left, String right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="String"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(String left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Capture"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Pattern left, Capture right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Then(right);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Capture"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern operator &(Capture left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return left.Then(right);
		}

		#endregion

		#region Negator

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is negated.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal virtual Pattern Negate() {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Negate());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return pattern.Negate();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Negate());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Char pattern) => new Pattern(new CharLiteral(pattern).Negate());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern));
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern operator !(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return Not(pattern);
		}

		#endregion

		#region Optor

		/// <summary>
		/// Marks this <see cref="Pattern"/> as optional.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks>
		internal virtual Pattern Optional() {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Optional());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return pattern.Optional();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Optional());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Char pattern) => new Pattern(new CharLiteral(pattern).Optional());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Optional());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern operator -(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return Maybe(pattern);
		}

		#endregion

		#region Ranger

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		public static Pattern Range(Pattern from, Pattern to) {
			if (from is null || to is null) {
				throw new ArgumentNullException(from is null ? nameof(from) : nameof(to));
			} else if (from.Head is null || to.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(new Ranger(from.Head, to.Head));
		}

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		/// <param name="escape">Escape <see cref="Pattern"/>./</param>
		public static Pattern Range(Pattern from, Pattern to, Pattern escape) {
			if (from is null) {
				throw new ArgumentNullException(nameof(from));
			} else if (to is null) {
				throw new ArgumentNullException(nameof(to));
			} else if (escape is null) {
				throw new ArgumentNullException(nameof(escape));
			} else if (from.Head is null || to.Head is null || escape.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(new EscapedRanger(from.Head, to.Head, escape.Head));
		}

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>, that allows nesting of this pattern inside of itself.
		/// </summary>
		/// <remarks>
		/// The easiest way to explain this is that is shows up a lot in programming, with things like if-then-else statements which can contain other if-then-else statements.
		/// </remarks>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		public static Pattern NestedRange(Pattern from, Pattern to) {
			if (from is null || to is null) {
				throw new ArgumentNullException(from is null ? nameof(from) : nameof(to));
			} else if (from.Head is null || to.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(new NestedRanger(from.Head, to.Head));
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public virtual Pattern Repeat(Int32 count) {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Repeat(count));
		}

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as repeating <paramref name="count"/> times
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern operator *(Pattern pattern, Int32 count) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return pattern.Repeat(count);
		}

		#endregion

		#region Spanner

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks
		internal virtual Pattern Span() {
			if (Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(Head.Span());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return new Pattern(pattern.Head.Span());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(String pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new StringLiteral(pattern).Span());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Char pattern) => new Pattern(new CharLiteral(pattern).Span());

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Capture"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Capture pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(new CaptureLiteral(pattern).Span());
		}

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which spans.</returns>
		public static Pattern operator +(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			} else if (pattern.Head is null) {
				throw new PatternUndefinedException();
			}
			return Many(pattern);
		}

		#endregion
	}
}
