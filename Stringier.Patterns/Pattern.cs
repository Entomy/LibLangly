﻿using System.Globalization;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents a textual pattern
	/// </summary>
	public abstract class Pattern : IEquatable<String> {
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

		public abstract override Boolean Equals(Object obj);

		public virtual Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			return Consume(ref Source) && Source.Length == 0;
		}

		public virtual Boolean Equals(String other) {
			Source Source = new Source(other);
			return Consume(ref Source) && Source.Length == 0;
		}

		public abstract override Int32 GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current object.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current object.</returns>
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

		/// <summary>
		/// Declares this <see cref="Pattern"/> should be captured into <paramref name="Capture"/> for later reference
		/// </summary>
		/// <param name="Capture">A <see cref="Patterns.Capture"/> object to store into.</param>
		/// <returns></returns>
		public virtual Pattern Capture(out Capture Capture) => new Capturer(this, out Capture);

		#endregion

		#region Checker

		public static implicit operator Pattern(Func<Char, Boolean> Check) => new CharChecker(Check);

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

		public static readonly Pattern ClosePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ClosePunctuation);

		public static readonly Pattern ConnectorPunctutation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ConnectorPunctuation);

		public static readonly Pattern Control = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Control);

		public static readonly Pattern CurrencySymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.CurrencySymbol);

		public static readonly Pattern DashPunctutation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DashPunctuation);

		public static readonly Pattern DecimalDigitNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.DecimalDigitNumber);

		public static readonly Pattern EnclosingMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.EnclosingMark);

		public static readonly Pattern FinalQuotePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.FinalQuotePunctuation);

		public static readonly Pattern Format = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Format);

		public static readonly Pattern InitialQuotePunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.InitialQuotePunctuation);

		public static readonly Pattern LetterNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LetterNumber);

		public static readonly Pattern LineSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LineSeparator);

		public static readonly Pattern LowercaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.LowercaseLetter);

		public static readonly Pattern MathSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.MathSymbol);

		public static readonly Pattern ModifierLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierLetter);

		public static readonly Pattern ModifierSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ModifierSymbol);

		public static readonly Pattern NonSpacingMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.NonSpacingMark);

		public static readonly Pattern OpenPunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OpenPunctuation);

		public static readonly Pattern OtherNotAssigned = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNotAssigned);

		public static readonly Pattern OtherNumber = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherNumber);

		public static readonly Pattern OtherPunctuation = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherPunctuation);

		public static readonly Pattern OtherSymbol = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.OtherSymbol);

		public static readonly Pattern ParagraphSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.ParagraphSeparator);

		public static readonly Pattern PrivateUse = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.PrivateUse);

		public static readonly Pattern SpaceSeparator = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpaceSeparator);

		public static readonly Pattern SpacingCombiningMark = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.SpacingCombiningMark);

		public static readonly Pattern Surrogate = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.Surrogate);

		public static readonly Pattern TitlecaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.TitlecaseLetter);

		public static readonly Pattern UppercaseLetter = new CharChecker((Char) => Char.GetUnicodeCategory() == UnicodeCategory.UppercaseLetter);

		public static readonly Pattern Letter = LowercaseLetter | TitlecaseLetter | UppercaseLetter;

		public static readonly Pattern Mark = EnclosingMark | NonSpacingMark | SpacingCombiningMark;

		public static readonly Pattern Number = DecimalDigitNumber | LetterNumber | OtherNumber;

		public static readonly Pattern Punctuation = ConnectorPunctutation | DashPunctutation | FinalQuotePunctuation | InitialQuotePunctuation | OpenPunctuation | OtherPunctuation;

		public static readonly Pattern Symbol = CurrencySymbol | MathSymbol | ModifierSymbol | OtherSymbol;

		public static readonly Pattern Separator = LineSeparator | ParagraphSeparator | SpaceSeparator;

		public static readonly Pattern Graphic = Letter | Mark | Number | Punctuation | Symbol | SpaceSeparator;

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
		public static readonly Pattern Any = new CharChecker((_) => true);

		#endregion
	}
}
