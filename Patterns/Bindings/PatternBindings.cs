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
		/// Create a <see cref="Pattern"/> from the given <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Capture"/> literal.</param>
		/// <returns>A <see cref="Pattern"/> representing literally the <paramref name="capture"/>.</returns>
		public static Pattern Literal(Capture capture) {
			if (capture is null) {
				throw new ArgumentNullException(nameof(capture));
			}
			return new Pattern(new CaptureLiteral(capture));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of <paramref name="left"/>
		/// </summary>
		/// <param name="left">The <see cref="Pattern"/> to check first</param>
		/// <param name="right">The <see cref="Pattern"/> to check if <paramref name="left"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Alternator(Pattern left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(left.Head.Alternate(right.Head));
		}

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to capture.</param>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <paramref name="pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		public static Pattern Capturer(Pattern pattern, out Capture capture) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return pattern.Capture(out capture);
		}

		/// <summary>
		/// Concatenates the patterns so that <paramref name="left"/> comes before <paramref name="right"/>
		/// </summary>
		/// <param name="left">The preceeding <see cref="Pattern"/></param>
		/// <param name="right">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating <paramref name="left"/> and <paramref name="right"/></returns>
		public static Pattern Concatenator(Pattern left, Pattern right) {
			if (left is null || right is null) {
				throw new ArgumentNullException(left is null ? nameof(left) : nameof(right));
			}
			return new Pattern(left.Head.Concatenate(right.Head));
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Negator(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(pattern.Head.Negate());
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Optor(Pattern pattern) {
			if (pattern is null) {
				throw new ArgumentNullException(nameof(pattern));
			}
			return new Pattern(pattern.Head.Optional());
		}

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		public static Pattern Ranger(Pattern from, Pattern to) => new Pattern(new Ranger(from.Head, to.Head));

		public static Pattern Ranger(Pattern From, Pattern To, Pattern Escape) => new Pattern(new EscapedRanger(From.Head, To.Head, Escape.Head));

		public static Pattern NestedRanger(Pattern From, Pattern To) => new Pattern(new NestedRanger(From.Head, To.Head));

		/// <summary>
		/// Marks the <paramref name="pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to repeat.</param>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public static Pattern Repeater(Pattern pattern, Int32 count) => new Pattern(pattern.Head.Repeat(count));

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Spanner(Pattern pattern) => new Pattern(pattern.Head.Span());
	}
}
