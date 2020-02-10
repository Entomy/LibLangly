using System;
using Stringier.Patterns.Nodes;
using Defender;

namespace Stringier.Patterns {
	public abstract partial class Pattern {
		#region Literals

		public static implicit operator Pattern(Char @char) => new CharLiteral(@char);

		public static implicit operator Pattern(String @string) {
			Guard.NotNull(@string, nameof(@string));
			return new StringLiteral(@string);
		}

		public static implicit operator Pattern(ReadOnlySpan<Char> span) => new StringLiteral(span);

		#endregion

		#region Alternator

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal virtual Pattern Alternate(Pattern right) {
			Guard.NotNull(right, nameof(right));
			return new Alternator(this, right);
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal virtual Pattern Alternate(Char right) => new Alternator(this, new CharLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal virtual Pattern Alternate(String right) {
			Guard.NotNull(right, nameof(right));
			return new Alternator(this, new StringLiteral(right));
		}

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check if this <see cref="Pattern"/> does not match.</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal virtual Pattern Alternate(ReadOnlySpan<Char> right) => new Alternator(this, new StringLiteral(right));

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Pattern"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Pattern other) {
			Guard.NotNull(other, nameof(other));
			return Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(String other) {
			Guard.NotNull(other, nameof(other));
			return Alternate(other);
		}

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(ReadOnlySpan<Char> other) => Alternate(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Char"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Char other) => Alternate(other);

		/// <summary>
		/// Declares <paramref name="other"/> to be an alternate of this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="Patterns.Capture"/> to check if this <see cref="Pattern"/> does not match</param>
		/// <returns>A new <see cref="Pattern"/> alternating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Or(Capture other) {
			Guard.NotNull(other, nameof(other));
			return Alternate(new CaptureLiteral(other));
		}

		/// <summary>
		/// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <param name="patterns">The set of <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		public static Pattern OneOf(params Pattern[] patterns) {
			Guard.NotNull(patterns, nameof(patterns));
			if (patterns.Length < 2) {
				throw new ArgumentException("Must have at least two patterns", nameof(patterns));
			} else {
				Pattern result = patterns[0];
				for (Int32 i = 1; i < patterns.Length; i++) {
					result = result.Or(patterns[i]);
				}
				return result;
			}
		}

		/// <summary>
		/// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <param name="comparisonType">The <see cref="Compare"/> to use for all <paramref name="patterns"/>.</param>
		/// <param name="patterns">The set of <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		public static Pattern OneOf(Compare comparisonType, params String[] patterns) {
			Guard.NotNull(patterns, nameof(patterns));
			if (patterns.Length < 2) {
				throw new ArgumentException("Must have at least two patterns", nameof(patterns));
			} else {
				Pattern result = patterns[0].With(comparisonType).Or(patterns[1].With(comparisonType));
				for (Int32 i = 2; i < patterns.Length; i++) {
					result = result.Or(patterns[i].With(comparisonType));
				}
				return result;
			}
		}

		/// <summary>
		/// Declares the <paramref name="patterns"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <param name="comparisonType">The <see cref="Compare"/> to use for all <paramref name="patterns"/>.</param>
		/// <param name="patterns">The set of <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> alternating all of the <paramref name="patterns"/>.</returns>
		public static Pattern OneOf(Compare comparisonType, params Char[] patterns) {
			Guard.NotNull(patterns, nameof(patterns));
			if (patterns.Length < 2) {
				throw new ArgumentException("Must have at least two patterns", nameof(patterns));
			} else {
				Pattern result = patterns[0].With(comparisonType).Or(patterns[1].With(comparisonType));
				for (Int32 i = 2; i < patterns.Length; i++) {
					result = result.Or(patterns[i].With(comparisonType));
				}
				return result;
			}
		}

		/// <summary>
		/// Declares the names of <typeparamref name="E"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <typeparam name="E">The <see cref="Enum"/> providing names.</typeparam>
		/// <returns>A new <see cref="Pattern"/> alternating all the names of <typeparamref name="E"/>.</returns>
		public static Pattern OneOf<E>() where E : Enum => OneOf<E>(Compare.NoPreference);

		/// <summary>
		/// Declares the names of <typeparamref name="E"/> to be alternates of each other; one of them will match.
		/// </summary>
		/// <param name="comparisonType">The <see cref="Compare"/> to use for all <typeparamref name="E"/>.</param>
		/// <typeparam name="E">The <see cref="Enum"/> providing names.</typeparam>
		/// <returns>A new <see cref="Pattern"/> alternating all the names of <typeparamref name="E"/>.</returns>
		public static Pattern OneOf<E>(Compare comparisonType) where E : Enum => OneOf(comparisonType, Enum.GetNames(typeof(E)));

