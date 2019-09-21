using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public abstract class Pattern : IEquatable<String> {
		/// <summary>
		/// Checks the first character in the <paramref name="Source"/> against the header of this pattern
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="Source">The <see cref="Source"/> to check against</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal abstract Boolean CheckHeader(ref Source Source);

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>
		/// </summary>
		/// <param name="Source">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(String Source) {
			Source source = new Source(Source);
			return Consume(ref source);
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/></returns>
		public Result Consume(ref Source Source) {
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			return Result;
		}

		internal abstract void Consume(ref Source Source, ref Result Result);

		internal abstract void Neglect(ref Source Source, ref Result Result);

		/// <summary>
		/// Determines whether this instance and a specified object, which must also be a String object, have the same value.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public abstract override Boolean Equals(Object obj);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public virtual Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			return Consume(ref Source) && Source.Length == 0;
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Pattern"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Pattern"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public virtual Boolean Equals(String other) {
			Source Source = new Source(other);
			return Consume(ref Source) && Source.Length == 0;
		}

		/// <summary>
		/// Returns the hash code for this <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public abstract override Int32 GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Pattern"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Pattern"/>.</returns>
		public abstract override String ToString();

		#region Literals

		public static implicit operator Pattern(Char Char) => new CharLiteral(Char);

		public static implicit operator Pattern((Char Char, StringComparison ComparisonType) Pattern) => new CharLiteral(Pattern.Char, Pattern.ComparisonType);

		public static implicit operator Pattern(String Pattern) => new StringLiteral(Pattern);

		public static implicit operator Pattern((String String, StringComparison ComparisonType) Pattern) => new StringLiteral(Pattern.String, Pattern.ComparisonType);

		#endregion

		#region Alternator

		internal virtual Pattern Alternate(Pattern Right) => new Alternator(this, Right);

		internal virtual Pattern Alternate(Char Right) => new Alternator(this, Right);

		internal virtual Pattern Alternate(String Right) => new Alternator(this, Right);

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, Pattern Right) => Left.Alternate(Right);

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="Char"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, Char Right) => Left.Alternate(Right);

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Char"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Char Left, Pattern Right) => Left.Alternate(Right);

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="Pattern"/> to check first</param>
		/// <param name="Right">The <see cref="String"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(Pattern Left, String Right) => Left.Alternate(Right);

		/// <summary>
		/// Declares <paramref name="Right"/> to be an alternate of <paramref name="Left"/>
		/// </summary>
		/// <param name="Left">The <see cref="String"/> to check first</param>
		/// <param name="Right">The <see cref="Pattern"/> to check if <paramref name="Left"/> does not match</param>
		/// <returns></returns>
		public static Pattern operator |(String Left, Pattern Right) => Left.Alternate(Right);

		#endregion

		#region Capturer

		public static implicit operator Pattern(Capture Capture) => new CaptureLiteral(Capture);

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="Capture"/> for later reference
		/// </summary>
		/// <param name="Capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns></returns>
		public virtual Pattern Capture(out Capture Capture) => new Capturer(this, out Capture);

		#endregion

		#region Checker

		[Obsolete("Use Pattern.Check() now")]
		public static implicit operator Pattern((String Name, Func<Char, Boolean> Check) Checker) => new CharChecker(Checker.Name, Checker.Check);

		/// <summary>
		/// Use the <paramref name="Check"/> to represent a single character.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="Check">A <see cref="Func{T, TResult}"/> to validate the character.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> Check) => new CharChecker(Name, Check);

		[Obsolete("Use Pattern.Check() now")]
		public static implicit operator Pattern((String Name, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) Checker) => new StringChecker(Checker.Name, Checker.HeadCheck, Checker.BodyCheck, Checker.TailCheck);

		/// <summary>
		/// Use the specified <paramref name="HeadCheck"/>, <paramref name="BodyCheck"/>, and <paramref name="TailCheck"/> to represent a variable length string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="HeadCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="BodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="TailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> HeadCheck, Func<Char, Boolean> BodyCheck, Func<Char, Boolean> TailCheck) => new StringChecker(Name, HeadCheck, BodyCheck, TailCheck);

		[Obsolete("Use Pattern.Check() now")]
		public static implicit operator Pattern((String Name, Func<Char, Boolean> HeadCheck, Boolean HeadRequired, Func<Char, Boolean> BodyCheck, Boolean BodyRequired, Func<Char, Boolean> TailCheck, Boolean TailRequired) Checker) => new StringChecker(Checker.Name, Checker.HeadCheck, Checker.HeadRequired, Checker.BodyCheck, Checker.BodyRequired, Checker.TailCheck, Checker.TailRequired);

		/// <summary>
		/// Use the specified <paramref name="HeadCheck"/>, <paramref name="BodyCheck"/>, and <paramref name="TailCheck"/> to represent a variable length string, along with whether each check is required for a valid string. The head and tail are only present once, with the body being repeatable.
		/// </summary>
		/// <param name="Name">Name to display this pattern as.</param>
		/// <param name="HeadCheck">A <see cref="Func{T, TResult}"/> to validate the head.</param>
		/// <param name="HeadRequired">Whether the <paramref name="HeadCheck"/> is required.</param>
		/// <param name="BodyCheck">A <see cref="Func{T, TResult}"/> to validate the body, which may repeat.</param>
		/// <param name="BodyRequired">Whether the <paramref name="BodyCheck"/> is required.</param>
		/// <param name="TailCheck">A <see cref="Func{T, TResult}"/> to validate the tail.</param>
		/// <param name="TailRequired">Whether the <paramref name="TailRequired"/> is required.</param>
		/// <returns></returns>
		public static Pattern Check(String Name, Func<Char, Boolean> HeadCheck, Boolean HeadRequired, Func<Char, Boolean> BodyCheck, Boolean BodyRequired, Func<Char, Boolean> TailCheck, Boolean TailRequired) => new StringChecker(Name, HeadCheck, HeadRequired, BodyCheck, BodyRequired, TailCheck, TailRequired);

		#endregion

		#region Concatenator

		internal virtual Pattern Concatenate(Pattern Right) => new Concatenator(this, Right);

		internal virtual Pattern Concatenate(Char Right) => new Concatenator(this, Right);

		internal virtual Pattern Concatenate(String Right) => new Concatenator(this, Right);

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, Pattern Right) => Left.Concatenate(Right);

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="Char"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, Char Right) => Left.Concatenate(Right);

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Char"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(Char Left, Pattern Right) => Left.Concatenate(Right);

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="Pattern"/></param>
		/// <param name="Right">The succeeding <see cref="String"/></param>
		/// <returns></returns>
		public static Pattern operator &(Pattern Left, String Right) => Left.Concatenate(Right);

		/// <summary>
		/// Concatenates the patterns so that <paramref name="Left"/> comes before <paramref name="Right"/>
		/// </summary>
		/// <param name="Left">The preceeding <see cref="String"/></param>
		/// <param name="Right">The succeeding <see cref="Pattern"/></param>
		/// <returns></returns>
		public static Pattern operator &(String Left, Pattern Right) => Left.Concatenate(Right);

		#endregion

		#region Negator

		internal virtual Pattern Negate() => new Negator(this);

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as negated
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator !(Pattern Pattern) => Pattern.Negate();

		#endregion

		#region Optor

		internal virtual Pattern Optional() => new Optor(this);

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as optional
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator -(Pattern Pattern) => Pattern.Optional();

		#endregion

		#region Ranger

		public static implicit operator Pattern((Pattern From, Pattern To) Range) => new Ranger(Range.From, Range.To);

		public static implicit operator Pattern((Pattern From, Pattern To, Pattern Escape) Range) => new EscapedRanger(Range.From, Range.To, Range.Escape);

		public static implicit operator Pattern((Pattern From, Pattern To, Boolean Nested) Range) => Range.Nested ? new NestedRanger(Range.From, Range.To) : new Ranger(Range.From, Range.To);

		#endregion

		#region Repeater

		internal virtual Pattern Repeat(Int32 Count) => new Repeater(this, Count);

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as repeating <paramref name="Count"/> times
		/// </summary>
		/// <param name="Pattern"></param>
		/// <param name="Count"></param>
		/// <returns></returns>
		public static Pattern operator *(Pattern Pattern, Int32 Count) => Pattern.Repeat(Count);

		#endregion

		#region Spanner

		internal virtual Pattern Span() => new Spanner(this);

		/// <summary>
		/// Marks the <paramref name="Pattern"/> as spanning
		/// </summary>
		/// <param name="Pattern"></param>
		/// <returns></returns>
		public static Pattern operator +(Pattern Pattern) => Pattern.Span();

		#endregion

		#region Unicode Category Patterns

		public static readonly Pattern ClosePunctuation = new CharChecker("[Pe]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = new CharChecker("[Pc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = new CharChecker("[Cc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = new CharChecker("[Sc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = new CharChecker("[Pd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = new CharChecker("[Nd]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = new CharChecker("[Me]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = new CharChecker("[Pf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = new CharChecker("[Cf]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = new CharChecker("[Pi]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = new CharChecker("[Nl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = new CharChecker("[Zl]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = new CharChecker("[Ll]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = new CharChecker("[Sm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = new CharChecker("[Lm]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = new CharChecker("[Sk]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = new CharChecker("[Mn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = new CharChecker("[Ps]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = new CharChecker("[Lo]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = new CharChecker("[Cn]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = new CharChecker("[No]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = new CharChecker("[Po]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = new CharChecker("[So]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = new CharChecker("[Zp]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = new CharChecker("[Co]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = new CharChecker("[Zs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = new CharChecker("[Mc]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = new CharChecker("[Cs]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = new CharChecker("[Lt]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = new CharChecker("[Lu]", (Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

		public static readonly Pattern Letter = new CharChecker("[L*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			_ => false
		});

		public static readonly Pattern Mark = new CharChecker("[M*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			_ => false
		});

		public static readonly Pattern Number = new CharChecker("[N*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			_ => false
		});

		public static readonly Pattern Punctuation = new CharChecker("[P*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			_ => false
		});

		public static readonly Pattern Symbol = new CharChecker("[S*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			_ => false
		});

		public static readonly Pattern Separator = new CharChecker("[Z*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		});

		public static readonly Pattern Graphic = new CharChecker("[G*]", (Char) => Char.GetUnicodeCategory() switch {
			UnicodeCategory.UppercaseLetter => true,
			UnicodeCategory.LowercaseLetter => true,
			UnicodeCategory.TitlecaseLetter => true,
			UnicodeCategory.EnclosingMark => true,
			UnicodeCategory.NonSpacingMark => true,
			UnicodeCategory.SpacingCombiningMark => true,
			UnicodeCategory.DecimalDigitNumber => true,
			UnicodeCategory.LetterNumber => true,
			UnicodeCategory.OtherNumber => true,
			UnicodeCategory.ConnectorPunctuation => true,
			UnicodeCategory.DashPunctuation => true,
			UnicodeCategory.FinalQuotePunctuation => true,
			UnicodeCategory.InitialQuotePunctuation => true,
			UnicodeCategory.OpenPunctuation => true,
			UnicodeCategory.ClosePunctuation => true,
			UnicodeCategory.OtherPunctuation => true,
			UnicodeCategory.CurrencySymbol => true,
			UnicodeCategory.MathSymbol => true,
			UnicodeCategory.ModifierSymbol => true,
			UnicodeCategory.OtherSymbol => true,
			UnicodeCategory.LineSeparator => true,
			UnicodeCategory.ParagraphSeparator => true,
			UnicodeCategory.SpaceSeparator => true,
			_ => false
		});

		#endregion

		#region Additional Patterns

		/// <summary>
		/// Not a UNICODE group, but instead, the various line terminators Operating Systems recognize.
		/// </summary>
		/// <remarks>
		/// The CR+LF used by Windows, DOS, OS2, PalmOS, and others is checked first, because otherwise only the single CR would be matched. Similarly, because RISC OS uses LF+CR this check occurs directly after CR+LF, before any single characters.
		/// </remarks>
		public static readonly Pattern LineTerminator = (Pattern)"\u000D\u000A" | "\u000A\u000D" | "\u000A" | "\u000B" | "\u000C" | "\u000D" | "\u0085" | "\u2028" | "\u2029";

		/// <summary>
		/// Matches any possible character
		/// </summary>
		public static readonly Pattern Any = new CharChecker("*", (_) => true);

		#endregion
	}
}