		#endregion

		#region Capturer

		public static implicit operator Pattern(Capture capture) {
			Guard.NotNull(capture, nameof(capture));
			return new CaptureLiteral(capture);
		}

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="capture"/> for later reference.
		/// </summary>
		/// <param name="capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns>A new <see cref="Pattern"/> which will capture its result into <paramref name="capture"/>.</returns>
		public virtual Pattern Capture(out Capture capture) {
			return new Capturer(this, out capture);
		}

		#endregion

		#region Checker

		/// <summary>
		/// Use the <paramref name="check"/> to represent a single character.
		/// </summary>
		/// <param name="check">A <see cref="Func{T, TResult}"/> to validate the character.</param>
		/// <returns></returns>
		public static Pattern Check(Func<Char, Boolean> check) {
			Guard.NotNull(check, nameof(check));
			return new CharChecker(check);
		}

		/// <summary>
		/// Use the <paramref name="check"/> to represent a single character.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="check">A <see cref="Func{T, TResult}"/> to validate the character.</param>
		/// <returns></returns>
		[Obsolete("Remove the name parameter as it's no longer used.")]
		public static Pattern Check(String name, Func<Char, Boolean> check) => Check(check);

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent a variable length string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) {
			Guard.NotNull(headCheck, nameof(headCheck));
			Guard.NotNull(bodyCheck, nameof(bodyCheck));
			Guard.NotNull(tailCheck, nameof(tailCheck));
			return new StringChecker(headCheck, bodyCheck, tailCheck);
		}

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent a variable length string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		[Obsolete("Remove the name parameter as it's no longer used.")]
		public static Pattern Check(String name, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) => Check(headCheck, bodyCheck, tailCheck);

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent a variable length string, along with whether each check is required for a valid string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="headRequired">Whether the <paramref name="headCheck"/> is required.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="bodyRequired">Whether the <paramref name="bodyCheck"/> is required.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <param name="tailRequired">Whether the <paramref name="tailRequired"/> is required.</param>
		/// <returns></returns>
		public static Pattern Check(Func<Char, Boolean> headCheck, Boolean headRequired, Func<Char, Boolean> bodyCheck, Boolean bodyRequired, Func<Char, Boolean> tailCheck, Boolean tailRequired) {
			Guard.NotNull(headCheck, nameof(headCheck));
			Guard.NotNull(bodyCheck, nameof(bodyCheck));
			Guard.NotNull(tailCheck, nameof(tailCheck));
			return new StringChecker(headCheck, headRequired, bodyCheck, bodyRequired, tailCheck, tailRequired);
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
		[Obsolete("Remove the name parameter as it's no longer used.")]
		public static Pattern Check(String name, Func<Char, Boolean> headCheck, Boolean headRequired, Func<Char, Boolean> bodyCheck, Boolean bodyRequired, Func<Char, Boolean> tailCheck, Boolean tailRequired) => Check(headCheck, headRequired, bodyCheck, bodyRequired, tailCheck, tailRequired);

		/// <summary>
		/// Use the specified <paramref name="headCheck"/>, <paramref name="bodyCheck"/>, and <paramref name="tailCheck"/> to represent the valid form of a word, along with the <paramref name="bias"/>.
		/// </summary>
		/// <param name="name">Name to display this pattern as.</param>
		/// <param name="bias">Endian bias of the word. Head bias requires the head if only one letter is present. Tail bias requires the tail if only one letter is present.</param>
		/// <param name="headCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="bodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="tailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(Bias bias, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) {
			Guard.NotNull(headCheck, nameof(headCheck));
			Guard.NotNull(bodyCheck, nameof(bodyCheck));
			Guard.NotNull(tailCheck, nameof(tailCheck));
			return new WordChecker(bias, headCheck, bodyCheck, tailCheck);
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
		[Obsolete("Remove the name parameter as it's not longer used")]
		public static Pattern Check(String name, Bias bias, Func<Char, Boolean> headCheck, Func<Char, Boolean> bodyCheck, Func<Char, Boolean> tailCheck) => Check(bias, headCheck, bodyCheck, tailCheck);

		#endregion

		#region Concatenator

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Pattern"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal virtual Pattern Concatenate(Pattern right) {
			Guard.NotNull(right, nameof(right));
			return new Concatenator(this, right);
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns>
		internal virtual Pattern Concatenate(Char right) => new Concatenator(this, new CharLiteral(right));

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal virtual Pattern Concatenate(String right) {
			Guard.NotNull(right, nameof(right));
			return new Concatenator(this, new StringLiteral(right));
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Pattern"/> comes before the <paramref name="right"/> <see cref="String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="right"/>.</returns
		internal virtual Pattern Concatenate(ReadOnlySpan<Char> right) => new Concatenator(this, new StringLiteral(right));

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Pattern other) {
			Guard.NotNull(other, nameof(other));
			return Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="String"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(String other) {
			Guard.NotNull(other, nameof(other));
			return Concatenate(other);
		}

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(ReadOnlySpan<Char> other) => Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Char"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Char other) => Concatenate(other);

		/// <summary>
		/// Concatenates the patterns so that this <see cref="Pattern"/> comes before <paramref name="other"/>
		/// </summary>
		/// <param name="other">The succeeding <see cref="Pattern"/></param>
		/// <returns>A new <see cref="Pattern"/> concatenating this <see cref="Pattern"/> and <paramref name="other"/></returns>
		public virtual Pattern Then(Capture other) {
			Guard.NotNull(other, nameof(other));
			return Concatenate(new CaptureLiteral(other));
		}

		#endregion

		#region Fuzzer

		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		public static Pattern Fuzzy(String @string) {
			Guard.NotNull(@string, nameof(@string));
			return new Fuzzer(@string);
		}

		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <param name="maxEdits">The maximum allowed edits to still be considered a match.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		public static Pattern Fuzzy(String @string, Int32 maxEdits) {
			Guard.NotNull(@string, nameof(@string));
			return new Fuzzer(@string, maxEdits);
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
		internal virtual Pattern Negate() => new Negator(this);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Pattern pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return pattern.Negate();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="String"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(String pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new StringLiteral(pattern).Negate();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(ReadOnlySpan<Char> pattern) => new StringLiteral(pattern).Negate();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Char"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Char pattern) => new CharLiteral(pattern).Negate();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Patterns.Capture"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which has been negated.</returns>
		public static Pattern Not(Capture pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new CaptureLiteral(pattern).Negate();
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
		internal virtual Pattern Optional() => new Optor(this);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Pattern pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return pattern.Optional();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(String pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new StringLiteral(pattern).Optional();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(ReadOnlySpan<Char> pattern) => new StringLiteral(pattern).Optional();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Char pattern) => new CharLiteral(pattern).Optional();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as optional.
		/// </summary>
		/// <param name="pattern">The optional <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is optional.</returns>
		public static Pattern Maybe(Capture pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new CaptureLiteral(pattern).Optional();
		}

		#endregion

		#region Ranger

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>.
		/// </summary>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		public static Pattern Range(Pattern from, Pattern to) {
			Guard.NotNull(from, nameof(from));
			Guard.NotNull(to, nameof(to));
			return new Ranger(from, to);
		}

		/// <summary>
		/// Create a pattern representing the range <paramref name="from"/> until <paramref name="to"/>, allowing an <paramref name="escape"/>.
		/// </summary>
		/// <param name="from">Begining <see cref="Pattern"/>.</param>
		/// <param name="to">Ending <see cref="Pattern"/>.</param>
		/// <param name="escape">Escape <see cref="Pattern"/>./</param>
		public static Pattern Range(Pattern from, Pattern to, Pattern escape) {
			Guard.NotNull(from, nameof(from));
			Guard.NotNull(to, nameof(to));
			Guard.NotNull(escape, nameof(escape));
			return new EscapedRanger(from, to, escape);
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
			Guard.NotNull(from, nameof(from));
			Guard.NotNull(to, nameof(to));
			return new NestedRanger(from, to);
		}

		#endregion

		#region Repeater

		/// <summary>
		/// Marks this <see cref="Pattern"/> as repeating <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Pattern"/> repeated <paramref name="count"/> times.</returns>
		public virtual Pattern Repeat(Int32 count) => new Repeater(this, count);

		#endregion

		#region Spanner

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		/// <remarks>
		/// This exists to set up dispatching to the appropriate <see cref="Pattern"/> type. Dispatching happens to be faster than switching on a typeclass.
		/// </remarks
		internal virtual Pattern Span() => new Spanner(this);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Pattern"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Pattern pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return pattern.Span();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="String"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(String pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new StringLiteral(pattern).Span();
		}

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(ReadOnlySpan<Char> pattern) => new StringLiteral(pattern).Span();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Char pattern) => new CharLiteral(pattern).Span();

		/// <summary>
		/// Marks the <paramref name="pattern"/> as spanning.
		/// </summary>
		/// <param name="pattern">The spanning <see cref="Capture"/>.</param>
		/// <returns>A new <see cref="Pattern"/> which is spanning.</returns>
		public static Pattern Many(Capture pattern) {
			Guard.NotNull(pattern, nameof(pattern));
			return new CaptureLiteral(pattern).Span();
		}

		#endregion
	}
}
